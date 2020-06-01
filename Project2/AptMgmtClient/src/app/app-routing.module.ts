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
//import { LeaseTenComponent } from './components/tenant/lease-ten/lease-ten.component';
//import { MaintenanceTenComponent } from './components/tenant/maintenance-ten/maintenance-ten.component';
import { PaymentTenComponent } from './components/tenant/payment-ten/payment-ten.component';
//import { LeaseManComponent } from './components/manager/lease-man/lease-man.component';
//import { MaintenanceManComponent } from './components/manager/maintenance-man/maintenance-man.component';
import { PaymentManComponent } from './components/manager/payment-man/payment-man.component';

// Define routes for the application
const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  // * Auth
  { path: 'login', component: LoginComponent},
  // * Tenants
  { path: 'tenants', component: TenantsComponent },
  { path: 'tenant-detail/:id', component: TenantDetailsComponent },
  // * Maintenance
  { path: 'maintenance-requests', component: MaintenanceRequestsComponent, canActivate: [AuthGuard] },
 // { path: 'manager/maintenance', component: MaintenanceManComponent },
 // { path: 'tenant/maintenance', component: MaintenanceTenComponent },
  
  // * Payments Pages
  { path: 'manager/payment', component: PaymentManComponent },
  { path: 'tenant/payment', component: PaymentTenComponent },
  // * Lease Pages
 // { path: 'manager/lease', component: LeaseManComponent },
 // { path: 'tenant/lease', component: LeaseTenComponent },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
