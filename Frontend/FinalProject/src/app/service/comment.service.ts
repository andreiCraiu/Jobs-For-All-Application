import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserComment } from '../model/userComment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private baseUrl = `${environment.baseApiUrl}/comment`;

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }
  
  public addComment(comment: any, commentedUserId: string){
    return this.httpClient.post<any>(`${this.baseUrl}/addComment/${commentedUserId}`, comment, { headers: this.headers });
  }

  public getComments(id: string){
    return  this.httpClient.get<any[]>(`${this.baseUrl}/getComments/${id}`);
  }
  
  }
