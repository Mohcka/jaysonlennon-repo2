import { TenantHomeService } from './../../services/tenant-home.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../model/user';
import { Bill } from 'src/app/model/bill';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public users: User[] = [];
  public bills: Bill[];

  constructor(
    private userService: UserService,
    private tenantHomeService: TenantHomeService,
    ) {}

  public ngOnInit() {
    this.getUsers();
    this.getHomeData();
  }

  public getHomeData() {
    this.tenantHomeService.get().subscribe(data => this.bills = data);
  }

  public getUsers(): void {
    this.userService.getUsers().subscribe((users) => (this.users = users));
  }
}
