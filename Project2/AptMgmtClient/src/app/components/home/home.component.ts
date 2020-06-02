import { TenantBillsService } from './../../services/tenant-home.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../model/user';
// import { TenantHome } from 'src/app/model/tenant-home';
import { Resource } from 'src/types/Resource';
import { PayBillData } from 'src/app/model/pay-bill-data';
import { TenantService } from 'src/app/services/tenant.service';
import { Bill } from 'src/app/model/bill';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { BillService } from 'src/app/services/bill.service';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { MaintenanceRequest } from 'src/app/model/maintenance';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public users: User[] = [];
  public bills: Bill[];
  public maintenanceRequests: MaintenanceRequest[];

  constructor(
    private userService: UserService,
    private tenantHomeService: TenantBillsService,
    private billService: BillService,
    private maintenanceService: MaintenanceService,
    public authService: AuthenticationService
  ) {}

  public ngOnInit() {
    this.getUsers();
    this.getHomeData();
    this.getTenantMaintenanceRequests();
  }

  public getHomeData() {
    this.tenantHomeService.get().subscribe((data) => (this.bills = data));
  }

  public getUsers(): void {
    this.userService.getUsers().subscribe((users) => (this.users = users));
  }

  public getTenantMaintenanceRequests(): void {
    this.maintenanceService
      .get()
      .subscribe((mR) => (this.maintenanceRequests = mR));
  }

  public cancelTenantRequest(): void {

  }

  public payBill(
    resource: Resource,
    billingPeriodId: number,
    amount: number
  ): void {
    this.billService
      .payBill({
        // Signed in user should be tenant
        tenantId: this.authService.currentUserValue.id,
        resource: resource,
        billingPeriodId: billingPeriodId,
        amount: amount,
      })
      .subscribe((_) => this.getHomeData());
  }
}
