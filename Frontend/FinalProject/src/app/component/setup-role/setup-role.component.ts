import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-setup-role',
  templateUrl: './setup-role.component.html',
  styleUrls: ['./setup-role.component.scss']
})
export class SetupRoleComponent implements OnInit {
  checked = false;
  indeterminate = false;
  labelPosition: 'before' | 'after' = 'after';
  disabled = false;
  firstFormGroup!: FormGroup;
  secondFormGroup!: FormGroup;
  isEditable = true;
  fileAttr = null;
  outherProfessions = new FormControl();

  constructor(private _formBuilder: FormBuilder) { }

  states: string[] = [
    'Electrician', 'Labourer', 'Mechanic', 'Jointer', 'Glaizer', 'Plumber', 'Architect', 'Roofer',
    'Louisiana', 'Operator', 'Construction Worker', 'Carpenter', 'Cleaner', 'Driver', 'Tiler',
    'Painter', 'Programmer', 'IT Techinitian'
  ];

  outherProfessionList: string[] = ['Electrician', 'Labourer', 'Mechanic', 'Jointer', 'Glaizer', 'Plumber', 'Architect', 'Roofer',
  'Louisiana', 'Operator', 'Construction Worker', 'Carpenter', 'Cleaner', 'Driver', 'Tiler',
  'Painter', 'Programmer', 'IT Techinitian'];

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
   

  }
  

  
  

}
