import { Component, OnInit } from '@angular/core';
import { JobsService } from 'src/app/service/jobs.service';
import { Jobs } from 'src/app/model/job';

@Component({
  selector: 'app-view-jobs',
  templateUrl: './view-jobs.component.html',
  styleUrls: ['./view-jobs.component.scss']
})
export class ViewJobsComponent implements OnInit {
 public jobs!: Jobs[];

  constructor(
    private jobsService: JobsService,
  ){}

  ngOnInit(): void {
    this.jobsService.getJobs().add((jobs: Jobs[]) => this.jobs = jobs);
  }

}
