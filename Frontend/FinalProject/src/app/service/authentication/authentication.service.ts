import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApplicationUserLogin } from 'src/app/model/loginUser';
import { ApplicationUserRegister } from 'src/app/model/registerUser';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
  private baseApiUrlLogin= `${environment.baseApiUrl}/Authentication/login`;

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }

  public authorizeUser(authRequest: any){
    return this.httpClient.post<ApplicationUserLogin>(`${this.baseApiUrlLogin}`, authRequest, { headers: this.headers });
  }

}
