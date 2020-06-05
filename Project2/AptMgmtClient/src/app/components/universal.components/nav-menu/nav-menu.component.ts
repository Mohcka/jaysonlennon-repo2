import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { User } from 'src/app/model/user';
import { UserAccountType } from 'src/enums/user-account-type';

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

    // console.log(`Is Manager ${this.currentUser.userAccountType}`);
  }

  ngOnInit() {}

  get isManager(): boolean {
    return (
      this.currentUser &&
      Number(this.currentUser.userAccountType) === UserAccountType.Manager
    );
  }

  get isTenant(): boolean {
    return (
      this.currentUser &&
      this.currentUser.userAccountType === UserAccountType.Tenant
    );
  }

  leaseAgreementsPage(): string {
    return `${this.authenticationService.getHomeRoute()}/agreement/list`;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  goHome() {
    this.router.navigate([this.authenticationService.getHomeRoute()]);
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
