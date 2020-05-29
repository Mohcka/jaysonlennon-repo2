import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { Injectable } from '@angular/core';

@Injectable()
export class ApiTokenInterceptor implements HttpInterceptor {
  constructor(private authenticationService: AuthenticationService) {}

  public intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Add auth header with api token if available
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser && currentUser.apiKey) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.apiKey}`,
          'X-Api-Key': currentUser.apiKey,
        },
      });
    }

    return next.handle(request);
  }
}
