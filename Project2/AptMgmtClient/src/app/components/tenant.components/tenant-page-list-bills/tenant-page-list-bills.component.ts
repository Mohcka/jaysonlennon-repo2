import { BillService } from 'src/app/services/bill.service';
import { Component, OnInit } from '@angular/core';
import { Bill } from 'src/app/model/bill';
import { Resource } from 'src/enums/Resource';
import { PayBillData } from 'src/app/model/pay-bill-data';
import { Tenant } from 'src/app/model/tenant';
import { TenantService } from 'src/app/services/tenant.service';

@Component({
  selector: 'app-tenant-page-list-bills',
  templateUrl: './tenant-page-list-bills.component.html',
})
export class TenantPageListBillsComponent implements OnInit {

  public unpaidBills: Bill[];
  public paidBills: Bill[];
  public tenant: Tenant;

  constructor(private billService: BillService,
              private tenantService: TenantService) {}

  ngOnInit(): void {
    this.getBillsThisPeriod();
  }

  getBillsThisPeriod(): void {
    this.billService.getBillsInCurrentPeriod().subscribe((bills) => {
      this.unpaidBills = bills.filter(bill => bill.owed > 0);
      this.paidBills = bills.filter(bill => bill.owed <= 0);
    });
  }

  public payBill(
    resource: Resource,
    billingPeriodId: number,
    amount: number
  ): void {
    const payBillInfo: PayBillData = {
      tenantId: this.tenant.tenantId,
      resource: resource,
      billingPeriodId: billingPeriodId,
      amount: amount,
    };
    this.billService.payBill(payBillInfo).subscribe((_) => this.getBillsThisPeriod());
  }

}
