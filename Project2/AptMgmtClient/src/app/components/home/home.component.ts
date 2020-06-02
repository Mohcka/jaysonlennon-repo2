import { TenantHomeService } from './../../services/tenant-home.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../model/user';
import { TenantHome } from 'src/app/model/tenant-home';
import { Resource } from 'src/types/Resource';
import { PayBillData } from 'src/app/model/pay-bill-data';
import { TenantService } from 'src/app/services/tenant.service';

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
    private tenantService: TenantService
  ) {}

  public ngOnInit() {
    this.getUsers();
    this.getHomeData();
  }

  public getHomeData() {
    this.tenantHomeService.get().subscribe((data) => (this.homeInfo = data));
  }

  public getUsers(): void {
    this.userService.getUsers().subscribe((users) => (this.users = users));
  }

  public payBill(
    resource: Resource,
    billingPeriodId: number,
    amount: number
  ): void {
    this.tenantService
      .payBill({
        resource: resource,
        billingPeriodId: billingPeriodId,
        amount: amount,
      })
      .subscribe((_) => this.getHomeData());
  }
}
