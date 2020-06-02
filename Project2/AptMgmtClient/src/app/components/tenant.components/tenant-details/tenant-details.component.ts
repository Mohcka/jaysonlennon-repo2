import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tenant-details',
  templateUrl: './tenant-details.component.html',
  styleUrls: ['./tenant-details.component.css'],
})
export class TenantDetailsComponent implements OnInit {
  public targetTenant: Tenant = undefined;
  constructor(
    private tenantService: TenantService,
    private route: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit() {
    this.getTenant();
  }

  public getTenant(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.tenantService
      .getTenantById(id)
      .subscribe((tenant) => (this.targetTenant = tenant));
  }
}
