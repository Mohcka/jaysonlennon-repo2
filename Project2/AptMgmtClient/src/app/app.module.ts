/// <reference types="node" />
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Provider } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MaintenanceRequestsComponent } from './components/maintenance/maintenance-requests/maintenance-requests.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { TenantDetailsComponent } from './components/tenant.components/tenant-details/tenant-details.component';
import { TenantsComponent } from './components/tenant.components/tenants/tenants.component';
import { TenantComponent } from './components/tenant.components/tenant/tenant.component';
import { TenantPaymentComponent } from './components/tenant.components/tenant-payment/tenant-payment.component';
import { MaintenanceRequestFormComponent } from './components/maintenance/maintenance-request-form/maintenance-request-form.component';
import { ApiTokenInterceptor } from './helpers/api-token.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { LoginComponent } from './components/login/login.component';

import { ResourceEnumPipe } from './helpers/resource-enum-pipe';
import { MaintenanceCloseReasonEnumPipe } from './helpers/maintenance-close-reason-pipe';

import { environment } from './../environments/environment';

//import { LeaseTenComponent } from './components/tenant/lease-ten/lease-ten.component';
//import { MaintenanceTenComponent } from './components/tenant/maintenance-ten/maintenance-ten.component';
import { PaymentTenComponent } from './components/tenant/payment-ten/payment-ten.component';
//import { LeaseManComponent } from './components/manager/lease-man/lease-man.component';
//import { MaintenanceManComponent } from './components/manager/maintenance-man/maintenance-man.component';
import { PaymentManComponent } from './components/manager/payment-man/payment-man.component';

import { ManagerComponent } from './components/manager.components/manager/manager.component';
import { ManagerMaintenanceRequestListComponent } from './components/manager/manager-maintenance-request-list/manager-maintenance-request-list.component';
import { LeaseViewComponent } from './components/manager/lease-view/lease-view.component';
import { LeaseAddComponent } from './components/manager/lease-add/lease-add.component';
import { RouterHubComponent } from './components/router-hub/router-hub.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TenantsComponent,
    TenantDetailsComponent,
    MaintenanceRequestsComponent,
    LoginComponent,
    TenantComponent,
    TenantPaymentComponent,
    MaintenanceRequestFormComponent,
    ManagerComponent,
    ResourceEnumPipe,
    MaintenanceCloseReasonEnumPipe,
    ManagerMaintenanceRequestListComponent,
    //LeaseTenComponent,
    //MaintenanceTenComponent,
    PaymentTenComponent,
    //LeaseManComponent,
    //MaintenanceManComponent,
    PaymentManComponent,
    LeaseViewComponent,
    LeaseAddComponent,
    RouterHubComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ApiTokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
