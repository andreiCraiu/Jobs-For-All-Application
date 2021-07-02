import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ApplicationUserRegister } from '../model/registerUser';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private baseApiUrlRegister= `${environment.baseApiUrl}/Authentication/registration`;

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }
  
  public registerUser(registerRequest: ApplicationUserRegister){
    return this.httpClient.post<ApplicationUserRegister>(`${this.baseApiUrlRegister}`, registerRequest, { headers: this.headers });
  }
}
