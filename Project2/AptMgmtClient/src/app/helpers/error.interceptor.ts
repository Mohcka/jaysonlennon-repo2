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
        if ([401, 403].indexOf(err.status) !== -1) {
          // auto logout if route was unauthorized or forbidden
          this.authtenticationService.logout();
          location.reload();
        }

        const error = err.error
          ? err.error.message
          : 'An error has occured' || err.statusTest;
        // tslint:disable-next-line: curly
        if (process.env.NODE_ENV === 'development') console.error(err);
        return throwError(error);
      })
    );
  }
}
