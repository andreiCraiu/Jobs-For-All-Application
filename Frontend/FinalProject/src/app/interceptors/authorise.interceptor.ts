import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { StorageService } from '../service/storage.service';

@Injectable()
export class HttpAuthInterceptor implements HttpInterceptor {

  constructor(private storageService: StorageService,
    private router: Router,
    private snackBar: MatSnackBar) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var jwtToken = this.storageService.getLoggedInUser() ? this.storageService.getLoggedInUser().jwtToken : '';
    console.log(jwtToken);
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${jwtToken}`
      }
    });;

    return next.handle(request);
  }
}