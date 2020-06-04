import { Component, OnInit } from '@angular/core';
import { AgreementService } from 'src/app/services/agreement.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TenantService } from 'src/app/services/tenant.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-manager-create-agreement-template',
  templateUrl: './manager-create-agreement-template.component.html',
  styleUrls: ['./manager-create-agreement-template.component.css'],
})
export class ManagerCreateAgreementTempalteComponent implements OnInit {
  public leaseAgreementTemplateForm: FormGroup;
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

  constructor(
    private agreementService: AgreementService,
    private tenantService: TenantService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.leaseAgreementTemplateForm = this.formBuilder.group({
      title: ['', Validators.required],
      text: ['', Validators.required],
    });
  }

  get f() {
    return this.leaseAgreementTemplateForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    // stop if form is invalid
    if (this.leaseAgreementTemplateForm.invalid) {
      return;
    }

    this.agreementService
      .addAgreementTemplate({
        title: this.f.title.value,
        text: this.f.text.value,
      })
      .toPromise()
      .then((_) => this.router.navigate(['/']));
  }
}
