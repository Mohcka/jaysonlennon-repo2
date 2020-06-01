/**
 * Implementation taken from:
 * https://jasonwatmore.com/post/2018/11/22/angular-7-role-based-authorization-tutorial-with-example#authentication-service-ts
 */

import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { User } from '../model/user';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { ApiBase } from './../../ApiBase';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  /**
   * User that has been saved in localstorage
   */
  private currentUserSubject: BehaviorSubject<User>;
  /**
   * Currnetly logged user
   */
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    // Find user in local storage if they've already been logged in
    this.currentUserSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem('currentUser'))
    );
    // Set currentUser as an observable for when we need to subscribe to the user's data later
    this.currentUser = this.currentUserSubject.asObservable();
  }

  // TODO: update description later
  /**
   * "The currentUserValue property can be used when you just want to get the current
   * value of the logged in user but don't need to reactively update when it changes,"
   */
  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  /**
   * Processes a login requst to the server using the username and password
   * from user input
   * @param loginName The username recieved from input
   * @param password The password recieved from input
   */
  public login(loginName: string, password: string): Observable<User> {
    // TODO: provide a more defined type than `any`
    const info = {
      UserName: loginName,
      Password: password,
    };
    return this.http
      .post<any>(ApiBase.url() + `Login`, info)
      .pipe(
        map((user: User) => {
          // Login is successful if the api key was returned!
          if (user && user.apiKey) {
            // store user details and api key in local storage so logged in state persists
            // between refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
          }
          return user;
        })
      );
  }

  /**
   * Logs user out
   */
  public logout(): void {
    // remove user from local storage resulting in a logout
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
