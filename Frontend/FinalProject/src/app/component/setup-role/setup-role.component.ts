import { Component, OnInit, TRANSLATIONS } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegistrationService } from 'src/app/service/registration.service';
import { StorageService } from 'src/app/service/storage.service';

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
  isJobRequester = false;
  fileAttr = null;
  roleId: number = 0;
  outherProfessions = new FormControl();

  constructor(
    private _formBuilder: FormBuilder,
    private registrationService: RegistrationService,
    private storageService: StorageService,
    private router: Router,) { }

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
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      adress: ['', Validators.required],
      postcode: ['', Validators.required]
    });
    
    this.secondFormGroup = this._formBuilder.group({
      mainProfession: ['', Validators.required],
      secundaryProfession: ['', Validators.required],
      hobby: ["",],
      funFact: [""]
    });
  }

  finishUserConfiguation() {
    // if (this.roleId == 2) {
      var UserProfileCompletedForWorker = {
        userName: this.firstFormGroup.value.firstName + " " + this.firstFormGroup.value.lastName,
        phoneNumber: this.firstFormGroup.value.phoneNumber,
        address: this.firstFormGroup.value.adress,
        postcode: this.firstFormGroup.value.postcode,
        mainProfession: this.secondFormGroup.value.mainProfession,
        secundaryProfession: this.secondFormGroup.value.secundaryProfession,
        hobby: this.secondFormGroup.value.hobby,
        funFact: this.secondFormGroup.value.funFact,
        roleId: this.roleId
       }
      // console.log("steap[2");
      this.registrationService.completeUserProfile(UserProfileCompletedForWorker).subscribe(_ => {
        this.router.navigate(['']);
    
     
  //   }

  //   if (this.roleId == 3) {
  //     var UserProfileCompletedForJobProvider = {
  //       userName: this.firstFormGroup.value.firstName + " " + this.firstFormGroup.value.lastName,
  //       phoneNumber: this.firstFormGroup.value.phoneNumber,
  //       address: this.firstFormGroup.value.adress,
  //       postcode: this.firstFormGroup.value.postcode,
  //       hobby: this.firstFormGroup.value.hobby,
  //       funFact: this.firstFormGroup.value.funFact,
  //       roleId: this.roleId
  //     }
  //     console.log("steap[3");
  //     this.registrationService.completeUserProfile(UserProfileCompletedForJobProvider);
  //   }

  //   if (this.roleId == 4) {
  //     var UserProfileCompletedForBothRoles = {
  //       userName: this.firstFormGroup.value.firstName + " " + this.firstFormGroup.value.lastName,
  //       phoneNumber: this.firstFormGroup.value.phoneNumber,
  //       address: this.firstFormGroup.value.adress,
  //       postcode: this.firstFormGroup.value.postcode,
  //       mainProfession: this.firstFormGroup.value.mainProfession,
  //       secundaryProfession: this.firstFormGroup.value.secundaryProfession,
  //       hobby: this.firstFormGroup.value.hobby,
  //       funFact: this.firstFormGroup.value.funFact,
  //       roleId: this.roleId
  //     }
  //     console.log("steap[4");
  //     this.registrationService.completeUserProfile(UserProfileCompletedForBothRoles);
  
      }
      )}
  setIsJobRequesterValue(event: any) {
    if (event.value === 2) {
      console.log(2);
      this.isJobRequester = true;
      this.roleId = 2;

      console.log(this.firstFormGroup.value.firstName);
    }

    if (event.value === 3) {
      console.log(3);
      this.isJobRequester = false;
      this.roleId = 3;
    }

    if (event.value === 4) {
      console.log(4);
      this.isJobRequester = true;
      this.roleId = 4;
    }
  }
}