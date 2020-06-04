import { AppIndexComponent } from './components/universal.components/app-index/app-index.component';
import { TenantPageViewResourceUsageComponent } from './components/tenant.components/tenant-page-view-resource-usage/tenant-page-view-resource-usage.component';
import { TenantPageListAgreementsComponent } from './components/tenant.components/tenant-page-list-agreements/tenant-page-list-agreements.component';
import { TenantPageBillPayComponent } from './components/tenant.components/tenant-page-bill-pay/tenant-page-bill-pay.component';
import { UnauthorizedAccessComponent } from './components/universal.components/unauthorized-access/unauthorized-access.component';
import { UserAccountType } from './../enums/user-account-type';
import { ManagerHomeComponent } from './components/manager.components/manager-home/manager-home.component';
import { RouterHubComponent } from './components/universal.components/router-hub/router-hub.component';
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
import { TenantEditInfoComponent } from './components/tenant.components/tenant-edit-info/tenant-edit-info.component';
import { AssignLeasePageComponent } from './components/manager.components/manager-assign-lease-page/assign-lease-page.component';
import { ManagerCreateAgreementTempalteComponent } from './components/manager.components/manager-create-agreement-template/manager-create-agreement-template.component';
import { LeaseAgreementsOageComponent } from './components/universal.components/lease-agreements-page/lease-agreements-page.component';
import { ManagerCreateTenantPageComponent } from './components/manager.components/manager-create-tenant-page/manager-create-tenant-page.component';
import { TenantSignupPageComponent } from './components/tenant.components/tenant-signup-page/tenant-signup-page.component';

// Define routes for the application
const routes: Routes = [
  // Universal routes
  { path: '', component: AppIndexComponent },
  { path: 'hub', component: RouterHubComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: TenantSignupPageComponent, },
  { path: '403', component: UnauthorizedAccessComponent },
  { path: 'maintenance', component: MaintenanceRequestsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Admin, UserAccountType.Tenant, UserAccountType.Manager]}},
  { path: 'agreements', component: LeaseAgreementsOageComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Admin, UserAccountType.Tenant, UserAccountType.Manager]}},


  // Tenants
  { path: 'tenant', component: TenantHomeComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  { path: 'tenant/edit', component: TenantEditInfoComponent,
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

  { path: 'tenant/resource/home', component: TenantPageViewResourceUsageComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Tenant] } },

  // Managers
  { path: 'manager', component: ManagerHomeComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/tenants/list', component: ManagerListTenantsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/tenants/create', component: ManagerCreateTenantPageComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/maintenance/list', component: MaintenanceRequestsComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/maintenance/new', component: MaintenanceRequestFormComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/lease-agreement/assign', component: AssignLeasePageComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },

  { path: 'manager/lease-agreement/new-template', component: ManagerCreateAgreementTempalteComponent,
    canActivate: [AuthGuard], data: { roles: [UserAccountType.Manager] } },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
