import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApplicationUserLogin } from 'src/app/model/loginUser';
import { ApplicationUserRegister } from 'src/app/model/registerUser';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
  private baseApiUrlLogin= `${environment.baseApiUrl}/authentication/registration`;
  private baseApiUrlRegister= `${environment.baseApiUrl}/authentication/registration`;

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }

  public authorizeUser(authRequest: any){
    return this.httpClient.post<ApplicationUserLogin>(`${this.baseApiUrlLogin}`, authRequest, { headers: this.headers });
  }

  public registerUser(registerRequest: any){
    return this.httpClient.post<ApplicationUserRegister>(`${this.baseApiUrlRegister}`, registerRequest, { headers: this.headers });
  }
}
