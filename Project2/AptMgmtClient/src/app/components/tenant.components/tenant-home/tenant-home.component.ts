import { PayBillData } from 'src/app/model/pay-bill-data';
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
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';

@Component({
  selector: 'app-home',
  templateUrl: './tenant-home.component.html',
})
export class TenantHomeComponent implements OnInit {
  public users: User[] = [];
  public openMaintenanceRequests: MaintenanceRequest[];
  public unsignedAgreements: Agreement[];
  public tenant: Tenant;
  public bills: Bill[];

  constructor(
    private userService: UserService,
    private maintenanceService: MaintenanceService,
    private agreementService: AgreementService,
    private tenantService: TenantService,
    private billService: BillService,
    public authService: AuthenticationService
  ) {}

  public ngOnInit() {
    this.getUsers();
    this.getTenantMaintenanceRequests();
    this.getUnsignedAgreements();
    this.getTenantInfo();
    this.getBills();
  }

  public getTenantInfo(): void {
    this.tenantService
      .getTenant()
      .subscribe((tenant) => (this.tenant = tenant));
  }

  public getUsers(): void {
    this.userService.getUsers().subscribe((users) => (this.users = users));
  }

  public getTenantMaintenanceRequests(): void {
    this.maintenanceService
      .getAll()
      .subscribe(
        (mR) =>
          (this.openMaintenanceRequests = mR.filter(
            (request) => request.closeReason === null
          ))
      );
  }

  getUnsignedAgreements(): void {
    this.agreementService
      .getAgreements()
      .subscribe(
        (data) =>
          (this.unsignedAgreements = data.filter(
            (agreement) => agreement.signedDate === null
          ))
      );
  }

  getBills(): void {
    this.billService
      .getUnpaidBills()
      .toPromise()
      .then((bills) => {
        this.bills = bills;
      });
  }

  public cancelTenantRequest(): void {}
}
