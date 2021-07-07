import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ApplicationUserRegister } from '../model/registerUser';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private baseUrl = `${environment.baseApiUrl}/registerUser`;

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }
  
  public registerUser(registerRequest: ApplicationUserRegister){
    return this.httpClient.post<ApplicationUserRegister>(`${this.baseUrl}/completeUserRegistrtation`, registerRequest, { headers: this.headers });
  }

  public completeUserProfile(completeUserProfile: any){
    console.log(completeUserProfile);
    return this.httpClient.post<any>(`${this.baseUrl}/completeUserProfile`, completeUserProfile, { headers: this.headers });
  }
}
