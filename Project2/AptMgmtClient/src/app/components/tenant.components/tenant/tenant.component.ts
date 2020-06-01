import { Component, OnInit } from '@angular/core';
import { Tenant } from 'src/app/model/tenant';
import { TenantService } from 'src/app/services/tenant.service';

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
      .registerPayment(1)
      .subscribe((_) => (this.amountDue = 0));
  }
}
