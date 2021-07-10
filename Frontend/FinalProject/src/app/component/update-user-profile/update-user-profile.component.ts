import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CurrentUser } from 'src/app/model/currentUser';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-update-user-profile',
  templateUrl: './update-user-profile.component.html',
  styleUrls: ['./update-user-profile.component.scss']
})
export class UpdateUserProfileComponent implements OnInit {

  editUserFormGroup!: FormGroup;
  readonly = true;
  isShowMoreActive = false;
  currentUser!: CurrentUser;
  constructor(
    private _formBuilder: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe(user => { this.currentUser = user });

    this.editUserFormGroup = this._formBuilder.group({
      // userName: [this.currentUser.UserName],
      // phoneNumber: [this.currentUser.PhoneNumber],
      // adress: [this.currentUser.Address],
      // postcode: [this.currentUser.Postcode]

      userName: ["NewValue"],
      phoneNumber: ["NewValue"],
      adress: ["NewValue"],
      postcode: ["NewValue"]
    });
  }

  updateUser() {
    if (this.readonly == false) {
      var userToBeUpdated = {
        UserName: this.editUserFormGroup.value.userName,
        PhoneNumber: this.editUserFormGroup.value.phoneNumber,
        Address: this.editUserFormGroup.value.adress,
        Postcode: this.editUserFormGroup.value.postcode,
      }
      this.userService.updateUser(userToBeUpdated).subscribe(_ => {
        this.snackBar.open('User updated succesfully', '', { duration: 2000 });
      })
    }else{
      this.snackBar.open('Edit mode is disabled', '', { duration: 2000 });
    }
  }

}
