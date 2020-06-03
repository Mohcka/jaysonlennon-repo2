import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Tenant } from 'src/app/model/tenant';
import { TenantService } from 'src/app/services/tenant.service';

@Component({
  selector: 'app-tenant-edit-info',
  templateUrl: './tenant-edit-info.component.html',
  styleUrls: ['./tenant-edit-info.component.css'],
})
export class TenantEditInfoComponent implements OnInit {
  public tenantForm: FormGroup;
  public tenant: Tenant;
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
    private router: Router,
    private authService: AuthenticationService,
    private tenantService: TenantService
  ) {}

  ngOnInit() {
    this.tenantForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
    });

    this.getTenant();
  }

  public getTenant(): void {
    this.tenantService.getTenant().subscribe((tenant) => {
      this.tenant = tenant;

      // update form with tenants details
      this.tenantForm.patchValue({
        firstName: tenant.firstName,
        lastName: tenant.lastName,
        email: tenant.email,
        phoneNumber: tenant.phoneNumber,
      });
    });
  }

  // convencience getter for easy access to form fields
  get f() {
    return this.tenantForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    // stop if form is invalid
    if (this.tenantForm.invalid) {
      return;
    }

    this.loading = true;

    const updatedTenant: Tenant = {
      tenantId: this.tenant.tenantId,
      phoneNumber: this.f.phoneNumber.value,
      email: this.f.email.value,
      firstName: this.f.firstName.value,
      lastName: this.f.lastName.value,
      unitNumber: this.tenant.unitNumber,
    };

    this.tenantService.updateTenant(updatedTenant).subscribe(
      (_data) => {
        this.router.navigate(['/tenant']);
      },
      (err) => {
        this.error = JSON.stringify(err);
        this.loading = false;
      }
    );
  }
}
