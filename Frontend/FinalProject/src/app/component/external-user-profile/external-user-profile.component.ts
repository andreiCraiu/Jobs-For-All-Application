import { stringify } from '@angular/compiler/src/util';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { getOrCreateElementRef } from '@angular/core/src/render3/di';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from 'src/app/enums/role';
import { CurrentUser } from 'src/app/model/currentUser';
import { UserComment } from 'src/app/model/userComment';
import { CommentService } from 'src/app/service/comment.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-external-user-profile',
  templateUrl: './external-user-profile.component.html',
  styleUrls: ['./external-user-profile.component.scss']
})

export class ExternalUserProfileComponent implements OnInit {
  isChatVisible = false;
  id: any;
  selctedUser!: CurrentUser;
  email!: string;
  address!: string;
  profession!: string;
  description!: string;
  userName!: string;
  role!: string;
  jobsFinished!: number;
  rating!: number;
  contentForCommentToBeSent!: string;
  commentUserName = "ANDREI CRAIU";
  commentContent = "goood";

  comments!: UserComment[];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private commentSerice: CommentService
  ) {

  }

  ngOnInit(): void {
    window.scrollTo(0,document.body.scrollHeight);
    this.route.paramMap.subscribe(param => {
      this.id = param.get("userId");
      console.log(this.id);
    })

    this.commentSerice.getComments(this.id).subscribe(result =>{
      this.comments = result
      console.log(result);
    });
  
    this.userService.getUser(this.id).subscribe(user => {
      this.profession = user.profession;
      this.email = user.email;
      this.address = user.address;
      this.description = user.details;
      this.role = this.getCurrentRole(user.role);
      this.userName = user.userName;
      this.rating = user.rating;

      if(user.jobsFinished < 1){
        this.jobsFinished = 0;
      }else{
        this.jobsFinished = user.jobsFinished;
      }
    });
    
  };

  getCurrentRole(role: number){
    switch(role){
      case 1:
        return Role.ADMIN
      case 2:
        return Role.JOB_REQUESTER
      case 3: 
       return Role.JOB_FINDER
      case 4: 
       return Role.REQESTER_FINDER
      default:
        return ""
    }
  }

  addComment(){
    var comment = {
      body: this.contentForCommentToBeSent
    };
    this.commentSerice.addComment(comment, this.id).subscribe(_ =>{
      window.location.reload();
      window.scrollTo(0,document.body.scrollHeight);
    });
  }
}
