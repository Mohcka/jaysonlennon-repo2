import { TenantHomeService } from './../../services/tenant-home.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../model/user';
import { TenantHome } from 'src/app/model/tenant-home';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public users: User[] = [];
  public homeInfo: TenantHome;

  constructor(
    private userService: UserService,
    private tenantHomeService: TenantHomeService,
    ) {}

  public ngOnInit() {
    this.getUsers();
    this.getHomeData();
  }

  public getHomeData() {
    this.tenantHomeService.get().subscribe(data => this.homeInfo = data);
  }

  public getUsers(): void {
    this.userService.getUsers().subscribe((users) => (this.users = users));
  }
}
