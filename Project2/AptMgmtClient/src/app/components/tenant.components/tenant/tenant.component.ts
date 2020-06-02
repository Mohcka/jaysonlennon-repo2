import { Component, OnInit } from '@angular/core';
import { Tenant } from 'src/app/model/tenant';
import { TenantService } from 'src/app/services/tenant.service';
import { Resource } from 'src/enums/Resource';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  templateUrl: './tenant.component.html',
  styleUrls: ['./tenant.component.css'],
})
export class TenantComponent implements OnInit {
  tenant: Tenant;
  dueDate: Date = new Date();
  amountDue = 1500;
  constructor(
    public tenantService: TenantService,
    public authServie: AuthenticationService
  ) {}

  ngOnInit(): void {}

  // TODO: get tenant details from service
  getTenantDetails(): void {}

  registerPayment() {
    this.tenantService
      .registerPayment(1, {
        tenantId: this.authServie.currentUserValue.id,
        resource: 0,
        billingPeriodId: Resource.Internet,
        amount: this.amountDue,
      })
      .subscribe((_) => (this.amountDue = 0));
  }
}
