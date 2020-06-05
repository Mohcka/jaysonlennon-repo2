import { Component, OnInit } from '@angular/core';
import { Agreement } from 'src/app/model/agreement';
import { AgreementService } from 'src/app/services/agreement.service';
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';

@Component({
  selector: 'app-manager-page-list-agreements',
  templateUrl: './manager-page-list-agreements.component.html',
})
export class ManagerPageListAgreementsComponent implements OnInit {

  public agreements: Agreement[];
  tenants: Tenant[];

  constructor(private agreementService: AgreementService,
              private tenantService: TenantService) { }

  ngOnInit(): void {
    this.getTenants();
    this.getAgreements();
  }

  getTenants(): void {
    this.tenantService.getTenants().subscribe(tenants => this.tenants = tenants);
  }

  getTenantNameFromId(id: number): string {
     const target = this.tenants.find(t => t.tenantId === id);
     return `${target.lastName}, ${target.firstName}`;
  }

  getAgreements(): void {
    this.agreementService.getAgreements().subscribe(agreements => {
      this.agreements = agreements;
      this.agreements.sort((a, b) => a.tenantId - b.tenantId);
    });
  }

  signAgreement(agreement: Agreement): void {
    console.log(new Date().toISOString());
    this.agreementService
      .signAgreement({
        ...agreement,
        signedDate: new Date().toISOString(),
      })
      .toPromise()
      .then(
        (_) => this.getAgreements(),
        (err) => console.error(err)
      );
  }
}
