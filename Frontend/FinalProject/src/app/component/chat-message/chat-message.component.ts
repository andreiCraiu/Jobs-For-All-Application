import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Chat } from 'src/app/model/chat';
import { CurrentUser } from 'src/app/model/currentUser';
import { Message } from 'src/app/model/message';
import { User } from 'src/app/model/User';
import { MessageCommunicationService } from 'src/app/service/communcation-services/messages-communication.service';
import { MessagesService } from 'src/app/service/messages.service';
import { StorageService } from 'src/app/service/storage.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-chat-message',
  templateUrl: './chat-message.component.html',
  styleUrls: ['./chat-message.component.scss'],
})
export class ChatMessageComponent implements OnInit {
  private message!: Message;
  private receiverId: any; // receiver
  public messageText: string = '';
  public messageList: Message[];
  public messageClass: string = '';
  public chatList: Chat[];
  private currentChatID!: number;
  private dataReceived: Message = new Message();
  private sender!: CurrentUser;
  public chatTitle: string;
  public senderName: string;
  public receiverName: string;
  users: any;
  isSearchingAnction = false;

  constructor(
    private messageService: MessagesService,
    private route: ActivatedRoute,
    private messageCommunicationService: MessageCommunicationService,
    private userService: UserService
  ) {}

  async ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.receiverId = params['userId']; // from users tab
    });
    this.sender = await this.userService.getCurrentUser();
    await this.loadChatList();
    this.setDefaultChatId(this.chatList);
    console.log(this.chatList, 'chatList in init');
    this.loadMessages();
    this.messageService.startSignalRConnection();

    this.messageCommunicationService.messageObservable$.subscribe(
      async (data) => {
        this.dataReceived = <Message>data;
        console.log('Data Rec:', this.dataReceived);
        console.log('data test', data);
        console.log(this.messageList?.length, 'this.messageList.length');
        if (this.dataReceived.senderId != this.sender.id) {
          console.log('insissss here mess');
          await this.loadChatList();
          await this.setDefaultChatId(this.chatList);
          this.messageList.push(this.dataReceived);
        }
      }
    );
  }
  async loadChatList() {
    console.log(this.sender.id, 'this.sender.id');
    this.chatList = await this.messageService.getChatList(this.sender.id);
  }

  async setDefaultChatId(chatList: any) {
    if (chatList.length && chatList != null) {
      this.currentChatID = this.chatList[0].id;
      this.chatTitle =  this.chatList[0].chatTitle
    } else {
      this.currentChatID = 0;
    }
    console.log(this.currentChatID, 'def ch id after set curr ch id');
  }
 async getMessageAuthor(userId: any){
    console.log(userId,'user entire')
    var messageAuthor = ''
  await  this.userService.getUser(userId).subscribe((user)=> {
      messageAuthor = user.email
    })
  console.log(messageAuthor,'messAuth')
    return messageAuthor
  }
  activeChat(chat: any) {
    console.log('ctaID', chat);
    this.currentChatID = chat.id;
    this.chatTitle = chat.chatTitle
    this.loadMessages();
  }
  createChat(user: any) {
    console.log(user, 'user');
    this.currentChatID = 0;
    this.messageList = [];
    console.log(this.sender.id, 'senderId');
    this.receiverId = user.id;
    console.log(this.receiverId == user.id, 'qula????');
    this.chatTitle = user.userName;
  }
  searchUser(event: any) {
    if (event.target.value != '') {
      this.isSearchingAnction = true;
    } else {
      this.isSearchingAnction = false;
    }
    this.userService.getFilteredUsers(event.target.value).subscribe((users) => {
      this.users = users;
      console.log('len', this.users);
    });
  }

  async loadMessages() {
    console.log('load mess started');
    this.messageList = await this.messageService.getMessageList(
      this.currentChatID
    );
    console.log(this.currentChatID, 'this.currentChatID ');
    console.log('message list', this.messageList);
  }
  composeMessage() {
    this.message = new Message();
    this.message.content = this.messageText;
    this.message.receiverId = this.receiverId;
    this.message.senderId = this.sender.id;
    this.message.chatId = this.currentChatID;
  }
  async saveMessage() {
    this.composeMessage();

    await this.messageService.saveMessage(this.message).subscribe(async (x) => {
      console.log('this is mid', x);
      this.currentChatID = x.chatId;
      this.loadChatList();
      this.activeChat(x.chatId);
    });

    console.log(this.currentChatID, 'returned chatID');
    this.isSearchingAnction = false;
  }
}
