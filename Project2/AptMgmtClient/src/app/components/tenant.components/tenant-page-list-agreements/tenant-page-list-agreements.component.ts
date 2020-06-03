import { TenantService } from 'src/app/services/tenant.service';
import { AgreementService } from 'src/app/services/agreement.service';
import { Component, OnInit } from '@angular/core';
import { Agreement } from 'src/app/model/agreement';
import { Tenant } from 'src/app/model/tenant';

@Component({
  selector: 'app-tenant-page-list-agreements',
  templateUrl: './tenant-page-list-agreements.component.html',
  styleUrls: ['./tenant-page-list-agreements.component.css']
})
export class TenantPageListAgreementsComponent implements OnInit {

  public agreements: Agreement[];
  public tenant: Tenant;

  constructor(private agreementService: AgreementService,
              private tenantService: TenantService) { }

  ngOnInit(): void {
    this.getTenant();
    this.getAgreements();
  }

  getTenant(): void {
    this.tenantService.getTenant().subscribe(tenant => this.tenant = tenant);
  }

  getAgreements(): void {
    this.agreementService.getAgreements().subscribe(agreements => this.agreements = agreements);
  }

}
