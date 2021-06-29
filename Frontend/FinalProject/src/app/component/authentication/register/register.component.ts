import { Component, OnInit } from '@angular/core';
import { ApplicationUserLogin } from 'src/app/model/loginUser';
import { AuthenticationService } from 'src/app/service/authentication/authentication.service';
import { StorageService } from 'src/app/service/storage.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public email: string = '';
  public password: string = '';
  public confirmPassword: string = '';


  constructor(
    private authenticateService: AuthenticationService,
    private storageService: StorageService
  ) { }

  register() {
    var registerRequest = {
      email: this.email,
      password: this.password,
      confirmPassword: this.confirmPassword
    };

    this.authenticateService.registerUser(registerRequest).subscribe(response => {
      this.storageService.setLoggedInUser(response);
    })

  }
  
  ngOnInit(): void {
  }



}
