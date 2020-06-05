import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-app-index',
  templateUrl: './app-index.component.html',
  styleUrls: ['./app-index.component.css']
})
export class AppIndexComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService,
              private router: Router) { }

  ngOnInit(): void {
    this.router.navigate([this.authenticationService.getHomeRoute()]);
  }

}
