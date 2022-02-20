import { Component, Input, OnInit } from '@angular/core';
import { C, p, t } from '@angular/core/src/render3';
import { SELECT_PANEL_INDENT_PADDING_X } from '@angular/material/select/select';
import { ActivatedRoute, Params } from '@angular/router';
import { ChatView } from 'src/app/enums/chat-view';
import { Chat } from 'src/app/model/chat';
import { CurrentUser } from 'src/app/model/currentUser';
import { Message } from 'src/app/model/message';
import { User } from 'src/app/model/User';
import { MessageCommunicationService } from 'src/app/service/communcation-services/messages-communication.service';
import { MessagesService } from 'src/app/service/messages.service';
import { StorageService } from 'src/app/service/storage.service';
import { UserService } from 'src/app/service/user.service';
import { threadId } from 'worker_threads';

@Component({
  selector: 'app-chat-message',
  templateUrl: './chat-message.component.html',
  styleUrls: ['./chat-message.component.scss']
})

export class ChatMessageComponent implements OnInit {
  private message!: Message;
  private userId: any;
  public messageText: string = '';
  public messageList!: Message[];
  public messageClass: string = 'message-sent';
  private chat!: Chat;
  public chatList: Chat[] = new Array();
  private currentChatID!: number;
  private dataReceived: Message = new Message();
  private sender!: CurrentUser;
  constructor(
    private messageService: MessagesService,
    private route: ActivatedRoute,
    private messageCommunicationService: MessageCommunicationService,
    private userService: UserService
  ) {
  }


  async ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
    });

    console.log("class", this.messageClass);
    this.messageService.startSignalRConnection();

    this.userService.getCurrentUser().subscribe(user => {
      this.sender = user;
      console.log("currentUser!!!!!!!!", this.sender);
      this.messageService.getChatList(user.id).subscribe(list => {
        this.chatList = list;
        this.setCurrentChatId(list);
        this.loadMessages();
      
      });
    });
     this.messageCommunicationService.messageObservable$.subscribe(data => {
      this.dataReceived = <Message>data;
      console.log("Data Rec:", this.dataReceived);
     })
  }

  setCurrentChatId(chatList: any) {
    debugger
    if(chatList){
      this.currentChatID = this.chatList[0].id;
    }else{
      this.currentChatID = 0;
    }
  }

  activeChat(chatId: number) {
    this.currentChatID = chatId;
    this.loadMessages()
  }

  async setMessageClass(){
    if(this.sender.id == this.dataReceived.senderId){
      this.messageClass = "message-sent";
    }else{
      this.messageClass = "message-received"
    }
    console.log("class", this.messageClass)
  }
  async loadMessages() {
    this.messageList = await this.messageService.getMessageList(this.currentChatID);
    console.log("ML", this.messageList)
  }

  saveMessage() {
    this.message = new Message();
    this.chat = new Chat();

    this.messageList = new Array();
    this.message.content = this.messageText;
    this.message.receiverId = this.userId;
    this.message.senderId = this.sender.id;
    this.message.chatId = this.currentChatID;

    this.messageService.saveMessage(this.message).subscribe(x => {
      console.log("this is mid", x)
    });

   this.setMessageClass();
  }


}
