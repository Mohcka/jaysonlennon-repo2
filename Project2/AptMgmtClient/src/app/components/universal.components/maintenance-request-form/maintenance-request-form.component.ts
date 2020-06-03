import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TenantService } from 'src/app/services/tenant.service';
import { Tenant } from 'src/app/model/tenant';
import { ResourcesStrArr } from 'src/enums/Resource';
import { MaintenanceRequestData } from 'src/app/model/maintenance-request-data';

@Component({
  selector: 'app-maintenance-request-form',
  templateUrl: './maintenance-request-form.component.html',
  styleUrls: ['./maintenance-request-form.component.css'],
})
export class MaintenanceRequestFormComponent implements OnInit {
  public maintenanceRequestForm: FormGroup;
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

  public tenants: Tenant[];

  // TODO: Get maintenance request type samples from server
  public maintenanceRequestTypes: string[] = ResourcesStrArr;

  constructor(
    private maintenanceService: MaintenanceService,
    private tenantService: TenantService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getTenants();

    let formGroupFields: any = {
      type: [ResourcesStrArr[0], Validators.required],
      notes: ['', Validators.required],
    };

    if (this.isManager) {
      formGroupFields = {
        ...formGroupFields,
        tenantUnit: ['', Validators.required],
      };
    }

    this.maintenanceRequestForm = this.formBuilder.group(formGroupFields);
  }

  get f() {
    return this.maintenanceRequestForm.controls;
  }

  get isManager() {
    return this.authService.currentUserIsManager();
  }

  getTenants(): void {
    if (!this.isManager) {
      return;
    }

    this.tenantService.getTenants().subscribe((tenants) => {
      this.tenants = tenants;

      this.maintenanceRequestForm.patchValue({
        tenantUnit: tenants[0].unitNumber,
      });
    });
  }

  onSubmit(): void {
    this.submitted = true;

    // stop if form is invalid
    if (this.maintenanceRequestForm.invalid) {
      return;
    }

    let maintenanceRequestData: MaintenanceRequestData = {
      openNotes: this.f.notes.value,
      maintenanceRequestType: this.f.type.value,
    };

    if (this.isManager) {
      maintenanceRequestData = {
        ...maintenanceRequestData,
        unitNumber: this.f.tenantUnit.value,
      };
    }

    this.maintenanceService
      .createNewRequest(maintenanceRequestData)
      .subscribe((_) =>
        this.router.navigate([
          `/${this.isManager ? 'manager' : 'tenant'}/maintenance/list`,
        ])
      );
  }
}
