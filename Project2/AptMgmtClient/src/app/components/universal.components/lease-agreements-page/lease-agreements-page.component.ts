import { Component, OnInit } from '@angular/core';
import { AgreementService } from 'src/app/services/agreement.service';
import { Agreement } from 'src/app/model/agreement';

@Component({
  selector: 'app-lease-agreements-page',
  templateUrl: './lease-agreements-page.component.html',
  styleUrls: ['./lease-agreements-page.component.css'],
})
export class LeaseAgreementsOageComponent implements OnInit {
  agreements: Agreement[];
  constructor(private agreementService: AgreementService) {}

  ngOnInit(): void {
    this.getAgreements();
  }

  getAgreements(): void {
    this.agreementService
      .getAgreements()
      .toPromise()
      .then((agreements) => {
        this.agreements = agreements.sort((a, b) => {
          if (a.agreementId < b.agreementId) {
            return -1;
          }
          if (a.agreementId > b.agreementId) {
            return 1;
          }
          return 0;
        });
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
