import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HTTP_INTERCEPTORS,
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { mergeMap } from 'rxjs/operators';

import { User } from '../model/user';
import * as mockUsers from 'api/mock-users.json';
import { UserAccountType } from '../model/user-account-type';
import { Injectable } from '@angular/core';

@Injectable()
export class FakeAuthBackendInterceptor implements HttpInterceptor {
  public intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const users: User[] = mockUsers.users;

    const authHeader = request.headers.get('X-Api-Key');
    const isLoggedIn = authHeader && authHeader.startsWith('api-key');
    const roleString = isLoggedIn && authHeader.split('.')[1];
    const role = roleString ? UserAccountType[roleString] : null;

    if (request.url.endsWith('/login')) {
      return of(null).pipe(
        mergeMap(() => {
          // Authenticate
          if (request.url.endsWith('/login') && request.method === 'POST') {
            const user = users.find(
              (u) =>
                u.loginName === request.body.loginName &&
                u.password === request.body.password
            );

            console.log(request.body);

            if (!user) {
              return error('Username or password is incorrect');
            }

            return ok({
              id: user.id,
              loginName: user.loginName,
              userAccountType: user.userAccountType,
              apiKey: `api-key${user.userAccountType}`,
            });
          }
        })
      );

      function ok(body) {
        return of(new HttpResponse({ status: 200, body }));
      }

      function unauthorised() {
        return throwError({ status: 401, error: { message: 'Unauthorised' } });
      }

      function error(message) {
        return throwError({ status: 400, error: { message } });
      }
    } else {
      return next.handle(request);
    }
  }
}

export const fakeAuthBackendProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: FakeAuthBackendInterceptor,
  multi: true,
};
