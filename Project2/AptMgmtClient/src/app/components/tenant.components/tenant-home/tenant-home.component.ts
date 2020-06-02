import { TenantBillsService } from '../../../services/tenant-home.service';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../model/user';
import { Resource } from 'src/enums/Resource';
import { Bill } from 'src/app/model/bill';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { BillService } from 'src/app/services/bill.service';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { Agreement } from 'src/app/model/agreement';
import { AgreementService } from 'src/app/services/agreement.service';
import { MaintenanceRequest } from 'src/app/model/maintenance-request';

@Component({
  selector: 'app-home',
  templateUrl: './tenant-home.component.html',
})
export class TenantHomeComponent implements OnInit {
  public users: User[] = [];
  public bills: Bill[];
  public maintenanceRequests: MaintenanceRequest[];
  public agreements: Agreement[];

  constructor(
    private userService: UserService,
    private tenantHomeService: TenantBillsService,
    private billService: BillService,
    private maintenanceService: MaintenanceService,
    private agreementService: AgreementService,
    public authService: AuthenticationService
  ) {}

  public ngOnInit() {
    this.getUsers();
    this.getHomeData();
    this.getTenantMaintenanceRequests();
    this.getTenantAgreements();
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

  getTenantAgreements(): void {
    this.agreementService.get().subscribe((data) => (this.agreements = data));
  }

  public cancelTenantRequest(): void {}

  public payBill(
    resource: Resource,
    billingPeriodId: number,
    amount: number
  ): void {
    this.billService
      .payBill({
        // Signed in user should be tenant
        tenantId: this.authService.currentUserValue.userId,
        resource: resource,
        billingPeriodId: billingPeriodId,
        amount: amount,
      })
      .subscribe((_) => this.getHomeData());
  }
}
