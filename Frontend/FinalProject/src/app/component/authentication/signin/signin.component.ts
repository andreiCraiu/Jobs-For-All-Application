import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';
import { User } from 'src/app/model/User';
import { StorageService } from 'src/app/service/storage.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';
import { CurrentUser } from 'src/app/model/currentUser';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})

export class SigninComponent implements OnInit {
  public email: string = '';
  public password: string = '';
  currentUser! : CurrentUser;
  isAdminUser = false;
  constructor(
    private authenticateService: AuthenticationService,
    private storageService: StorageService,
    private userService: UserService,
    private router: Router,
  ) { }

  login() {
    var user = {
      email: this.email,
      password: this.password
    };

    // this.userService.findUserByEmail(this.email).subscribe(user => {
    //   this.currentUser = user;
    // });
    console.log(this.currentUser)
    this.authenticateService.authorizeUser(user).subscribe(response => {
      this.storageService.setLoggedInUser(response);
      this.router.navigate(["main-page"]);
      // if(this.currentUser.Role = 1){
      //   this.isAdminUser = true;
      //   this.router.navigate(["main-page"]);
      // }
      // if(this.currentUser.Role = 2){
      //   this.router.navigate(["main-page"]);
      // }
      
    })
  }
  
  ngOnInit(): void {
    
  }

}
