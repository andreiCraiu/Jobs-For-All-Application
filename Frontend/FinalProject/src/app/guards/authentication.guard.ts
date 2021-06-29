import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { StorageService } from '../service/storage.service';

@Injectable()
export class AuthenticationGuard implements CanActivate {

    constructor(private router: Router, private storageService: StorageService) { }

    canActivate() {
        if (!this.storageService.getLoggedInUser()) {
            this.router.navigate(['']);
            return false;
        }

        return true;
    }
}