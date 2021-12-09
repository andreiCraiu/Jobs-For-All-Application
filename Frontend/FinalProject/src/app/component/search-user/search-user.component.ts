import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { CurrentUser } from 'src/app/model/currentUser';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.scss']
})
export class SearchUserComponent implements OnInit {
  public users!: CurrentUser[];
  public selectedUser!: CurrentUser;
  public displayedColumns: string[] = ['UserName', 'Email', 'Role', 'UserProfile', 'ContactPeople'];

  constructor(
    private userService: UserService,
    private router: Router,
  ) { }

  ngOnInit(): void {
  }
  
  goToUserPage(id:string){
    console.log("id is "+id);
    this.router.navigate(["search-user-profile",{userId: id}]);
  }

  contactPeople(id:string){
    console.log("id is "+id);
    this.router.navigate(["chat",{userId: id}]);
  }
  searchUSer(event:any){
    this.userService.getFilteredUsers(event.target.value).subscribe(users => {
      this.users = users;
    })
  }
}
