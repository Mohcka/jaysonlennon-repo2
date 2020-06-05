import { AgreementService } from 'src/app/services/agreement.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Agreement } from 'src/app/model/agreement';

@Component({
  selector: 'app-lease-agreement-text',
  templateUrl: './lease-agreement-text.component.html',
})
export class LeaseAgreementTextComponent implements OnInit {

  agreement: Agreement;

  constructor(private activatedRoute: ActivatedRoute,
              private agreementService: AgreementService) { }

  ngOnInit(): void {
    this.loadAgreement();
  }

  loadAgreement(): void {
    const agreementId = Number(this.activatedRoute.snapshot.paramMap.get('agreementId'));
    this.agreementService.getAgreements()
      .subscribe(agreements => {
        this.agreement = agreements.filter(a => a.agreementId === agreementId).pop();
      });
  }

}
