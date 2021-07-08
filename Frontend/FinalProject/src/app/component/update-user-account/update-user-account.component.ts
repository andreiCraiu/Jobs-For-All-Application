import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-user-account',
  templateUrl: './update-user-account.component.html',
  styleUrls: ['./update-user-account.component.scss']
})
export class UpdateUserAccountComponent implements OnInit {
  public email: string = '';
  public password: string = '';
  isActive = true;
  isHidden = true;
  isEditPasswordActive = false;
  editUserAccountFormGroup!: FormGroup;
  constructor(
    private _formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.editUserAccountFormGroup = this._formBuilder.group({
      userName: ['gdf', Validators.required],
      email: ['dddd', Validators.required],
      password: ['ddd', Validators.required],
      confirmPassword: ['', Validators.required]
    });
  }

}
