import { UserAccountType } from './../../enums/user-account-type';
/**
 * Implementation taken from:
 * https://jasonwatmore.com/post/2020/05/15/angular-9-role-based-authorization-tutorial-with-example#auth-guard-ts
 */
import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

/**
 * The auth guard is an angular route guard that's used to
 * prevent unauthorized users from accessing restricted routes
 */
@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser) {
      if (route.data.roles.find((el: UserAccountType) => el === currentUser.userAccountType)) {
        // User is authorized.
        return true;
      } else {
        // User is not authorized.
        this.router.navigate(['403']);
        return false;
      }
    }

    // User is not logged in.
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
