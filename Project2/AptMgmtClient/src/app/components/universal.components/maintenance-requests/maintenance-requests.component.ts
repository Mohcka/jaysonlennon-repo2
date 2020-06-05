import { TenantService } from 'src/app/services/tenant.service';
import { Component, OnInit } from '@angular/core';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { MaintenanceRequest } from 'src/app/model/maintenance-request';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { MaintenanceRequestUpdate } from 'src/app/model/maintenance-update';
import { MaintenanceCloseReason } from 'src/enums/maintenance-close-reason';
import { Tenant } from 'src/app/model/tenant';

@Component({
  selector: 'app-maintenance-requests',
  templateUrl: './maintenance-requests.component.html',
})
export class MaintenanceRequestsComponent implements OnInit {
  public closeReason = MaintenanceCloseReason;
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
    this.tenantService.getTenant().subscribe((t) => (this.tenant = t));
  }

  get isManager(): boolean {
    return this.authService.currentUserIsManager();
  }

  get isTenant(): boolean {
    return this.authService.currentUserIsTenant();
  }

  completeRequest(request: MaintenanceRequestUpdate): void {
    this.maintenanceService
      .cancelRequest({
        ...request,
        closeReason: MaintenanceCloseReason.Completed,
      })
      .toPromise()
      .then((_) => this.getAllRequests());
  }

  cancelRequest(request: MaintenanceRequestUpdate): void {
    const closeReason = this.isManager
      ? MaintenanceCloseReason.CanceledByManagement
      : MaintenanceCloseReason.CanceledByTenant;
    this.maintenanceService
      .cancelRequest({ ...request, closeReason: closeReason })
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
