import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Job } from 'src/app/model/job';
import { JobsService } from 'src/app/service/jobs.service';

@Component({
  selector: 'app-view-jobs',
  templateUrl: './view-jobs.component.html',
  styleUrls: ['./view-jobs.component.scss'],
})
export class ViewJobsComponent implements OnInit {
  public jobs: Job[];
  public displayedColumns: string[] = [
    'jobTitle',
    'jobCategory',
    'price',
    'isPriceNegociable',
    'delete',
  ];
  public load = false;
  constructor(
    private jobsService: JobsService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.load = true;
    this.loadJobs();
  }
  loadJobs() {
    this.jobsService.getJobs().subscribe((jobs: Job[]) => {
      this.jobs = jobs;
      this.load = false
    });
  }
  
  removeJob(id: number) {
    this.jobsService.removeJob(id).subscribe((_) => {
      this.jobs = this.jobs.filter((x) => x.id != id);
      this.snackBar.open('Job deleted succesfully', '', { duration: 2000 });
    });
  }
}
