import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './component/authentication/register/register.component';
import { SigninComponent } from './component/authentication/signin/signin.component';
import { HeaderComponent } from './component/header/header.component';
import { MainPageComponent } from './component/main-page/main-page.component';
import { SetupRoleComponent } from './component/setup-role/setup-role.component';
import { AuthenticationGuard } from './guards/authentication.guard';

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path:'', component: SigninComponent},
  {path:'setup-role', component:SetupRoleComponent},
  {path:'main-page', component: MainPageComponent},
  {path:'header', component: HeaderComponent, canActivate: [AuthenticationGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
