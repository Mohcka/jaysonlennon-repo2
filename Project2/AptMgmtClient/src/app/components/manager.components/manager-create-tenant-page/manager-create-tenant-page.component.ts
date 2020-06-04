import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

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
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.tenantCreationForm = this.formBuilder.group(
      {
        tenantEmail: ['', Validators.required],
        tenantPassword: ['', Validators.required],
        tenantConfirmPassword: ['', Validators.required],
      },
      {
        validators: this.confirmValidator(
          'tenantPassword',
          'tenantConfirmPassword'
        ),
      }
    );
  }

  get f() {
    return this.tenantCreationForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.tenantCreationForm.invalid) {
      return;
    }
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
