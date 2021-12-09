import { Component, Input, OnInit } from '@angular/core';
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
  isShowMoreActive = false;
  isRequestJob = true;
  public chatList!: CurrentUser[];
  public displayedColumns: string[] = [''];


  constructor(Service: UserService) { }

  ngOnInit(): void {
   
}
}
