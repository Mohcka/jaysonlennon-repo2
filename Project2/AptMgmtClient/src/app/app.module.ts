/// <reference types="node" />
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Provider } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { HomeComponent } from './components/home/home.component';
import { MaintenanceRequestsComponent } from './components/maintenance/maintenance-requests/maintenance-requests.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { TenantDetailsComponent } from './components/tenant.components/tenant-details/tenant-details.component';
import { TenantsComponent } from './components/tenant.components/tenants/tenants.component';
import { ApiTokenInterceptor } from './helpers/api-token.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { LoginComponent } from './components/login/login.component';

import { ResourceEnumPipe } from './helpers/resource-enum-pipe';

import { environment } from './../environments/environment';

//import { LeaseTenComponent } from './components/tenant/lease-ten/lease-ten.component';
//import { MaintenanceTenComponent } from './components/tenant/maintenance-ten/maintenance-ten.component';
import { PaymentTenComponent } from './components/tenant/payment-ten/payment-ten.component';
//import { LeaseManComponent } from './components/manager/lease-man/lease-man.component';
//import { MaintenanceManComponent } from './components/manager/maintenance-man/maintenance-man.component';
import { PaymentManComponent } from './components/manager/payment-man/payment-man.component';

// Used in development builds only
import { InMemoryDataService } from './services/in-memory-data.service';
import { fakeAuthBackendProvider } from './helpers/fake-auth-backend.interceptor';
import { LeaseViewComponent } from './lease-view/lease-view.component';
import { LeaseAddComponent } from './lease-add/lease-add.component';

// Uses mock api when under development, replaced with a blank module in
// production
const inMemApiModule =
  process.env.NODE_ENV === 'development' && environment.memoryApi === true
    ? HttpClientInMemoryWebApiModule.forRoot(InMemoryDataService, {
        dataEncapsulation: false,
      })
    : CommonModule;

const providers: Provider[] = [
    { provide: HTTP_INTERCEPTORS, useClass: ApiTokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
];

if (process.env.NODE_ENV === 'development' && environment.memoryApi === true) {
  providers.push(fakeAuthBackendProvider);
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TenantsComponent,
    TenantDetailsComponent,
    MaintenanceRequestsComponent,
    LoginComponent,
    ResourceEnumPipe,
    //LeaseTenComponent,
    //MaintenanceTenComponent,
    PaymentTenComponent,
    //LeaseManComponent,
    //MaintenanceManComponent,
    PaymentManComponent,
    LeaseViewComponent,
    LeaseAddComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    inMemApiModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
  providers: providers,
  bootstrap: [AppComponent],
})
export class AppModule {}
