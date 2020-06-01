import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { User } from '../model/user';
import * as USERS from 'api/mock-users.json';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { ApiBase } from './../../ApiBase';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  /**
   * The base url for making api requests for users resources
   */
  private readonly usersUrl = ApiBase.url() + 'users';

  constructor(private http: HttpClient) {}

  /**
   * Requests to fetch all the users from the api
   */
  public getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.usersUrl)
      .pipe(
        catchError(handleError<User[]>('getUsers', []))
      );
  }

}
