import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { NgZone, ViewChild } from '@angular/core';
import { take } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { JobsService } from 'src/app/service/jobs.service';
import { StorageService } from 'src/app/service/storage.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Job } from 'src/app/model/job';

@Component({
  selector: 'app-request-job',
  templateUrl: './request-job.component.html',
  styleUrls: ['./request-job.component.scss']
})
export class RequestJobComponent implements OnInit {

  requestJobFormgroup!: FormGroup;
  isEditable = true;
  isPriceNegociable = false;
  isShowMoreActive = false;
  jobType = new FormControl();

  jobTypes: string[] = [
    'Electrician', 'Labourer', 'Mechanic', 'Jointer', 'Glaizer', 'Plumber', 'Architect', 'Roofer',
    'Louisiana', 'Operator', 'Construction Worker', 'Carpenter', 'Cleaner', 'Driver', 'Tiler',
    'Painter', 'Programmer', 'IT Techinitian'
  ];

  constructor(
    private _formBuilder: FormBuilder,
    private _ngZone: NgZone,
    private jobService: JobsService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  @ViewChild('autosize')
  autosize!: CdkTextareaAutosize;

  triggerResize() {
    this._ngZone.onStable.pipe(take(1))
      .subscribe(() => this.autosize.resizeToFitContent(true));
  }

  ngOnInit(): void {
    this.requestJobFormgroup = this._formBuilder.group({
      jobType:["",],
      jobTitle:["", Validators.required],
      price:["", Validators.required],
      description:[""],
    });
  }
  getIsNegociableValue(event: any){
    console.log(event.value);
    if(event.value == "1"){
      this.isPriceNegociable = true;
      console.log(this.isPriceNegociable);
    }else{
      this.isPriceNegociable = false;
      console.log(this.isPriceNegociable);
    }
  }
  requestJob() {
    var job = {
      jobTitle: this.requestJobFormgroup.value.jobTitle,
      jobCategory: this.requestJobFormgroup.value.jobType,
      price: this.requestJobFormgroup.value.price,
      isPriceNegociable: this.isPriceNegociable,
      description: this.requestJobFormgroup.value.description
    }

    this.jobService.requestJob(job).subscribe(_=> {
      this.snackBar.open('Job created succesfully', '', { duration: 2000 });
    })
  }
}
