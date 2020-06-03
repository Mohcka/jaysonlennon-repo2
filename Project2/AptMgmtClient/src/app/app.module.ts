import { ManagerHomeComponent } from './components/manager.components/manager-home/manager-home.component';
/// <reference types="node" />
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Provider } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TenantHomeComponent } from './components/tenant.components/tenant-home/tenant-home.component';
import { MaintenanceRequestsComponent } from './components/universal.components/maintenance-requests/maintenance-requests.component';
import { NavMenuComponent } from './components/universal.components/nav-menu/nav-menu.component';
import { TenantDetailsComponent } from './components/tenant.components/tenant-details/tenant-details.component';
import { MaintenanceRequestFormComponent } from './components/universal.components/maintenance-request-form/maintenance-request-form.component';
import { ApiTokenInterceptor } from './helpers/api-token.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { LoginComponent } from './components/universal.components/login/login.component';
import { ManagerMaintenanceRequestListComponent } from './components/manager.components/manager-maintenance-request-list/manager-maintenance-request-list.component';
import { RouterHubComponent } from './components/universal.components/router-hub/router-hub.component';

import { ResourceEnumPipe } from './helpers/resource-enum-pipe';
import { MaintenanceCloseReasonEnumPipe } from './helpers/maintenance-close-reason-pipe';
import { ManagerListTenantsComponent } from './components/manager.components/manager-list-tenants/manager-list-tenants.component';
import { UnauthorizedAccessComponent } from './components/universal.components/unauthorized-access/unauthorized-access.component';
import { TenantPageBillPayComponent } from './components/tenant.components/tenant-page-bill-pay/tenant-page-bill-pay.component';
import { TenantPageListBillsComponent } from './components/tenant.components/tenant-page-list-bills/tenant-page-list-bills.component';

@NgModule({
  declarations: [
    AppComponent,

    // Components - Universal
    NavMenuComponent,
    MaintenanceRequestsComponent,
    MaintenanceRequestFormComponent,
    LoginComponent,
    RouterHubComponent,
    UnauthorizedAccessComponent,

    // Tenant components
    TenantHomeComponent,
    TenantDetailsComponent,

    // Tenant pages
    TenantPageListBillsComponent,
    TenantPageBillPayComponent,

    // Manager components
    ManagerHomeComponent,
    ManagerMaintenanceRequestListComponent,
    ManagerListTenantsComponent,

    // Pipes
    ResourceEnumPipe,
    MaintenanceCloseReasonEnumPipe,
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
