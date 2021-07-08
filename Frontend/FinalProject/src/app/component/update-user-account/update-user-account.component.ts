import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-user-account',
  templateUrl: './update-user-account.component.html',
  styleUrls: ['./update-user-account.component.scss']
})
export class UpdateUserAccountComponent implements OnInit {
  public email: string = '';
  public password: string = ''
  editUserFormGroup!: FormGroup;
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
