import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderComponent } from './component/header/header.component';
import {MatTabsModule} from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SigninComponent } from './component/authentication/signin/signin.component';
import { RegisterComponent } from './component/authentication/register/register.component';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpAuthInterceptor } from './interceptors/authorise.interceptor';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { StorageService } from './service/storage.service';
import { OverlayModule } from '@angular/cdk/overlay';
import { MainPageComponent } from './component/main-page/main-page.component';
import { SetupRoleComponent } from './component/setup-role/setup-role.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatRadioModule} from '@angular/material/radio';
import { FlexLayoutModule } from "@angular/flex-layout";
import {MatStepperModule} from '@angular/material/stepper';
import {MatSelectModule} from '@angular/material/select';
import {MatIconModule} from '@angular/material/icon';
import { UserProfileComponent } from './component/user-profile/user-profile.component';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { IgxAvatarModule } from 'igniteui-angular';
import { UpdateUserProfileComponent } from './component/update-user-profile/update-user-profile.component';
import { UpdateUserAccountComponent } from './component/update-user-account/update-user-account.component';
import { JobRequestsComponent } from './component/job-requests/job-requests.component';
import { ViewJobsComponent } from './component/view-jobs/view-jobs.component';
import { RequestJobComponent } from './component/request-job/request-job.component';
import {TextFieldModule} from '@angular/cdk/text-field';
import {MatTableModule} from '@angular/material/table';
import { ExternalUserProfileComponent } from './component/external-user-profile/external-user-profile.component';
import { RatingStarComponent } from './component/rating-star/rating-star.component';
import { ChatMessageComponent } from './component/chat-message/chat-message.component';
import { SearchUserComponent } from './component/search-user/search-user.component';
import {MatListModule} from '@angular/material/list';
import { PickerModule } from '@ctrl/ngx-emoji-mart';
import { TestComponent } from './component/test/test.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatPaginatorModule} from '@angular/material/paginator';
import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';
import {CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { TableSkeletonComponent } from './component/table-skeleton/table-skeleton.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SigninComponent,
    RegisterComponent,
    MainPageComponent,
    SetupRoleComponent,
    UserProfileComponent,
    UpdateUserProfileComponent,
    UpdateUserAccountComponent,
    JobRequestsComponent,
    ViewJobsComponent,
    RequestJobComponent,
    ExternalUserProfileComponent,
    RatingStarComponent,
    ChatMessageComponent,
    SearchUserComponent,
    TestComponent,
    TableSkeletonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    OverlayModule,
    FlexLayoutModule,
    MatCheckboxModule,
    MatRadioModule,
    MatStepperModule,
    MatSelectModule,
    MatIconModule,
    CommonModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatButtonToggleModule,
    IgxAvatarModule,
    TextFieldModule,
    MatTableModule,
    PickerModule,
    MatToolbarModule,
    MatButtonModule,
    MatPaginatorModule,
    NgxSkeletonLoaderModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS, useClass: HttpAuthInterceptor, multi: true},
    StorageService,
    SearchUserComponent,
    MatSnackBar,
    MatSnackBarModule,
    
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
 {
   
}
