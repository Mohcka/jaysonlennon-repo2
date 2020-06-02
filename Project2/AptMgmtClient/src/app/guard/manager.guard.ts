/**
 * Implementation taken from:
 * https://jasonwatmore.com/post/2018/11/22/angular-7-role-based-authorization-tutorial-with-example#auth-guard-ts
 */
import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { UserAccountType } from 'src/enums/user-account-type';

/**
 * The auth guard is an angular route guard that's used to
 * prevent unauthorized users from accessing restricted routes
 */
@Injectable({ providedIn: 'root' })
export class ManagerGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) { }

  canActivate(_: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser) {
      if (Number(currentUser.userAccountType) === UserAccountType.Manager
        || Number(currentUser.userAccountType) === UserAccountType.Admin
      ) {
        return true;
      } else {
        this.router.navigate(['/']);
        return false;
      }
    } else {
      // not logged in, redirect to login page
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
  }
}
