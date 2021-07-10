import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { RegistrationService } from 'src/app/service/registration.service';
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
    private registerService: RegistrationService,
    private storageService: StorageService,
    private snackBar : MatSnackBar,
    private router: Router
  ) { }

  register() {
    var registerRequest = {
      email: this.email,
      password: this.password,
      confirmPassword: this.confirmPassword
    };

    this.registerService.registerUser(registerRequest).subscribe(_ => {
      this.snackBar.open('User Registered succesfully', '', { duration: 2000 });
      this.router.navigate(["setup-role"]);
    })

  }
  
  ngOnInit(): void {
  }



}
