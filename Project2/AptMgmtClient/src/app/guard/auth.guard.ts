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
    // Check if the current route is restricted
    if (currentUser) {
      if (
        route.data.userAccountTypes &&
        route.data.userAccountTypes.indexOf(currentUser.userAccountType) === -1
      ) {
        // route not authorized, redicrecting to home page
        this.router.navigate(['/']);
        return false;
      }

      // authorization cleared
      return true;
    }

    // not logged in, redirect to login page
    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
