import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { User } from 'src/app/model/user';
import { UserAccountType } from 'src/app/model/user-account-type';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  userLoggedIn = false;
  currentUser: User;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(
      (u) => (this.currentUser = u)
    );
  }

  ngOnInit() {}

  get isManager(): boolean {
    return (
      this.currentUser &&
      this.currentUser.userAccountType === UserAccountType.Manager
    );
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  /**
   * Logs user out and removes relative data from local storage
   */
  logout() {
    this.authenticationService.logout();
    // go back home
    this.router.navigate(['/']);
  }
}
