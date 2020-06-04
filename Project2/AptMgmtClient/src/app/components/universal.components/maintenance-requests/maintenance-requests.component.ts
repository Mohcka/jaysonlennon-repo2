import { TenantService } from 'src/app/services/tenant.service';
import { Component, OnInit } from '@angular/core';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { MaintenanceRequest } from 'src/app/model/maintenance-request';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { MaintenanceRequestData } from 'src/app/model/maintenance-request-data';
import { MaintenanceRequestUpdate } from 'src/app/model/maintenance-update';
import { Tenant } from 'src/app/model/tenant';

@Component({
  selector: 'app-maintenance-requests',
  templateUrl: './maintenance-requests.component.html',
  styleUrls: ['./maintenance-requests.component.css'],
})
export class MaintenanceRequestsComponent implements OnInit {
  public maintenanceRequests: MaintenanceRequest[];
  tenant: Tenant;

  constructor(
    private maintenanceService: MaintenanceService,
    public authService: AuthenticationService,
    public tenantService: TenantService
  ) {}

  ngOnInit() {
    this.getAllRequests();
    this.getTenant();
  }

  getTenant(): void {
    this.tenantService.getTenant().subscribe(t => this.tenant = t);
  }

  get isManager(): boolean {
    return this.authService.currentUserIsManager();
  }

  get isTenant(): boolean {
    return this.authService.currentUserIsTenant();
  }

  cancelRequest(request: MaintenanceRequestUpdate): void {
    this.maintenanceService
      .cancelRequest({ ...request, closed: true })
      .subscribe((_) => this.getAllRequests());
  }

  public getAllRequests(): void {
    this.maintenanceService.getAll().subscribe(
      (requests) =>
        (this.maintenanceRequests = requests.sort((a, b) => {
          // Sort list by id
          if (a.maintenanceRequestId < b.maintenanceRequestId) {
            return -1;
          }
          if (b.maintenanceRequestId < a.maintenanceRequestId) {
            return 1;
          }
          return 0;
        }))
    );
  }
}
