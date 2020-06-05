import { Component, OnInit } from '@angular/core';
import { TenantService } from '../../../services/tenant.service';
import { Tenant } from '../../../model/tenant';

@Component({
  selector: 'app-tenants',
  templateUrl: './manager-list-tenants.component.html',
})
export class ManagerListTenantsComponent implements OnInit {
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
      .getTenants()
      .subscribe((tenants) => (this.tenants = tenants));
  }
}
