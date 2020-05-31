import { Component, OnInit } from '@angular/core';
import { Tenant } from 'src/app/model/tenant';

@Component({
  templateUrl: './tenant.component.html',
  styleUrls: ['./tenant.component.css'],
})
export class TenantComponent implements OnInit {
  tenant: Tenant;
  dueDate: Date = new Date();
  constructor() {}

  ngOnInit(): void {}

  // TODO: get tenant details from service
  getTenantDetails(): void {}

  registerPayment() {
    console.log('payment made');
  }
}
