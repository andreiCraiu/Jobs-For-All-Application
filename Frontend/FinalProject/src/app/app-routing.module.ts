import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './component/authentication/register/register.component';
import { SigninComponent } from './component/authentication/signin/signin.component';
import { ChatMessageComponent } from './component/chat-message/chat-message.component';
import { ExternalUserProfileComponent } from './component/external-user-profile/external-user-profile.component';
import { HeaderComponent } from './component/header/header.component';
import { MainPageComponent } from './component/main-page/main-page.component';
import { SetupRoleComponent } from './component/setup-role/setup-role.component';
import { UserProfileComponent } from './component/user-profile/user-profile.component';
import { AuthenticationGuard } from './guards/authentication.guard';
import {TestComponent} from "./component/test/test.component"

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path:'', component: SigninComponent},
  {path:'setup-role', component:SetupRoleComponent},
  {path:'main-page', component: MainPageComponent},
  {path:'user-profile', component: UserProfileComponent},
  //{path:'header', component: HeaderComponent, canActivate: [AuthenticationGuard]},
  {path:'header', component: HeaderComponent},
  {path:'chat', component: ChatMessageComponent},
  {path:'search-user-profile', component: ExternalUserProfileComponent},
  {path:'test', component: TestComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
