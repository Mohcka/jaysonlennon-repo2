import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';
import { first } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { UnitService } from 'src/app/services/unit.service';

@Component({
  selector: 'app-manager-create-tenant-page',
  templateUrl: './manager-create-tenant-page.component.html',
  styleUrls: ['./manager-create-tenant-page.component.css'],
})
export class ManagerCreateTenantPageComponent implements OnInit {
  public tenantCreationForm: FormGroup;
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
    private formBuilder: FormBuilder,
    private tenantService: TenantService,
    private unitService: UnitService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.tenantCreationForm = this.formBuilder.group({
      tenantEmail: ['', Validators.email],
      unitNumber: [
        '',
        [Validators.required, Validators.min(101), Validators.max(999)],
      ],
    });
  }

  get f() {
    return this.tenantCreationForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.tenantCreationForm.invalid) {
      return;
    }

    // return;

    const newTeanant: Tenant = {
      tenantId: 0,
      email: this.f.tenantEmail.value,
      unitNumber: null,
      phoneNumber: null,
      firstName: null,
      lastName: null,
    };

    // console.log(this.f.unitNumber.value);
    // return;

    this.tenantService
      .updateTenant(newTeanant)
      .pipe(first())
      .toPromise()
      .then(
        (createdTenant) => {
          this.addTenantsUnit(createdTenant.tenantId);
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

  private addTenantsUnit(tenantId: number): void {
    this.unitService
      .updateUnit({
        unitId: 0,
        unitNumber: this.f.unitNumber.value + '',
        tenantId: tenantId,
      })
      .toPromise()
      .then(
        (_) => this.router.navigate(['/']),
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
   * Confirms that the value of two formControls are matching
   *
   * @param controlName Name of the form control to compare
   * @param matchingControlName Name of the formControl to compare values of the first formControl
   * @see https://www.itsolutionstuff.com/post/angular-validation-password-and-confirm-passwordexample.html
   */
  confirmValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      // Return if matching controll has other errors than mattching
      if (matchingControl.errors && !matchingControl.errors.confirmValidator) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }
}
