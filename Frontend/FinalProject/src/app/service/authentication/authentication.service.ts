import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApplicationUserLogin } from 'src/app/model/loginUser';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
  private baseApiUrl = `${environment.baseApiUrl}/authentication/login`;
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }

  public authorizeUser(authRequest: { email: string; password: string; }){
    return this.httpClient.post<ApplicationUserLogin>(`${this.baseApiUrl}`, authRequest, { headers: this.headers });
  }
}
