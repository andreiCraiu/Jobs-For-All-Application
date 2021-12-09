import { Component, OnInit, TRANSLATIONS } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
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
  emial! : any;
  outherProfessions = new FormControl();

  constructor(
    private _formBuilder: FormBuilder,
    private registrationService: RegistrationService,
    private storageService: StorageService,
    private router: Router,
    private route: ActivatedRoute) { }

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
      adress: [''],
      postcode: ['']
    });
    
    this.secondFormGroup = this._formBuilder.group({
      mainProfession: [''],
      secundaryProfession: [''],
      hobby: [""],
      funFact: [""]
    });

    this.route.paramMap.subscribe(param => {
      this.emial = param.get("userMail");
      console.log(this.emial);
    })
  }

  finishUserConfiguation() {

      var UserProfileCompletedForWorker = {
        userName: this.firstFormGroup.value.firstName + " " + this.firstFormGroup.value.lastName,
        phoneNumber: this.firstFormGroup.value.phoneNumber,
        address: this.firstFormGroup.value.adress,
        postcode: this.firstFormGroup.value.postcode,
        mainProfession: this.secondFormGroup.value.mainProfession,
        secundaryProfession: this.secondFormGroup.value.secundaryProfession,
        hobby: this.secondFormGroup.value.hobby,
        funFact: this.secondFormGroup.value.funFact,
        role: this.roleId
       }
       console.log(UserProfileCompletedForWorker);
      this.registrationService.completeUserProfile(UserProfileCompletedForWorker, this.emial).subscribe(_ => {
        this.router.navigate(['']);
      }
      )}
  setIsJobRequesterValue(event: any) {
    if (event.value === 2) {
      this.isJobRequester = true;
      this.roleId = 2;

      console.log(this.isJobRequester);
    }

    if (event.value === 3) {
      this.isJobRequester = false;
      this.roleId = 3;
      console.log(this.isJobRequester);
    }

    if (event.value === 4) {
      this.isJobRequester = true;
      this.roleId = 4;
      console.log(this.isJobRequester);
    }
  }
}