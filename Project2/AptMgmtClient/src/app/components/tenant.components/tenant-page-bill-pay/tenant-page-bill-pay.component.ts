import { ResourceUsageService } from './../../../services/resource-usage.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { BillService } from 'src/app/services/bill.service';
import { Component, OnInit } from '@angular/core';
import { Bill } from 'src/app/model/bill';
import { Resource } from 'src/enums/Resource';
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';
import { ResourceUsageProjection } from 'src/app/model/resource-usage-projection';
import { MeteredResouceUsageEntry } from 'src/app/model/metered-resource-usage-entry';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-tenant-page-bill-pay',
  templateUrl: './tenant-page-bill-pay.component.html',
  styleUrls: ['./tenant-page-bill-pay.component.css']
})
export class TenantPageBillPayComponent implements OnInit {
  public bill: Bill;
  public tenant: Tenant;

  usageSummary: ResourceUsageProjection;
  usageData: MeteredResouceUsageEntry[];
  unitName: string;
  hasDetails = false;
  error: string = '';

  constructor(private billService: BillService,
              private tenantService: TenantService,
              private activatedRoute: ActivatedRoute,
              private resourceUsageService: ResourceUsageService) { }

  ngOnInit(): void {
    this.getBill();
    this.getTenant();
  }

  getUsageData() {
    this.resourceUsageService.getUsageEntriesForResource(this.bill.resource)
    .subscribe(data => this.usageData = data);
  }

  getSummaryData() {
    this.resourceUsageService.getProjectionForResource(this.bill.resource)
      .subscribe(summary => this.usageSummary = summary);
  }

  configureUnitName() {
    switch (this.bill.resource) {
      case Resource.Power: this.unitName = 'kWh'; break;
      case Resource.Water: this.unitName = 'cu.ft.'; break;
      default: this.unitName = '';
    }
  }


  getBill(): void {
    const billingPeriod = this.activatedRoute.snapshot.paramMap.get('periodId');
    const resourceTypeId = this.activatedRoute.snapshot.paramMap.get('resourceTypeId');
    if (Number(resourceTypeId) === 0 || Number(resourceTypeId) === 1) { this.hasDetails = true; }
    this.billService
      .getBillsInPeriod(Number(billingPeriod))
      .subscribe(bills => {
        this.bill = bills.filter(b => b.resource === Number(resourceTypeId)).pop();
        this.configureUnitName();
        this.getSummaryData();
        this.getUsageData();
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
