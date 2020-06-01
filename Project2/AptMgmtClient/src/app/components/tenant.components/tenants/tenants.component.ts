import { Component, OnInit } from '@angular/core';
import { TenantService } from '../../../services/tenant.service';
import { Tenant } from '../../../model/tenant';

@Component({
  selector: 'app-tenants',
  templateUrl: './tenants.component.html',
  styleUrls: ['./tenants.component.css'],
})
export class TenantsComponent implements OnInit {
  /**
   * Tenant data to be presented to the user
   */
  public tenants: Tenant[] = [];

  constructor(private tenantService: TenantService) {}

  ngOnInit() {
    this.getTenants();
  }

  public getTenants(): void {
    this.tenantService
      .getAll()
      .subscribe((tenants) => (this.tenants = tenants));
  }
}
