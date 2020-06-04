import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ValidatorFn,
  AbstractControl,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/model/user';
import { TenantService } from 'src/app/services/tenant.service';
import { UserAccountType } from 'src/enums/user-account-type';
import { first } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-tenant-signup-page',
  templateUrl: './tenant-signup-page.component.html',
  styleUrls: ['./tenant-signup-page.component.css'],
})
export class TenantSignupPageComponent implements OnInit {
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
    private userService: UserService,
    private tenantService: TenantService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.tenantCreationForm = this.formBuilder.group(
      {
        tenantEmail: ['', [Validators.required, Validators.email]],
        tenantPassword: ['', Validators.required],
        tenantConfirmPassword: ['', Validators.required],
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
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

    // TODO: find tenant by email to validat they exist

    // return;

    const newUser: User = {
      loginName: this.f.tenantEmail.value,
      firstName: this.f.firstName.value,
      lastName: this.f.lastName.value,
      password: this.f.tenantPassword.value,
      userAccountType: UserAccountType.Tenant,
    };

    this.userService
      .updateUser(newUser)
      .pipe(first())
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

  // confirmMatchingValidator(controlNameToMatch: string): ValidatorFn {
  //   return (control: AbstractControl): { [key: string]: any } | null => {
  //     return controlNameToMatch.value !== control.value
  //       ? { confirmMatching: { value: control.value } }
  //       : null;
  //   };
  // }

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
