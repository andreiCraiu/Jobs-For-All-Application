import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ChatView } from 'src/app/enums/chat-view';
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
  styleUrls: ['./chat-message.component.scss']
})

export class ChatMessageComponent implements OnInit {
  private message!: Message;
  private userId : any;
  public textArea: string = '';
  public isEmojiPickerVisible!: boolean;

  constructor(
    private messageService: MessagesService,
    private route: ActivatedRoute
    ) { }


  ngOnInit(): void {
    this.route.params.subscribe((params: Params) => {
      this.userId = params['userId'];
      console.log(params['userId']);
  });
}

 public addEmoji(event:any) {
      this.textArea = `${this.textArea}${event.emoji.native}`;
      this.isEmojiPickerVisible = false;
   }

  call22(){
    this.message = new Message()
    this.message.content = "HEllo"
    this.message.receiverId = this.userId
    this.messageService.saveMessage(this.message).subscribe(_ =>{})
  }
}
