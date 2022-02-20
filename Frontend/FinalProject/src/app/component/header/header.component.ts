import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  updateUserFormGroup!: FormGroup;
  showFiller = false;
  isAdminUser = environment.isUserAdmin;
  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  goTest(){
    this.router.navigate(["test"]);
  }
}
