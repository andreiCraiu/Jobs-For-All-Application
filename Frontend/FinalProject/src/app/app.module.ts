import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './component/login/login.component';
import { HeaderComponent } from './component/header/header.component';
import {MatTabsModule} from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SigninComponent } from './component/authentication/signin/signin.component';
import { RegisterComponent } from './component/authentication/register/register.component';
import {MatCardModule} from '@angular/material/card';
import { MainPageComponent } from './component/main-page/main-page.component';
import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    SigninComponent,
    RegisterComponent,
    MainPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatCardModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
