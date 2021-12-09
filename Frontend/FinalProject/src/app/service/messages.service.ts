import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { environment } from "src/environments/environment";
import * as signalR from "@aspnet/signalr";
import { Message } from "../model/message";

@Injectable({
  providedIn: 'root'
})
export class MessagesService {
  private baseApiUrl = `${environment.baseApiUrl}/message`;
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  private hubConnection!: signalR.HubConnection;
  private messagesSubject = new Subject();
  public messagesObservable$ = this.messagesSubject.asObservable();

  constructor(private httpClient: HttpClient) { }

  public getMessages(): Observable<Message[]> {
    return this.httpClient.get<Message[]>(`${this.baseApiUrl}`);
  }

  public saveMessage(message: Message): Observable<any> {
    return this.httpClient.post<any>(`${this.baseApiUrl}`, message, { headers: this.headers });
  }

  public startSignalRConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.baseApiUrl}/chatsocket`)
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));

    this.hubConnection.on('MessageReceived', (data) => {
      this.messagesSubject.next(data);
    });
  }
}
