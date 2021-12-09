import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginCommunicationService {
  private loginSubject = new Subject();
  loginObservable$ = this.loginSubject.asObservable();

  constructor() { }

  userLoggedIn() {
    this.loginSubject.next();
  }

  userLoggedOut() {
    this.loginSubject.next();
  }
}
