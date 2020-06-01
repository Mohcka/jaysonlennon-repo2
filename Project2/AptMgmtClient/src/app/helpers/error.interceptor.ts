/**
 * Implementation taken from:
 * https://jasonwatmore.com/post/2018/11/22/angular-7-role-based-authorization-tutorial-with-example#error-interceptor-ts
 */
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { AuthenticationService } from '../services/authentication.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authtenticationService: AuthenticationService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        // This is not good UX. User may accidentally click an
        // unauthorized link, and this doesn't stop attackers.
        // if ([401, 403].indexOf(err.status) !== -1) {
        //   // auto logout if route was unauthorized or forbidden
        //   this.authtenticationService.logout();
        //   location.reload();
        // }

        // No reason to discard useful error information. Attackers
        // can still get source error info by monitoring network requests.
        // const error = err.error
        //   ? err.error.message
        //   : 'An error has occured' || err.statusTest;
        // console.log(err);
        return throwError(err);
      })
    );
  }
}
