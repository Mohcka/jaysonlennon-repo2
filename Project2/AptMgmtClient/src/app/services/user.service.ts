import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { User } from '../model/user';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ApiBase } from './../../ApiBase';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  private readonly apiUrl = ApiBase.url() + 'User'; // API + endpoint

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  public getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl)
      .pipe(
        catchError(handleError<User[]>('user.service(getUsers)', []))
      );
  }

  public getUser(id: number): Observable<User> {
    return this.http.get<User>(this.apiUrl + `/${id}`)
      .pipe(
        catchError(handleError<null>('user.service(getUser)'))
      );
  }

  public updateUser(user: User): Observable<User> {
    return this.http.post<User>(this.apiUrl, user, this.httpOptions)
      .pipe(
        // catchError(handleError<User>('user.service(updateUser)'))
      );
  }

}
