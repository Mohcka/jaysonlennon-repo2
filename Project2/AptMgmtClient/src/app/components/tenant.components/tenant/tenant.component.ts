import { Component, OnInit } from '@angular/core';
import { Tenant } from 'src/app/model/tenant';
import { TenantService } from 'src/app/services/tenant.service';
import { Resource } from 'src/types/Resource';

@Component({
  templateUrl: './tenant.component.html',
  styleUrls: ['./tenant.component.css'],
})
export class TenantComponent implements OnInit {
  tenant: Tenant;
  dueDate: Date = new Date();
  amountDue = 1500;
  constructor(public tenantService: TenantService) {}

  ngOnInit(): void {}

  // TODO: get tenant details from service
  getTenantDetails(): void {}

  registerPayment() {
    this.tenantService
      .registerPayment(1, {
        resource: 0,
        billingPeriodId: Resource.Internet,
        amount: this.amountDue,
      })
      .subscribe((_) => (this.amountDue = 0));
  }
}
