import { ActivatedRoute, RouterModule } from '@angular/router';
import { BillService } from 'src/app/services/bill.service';
import { Component, OnInit } from '@angular/core';
import { Bill } from 'src/app/model/bill';
import { Resource } from 'src/enums/Resource';
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-tenant-page-bill-pay',
  templateUrl: './tenant-page-bill-pay.component.html',
  styleUrls: ['./tenant-page-bill-pay.component.css']
})
export class TenantPageBillPayComponent implements OnInit {
  public bill: Bill;
  public tenant: Tenant;

  public error = '';

  constructor(private billService: BillService,
              private tenantService: TenantService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getBill();
    this.getTenant();
  }

  getBill(): void {
    const billingPeriod = this.activatedRoute.snapshot.paramMap.get('periodId');
    const resourceTypeId = this.activatedRoute.snapshot.paramMap.get('resourceTypeId');
    this.billService
      .getBillsInPeriod(Number(billingPeriod))
      .subscribe(bills => {
        this.bill = bills.filter(b => b.resource === Number(resourceTypeId)).pop();
      });

  }

  getTenant(): void {
    this.tenantService.getTenant().subscribe(tenant => this.tenant = tenant);
  }

  public payBill(
    resource: Resource,
    billingPeriodId: number,
    amount: number
  ): void {
    this.billService
      .payBill({
        tenantId: this.tenant.tenantId,
        resource: resource,
        billingPeriodId: billingPeriodId,
        amount: amount,
      })
      .subscribe((_) => this.getBill(), (error: HttpErrorResponse) => {
        this.error =
          error.error && error.error.message
            ? error.error.message
            : JSON.stringify(error);
      });
  }

}
