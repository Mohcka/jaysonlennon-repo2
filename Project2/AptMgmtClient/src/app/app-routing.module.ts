import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { HomeComponent } from './components/home/home.component';
import { MaintenanceRequestsComponent } from './components/maintenance/maintenance-requests/maintenance-requests.component';
import { TenantDetailsComponent } from './components/tenant.components/tenant-details/tenant-details.component';
import { TenantsComponent } from './components/tenant.components/tenants/tenants.component';
import { AuthGuard } from './guard/auth.guard';
import { LoginComponent } from './components/login/login.component';
import { TenantComponent } from './components/tenant.components/tenant/tenant.component';
import { TenantPaymentComponent } from './components/tenant.components/tenant-payment/tenant-payment.component';
import { MaintenanceRequestFormComponent } from './components/maintenance/maintenance-request-form/maintenance-request-form.component';
import { ManagerComponent } from './components/manager.components/manager/manager.component';

// Define routes for the application
const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  // * Auth
  { path: 'login', component: LoginComponent },
  // * Tenants
  { path: 'tenant', component: TenantComponent },
  { path: 'tenant/payment', component: TenantPaymentComponent },
  { path: 'tenants', component: TenantsComponent },
  { path: 'tenant-detail/:id', component: TenantDetailsComponent },
  {
    path: 'tenant/:id/maintenance',
    component: MaintenanceRequestFormComponent,
  },
  // * Manager
  { path: 'manager', component: ManagerComponent },
  // * Maintenance
  {
    path: 'maintenance-requests',
    component: MaintenanceRequestsComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
