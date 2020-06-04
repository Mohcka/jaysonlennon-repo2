import { AuthenticationService } from './../../../services/authentication.service';
import { Unit } from './../../../model/unit';
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
  public emptyUnits: Unit[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private tenantService: TenantService,
    private unitService: UnitService,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.tenantCreationForm = this.formBuilder.group({
      tenantEmail: ['', Validators.email],
      unitNumber: [ '', Validators.required ],
    });

    this.getEmptyUnits();
  }

  getEmptyUnits(): void {
    this.unitService.getUnits().subscribe(units => this.emptyUnits = units.filter(u => u.tenantId === null))
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
      unitNumber: this.f.unitNumber.value,
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
        (_) => this.router.navigate([this.authenticationService.getHomeRoute()]),
        (error: HttpErrorResponse) => {
          this.error =
            error.error && error.error.message
              ? error.error.message
              : JSON.stringify(error);
          this.loading = false;
        }
      );
  }
}
