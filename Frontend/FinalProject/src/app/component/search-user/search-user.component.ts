import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { CurrentUser } from 'src/app/model/currentUser';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.scss'],
})
export class SearchUserComponent implements OnInit {
  public users: CurrentUser[];
  public selectedUser: CurrentUser;
  public displayedColumns: string[] = [
    'UserName',
    'Email',
    'Role',
    'UserProfile',
    'ContactPeople',
  ];
  public length = 20;
  pageSize: any = 10;
  pageSizeOptions: number[] = [1, 2, 5, 10, 25, 100];

  // MatPaginator Output
  pageEvent: PageEvent;

  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput
        .split(',')
        .map((str) => +str);
        this.pageSize = setPageSizeOptionsInput;
    }
  }

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  goToUserPage(id: string) {
    console.log('id is ' + id);
    this.router.navigate(['search-user-profile', { userId: id }]);
  }

  contactPeople(id: string) {
    console.log('id is ' + id);
    this.router.navigate(['chat', { userId: id }]);
  }
  searchUSer(event: any) {
    if (event.target.value == '') {
      this.getAllUsers();
    }
    this.userService.getFilteredUsers(event.target.value).subscribe((users) => {
      this.users = users;
      console.log('len', this.users.length);
      this.length = this.users.length;
    });
  }
  getAllUsers() {
    this.userService.getAllUsers().subscribe((users) => {
      this.users = users;
      this.length = this.users.length;
    });
  }
}
