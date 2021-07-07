import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  updateUserFormGroup!: FormGroup;
  showFiller = false;
  constructor() { }

  ngOnInit(): void {
  }

}
