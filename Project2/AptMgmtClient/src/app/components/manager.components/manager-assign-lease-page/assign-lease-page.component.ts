import { Component, OnInit } from '@angular/core';
import { AgreementService } from 'src/app/services/agreement.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TenantService } from 'src/app/services/tenant.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Agreement } from 'src/app/model/agreement';
import { Tenant } from 'src/app/model/tenant';
import { AgreementTemplate } from 'src/app/model/agreement-template';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-assign-lease-page',
  templateUrl: './assign-lease-page.component.html',
  styleUrls: ['./assign-lease-page.component.css'],
})
export class AssignLeasePageComponent implements OnInit {
  public leaseAgreementForm: FormGroup;
  /**
   * loading state provided to view component
   */
  public loading = false;
  /**
   * State to determine of the form has been submitted
   */
  public submitted = false;
  public returnUrl: string;
  public error = '';

  public agreementTemplates: AgreementTemplate[];
  public tenants: Tenant[];

  constructor(
    private agreementService: AgreementService,
    private tenantService: TenantService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.getAgreementTemplates();
    this.getTenants();

    this.leaseAgreementForm = this.formBuilder.group({
      agreementTemplateId: ['', Validators.required],
      tenantId: ['', Validators.required],
      startDate: [this.formatDate(new Date()), Validators.required],
      endDate: [
        this.formatDate(this.getDateByNextMonth()),
        Validators.required,
      ],
    });
  }

  get f() {
    return this.leaseAgreementForm.controls;
  }

  get isManager() {
    return this.authService.currentUserIsManager();
  }

  getAgreementTemplates(): void {
    this.agreementService
      .getAgreementTemplates()
      .subscribe((agreementTemplates) => {
        this.agreementTemplates = agreementTemplates;

        this.leaseAgreementForm.patchValue({
          agreementTemplateId: agreementTemplates[0].agreementTemplateId,
        });
      });
  }

  getTenants(): void {
    this.tenantService
      .getTenants()
      .toPromise()
      .then((tenants) => {
        this.tenants = tenants;

        this.leaseAgreementForm.patchValue({
          tenantId: tenants[0].tenantId,
        });
      });
  }

  onSubmit(): void {
    // console.log(+this.f.tenantId.value);
    // console.log(+this.f.agreementTemplateId.value);
    // console.log(this.f.startDate.value);
    // console.log(this.f.endDate.value);

    this.submitted = true;

    // stop if form is invalid
    if (this.leaseAgreementForm.invalid) {
      return;
    }

    // return;

    this.agreementService
      .signAgreement({
        agreementId: 0,
        title: null,
        text: null,
        signedDate: null,
        tenantId: +this.f.tenantId.value,
        agreementTemplateId: +this.f.agreementTemplateId.value,
        startDate: this.f.startDate.value,
        endDate: this.f.endDate.value,
      })
      .toPromise()
      .then(
        (_) => {
          this.router.navigate([this.authService.getHomeRoute()]);
        },
        (error: HttpErrorResponse) => {
          this.error =
            error.error && error.error.message
              ? error.error.message
              : JSON.stringify(error);
          this.loading = false;
        }
      );
  }

  /**
   * Formats the provided date to be used in the date input
   * @param date The `Date` to format
   * @see https://stackoverflow.com/questions/57198151/how-to-set-the-date-in-angular-reactive-forms-using-patchvalue
   */
  private formatDate(date) {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) {
      month = '0' + month;
    }
    if (day.length < 2) {
      day = '0' + day;
    }
    return [year, month, day].join('-');
  }

  /**
   * Gets the date for next month from now
   * @see https://stackoverflow.com/questions/499838/javascript-date-next-month
   */
  private getDateByNextMonth(): Date {
    const now = new Date();
    let current: Date;
    if (now.getMonth() === 11) {
      current = new Date(now.getFullYear() + 1, 0, 1);
    } else {
      current = new Date(now.getFullYear(), now.getMonth() + 1, 1);
    }
    // TODO: fix where current date exceeds the number of days for next month
    current.setDate(now.getDate());
    return current;
  }
}
