import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CurrentUser } from '../model/currentUser';
import { User } from '../model/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseApi= `${environment.baseApiUrl}/users`;
  user: any;
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }

  public updateUser(authRequest: any){
    return this.httpClient.post<any>(`${this.baseApi}/updateUserProfile`, authRequest, { headers: this.headers });
  }

  public getCurrentUser(){
    return  this.httpClient.get<CurrentUser>(`${this.baseApi}/getCurrentUser`);
  }

  public removeUser(){
    return  this.httpClient.delete(`${this.baseApi}/deleteUser`);
  }

  public findUserByEmail(email: string){
    return this.httpClient.get<CurrentUser>(`${this.baseApi}/getUserByEmail/${email}`);
  }

  public getAllUsers(){
    return  this.httpClient.get<CurrentUser[]>(`${this.baseApi}/getAllUsers`);
  }

  public getFilteredUsers(filterString: string){
    return  this.httpClient.get<CurrentUser[]>(`${this.baseApi}/getFilteredUsers/${filterString}`);
  }

  public getUser(id: any){
    return  this.httpClient.get<CurrentUser>(`${this.baseApi}/getUser/${id}`);
  }
}
