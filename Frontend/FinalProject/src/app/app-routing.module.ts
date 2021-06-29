import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './component/authentication/register/register.component';
import { SigninComponent } from './component/authentication/signin/signin.component';
import { HeaderComponent } from './component/header/header.component';
import { AuthenticationGuard } from './guards/authentication.guard';

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path:'', component: SigninComponent},
  {path:'header', component: HeaderComponent, canActivate: [AuthenticationGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
