import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-job-requests',
  templateUrl: './job-requests.component.html',
  styleUrls: ['./job-requests.component.scss']
})

export class JobRequestsComponent implements OnInit {
  isShowMoreActive = true;
  isRequestJob = true;
  constructor() { }

  ngOnInit(): void {
  }

}
