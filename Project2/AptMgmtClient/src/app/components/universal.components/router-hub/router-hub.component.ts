import { AuthenticationService } from 'src/app/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/user';

@Component({
  selector: 'app-router-hub',
  templateUrl: './router-hub.component.html',
})
export class RouterHubComponent implements OnInit {

  currentUser: User;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(
      (u) => (this.currentUser = u)
    );
  }

  logout() {
    this.authenticationService.logout();
  }
}
