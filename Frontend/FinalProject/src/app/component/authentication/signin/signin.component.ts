import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';
import { ApplicationUserLogin } from 'src/app/model/loginUser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})

export class SigninComponent implements OnInit {
  public email: string = '';
  public password: string = '';


  constructor(
    private authenticateService: AuthenticationService
  ) { }

  login(){
     var user = {
       email: this.email,
      password: this.password
     };

       this.authenticateService.authorizeUser(user).subscribe(response => {
        this.setLoggedInUser(response);
       })
        
  }
   
  setLoggedInUser(loggedInUser: ApplicationUserLogin){
    this.setItem('loggedInUser', JSON.stringify(loggedInUser));
}
private setItem(key: any, value: any){
  localStorage.setItem(key, value);
}
 
  ngOnInit(): void {
  }


}
