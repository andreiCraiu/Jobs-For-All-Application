import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-user-profile',
  templateUrl: './update-user-profile.component.html',
  styleUrls: ['./update-user-profile.component.scss']
})
export class UpdateUserProfileComponent implements OnInit {

  editUserFormGroup!: FormGroup;
  isEditable = true;
  isShowMoreActive = false;
  constructor(
    private _formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.editUserFormGroup = this._formBuilder.group({
      firstName: ['gdf', Validators.required],
      lastName: ['dddd', Validators.required],
      phoneNumber: ['ddd', Validators.required],
      adress: ['', Validators.required],
      postcode: ['', Validators.required]
    });
  }

}
