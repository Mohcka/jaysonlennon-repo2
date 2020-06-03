import { TenantPageListAgreementsComponent } from './components/tenant.components/tenant-page-list-agreements/tenant-page-list-agreements.component';
import { TenantPageBillPayComponent } from './components/tenant.components/tenant-page-bill-pay/tenant-page-bill-pay.component';
import { UnauthorizedAccessComponent } from './components/universal.components/unauthorized-access/unauthorized-access.component';
import { UserAccountType } from './../enums/user-account-type';
import { ManagerHomeComponent } from './components/manager.components/manager-home/manager-home.component';
import { RouterHubComponent } from './components/universal.components/router-hub/router-hub.component';
import { ManagerMaintenanceRequestListComponent } from './components/manager.components/manager-maintenance-request-list/manager-maintenance-request-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TenantHomeComponent } from './components/tenant.components/tenant-home/tenant-home.component';
import { MaintenanceRequestsComponent } from './components/universal.components/maintenance-requests/maintenance-requests.component';
import { TenantDetailsComponent } from './components/tenant.components/tenant-details/tenant-details.component';
import { AuthGuard } from './guard/auth.guard';
import { LoginComponent } from './components/universal.components/login/login.component';
import { MaintenanceRequestFormComponent } from './components/universal.components/maintenance-request-form/maintenance-request-form.component';
import { ManagerListTenantsComponent } from './components/manager.components/manager-list-tenants/manager-list-tenants.component';
import { TenantPageListBillsComponent } from './components/tenant.components/tenant-page-list-bills/tenant-page-list-bills.component';

// Define routes for the application
const routes: Routes = [
  // Universal routes
  { path: 'hub', component: RouterHubComponent },
  { path: 'login', component: LoginComponent },
  { path: '403', component: UnauthorizedAccessComponent },

  // Tenants
  { path: 'tenant', component: TenantHomeComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },


  { path: 'tenant/tenantInfo/:id', component: TenantDetailsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  { path: 'tenant/maintenance/new', component: MaintenanceRequestFormComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  { path: 'tenant/maintenance/list', component: MaintenanceRequestsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  { path: 'tenant/bill/list', component: TenantPageListBillsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  { path: 'tenant/bill/pay/:periodId/:resourceTypeId', component: TenantPageBillPayComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  { path: 'tenant/agreement/list', component: TenantPageListAgreementsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  // Managers
  { path: 'manager', component: ManagerHomeComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/tenants/list', component: ManagerListTenantsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/maintenance/list', component: ManagerMaintenanceRequestListComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
