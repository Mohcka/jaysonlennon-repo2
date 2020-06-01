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
import { TenantComponent } from './components/tenant.components/tenant/tenant.component';
import { TenantPaymentComponent } from './components/tenant.components/tenant-payment/tenant-payment.component';
import { MaintenanceRequestFormComponent } from './components/maintenance/maintenance-request-form/maintenance-request-form.component';
import { ApiTokenInterceptor } from './helpers/api-token.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { LoginComponent } from './components/login/login.component';

import { environment } from './../environments/environment';

// Used in development builds only
import { InMemoryDataService } from './services/in-memory-data.service';
import { fakeAuthBackendProvider } from './helpers/fake-auth-backend.interceptor';
import { ManagerComponent } from './components/manager.components/manager/manager.component';

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
    TenantComponent,
    TenantPaymentComponent,
    MaintenanceRequestFormComponent,
    ManagerComponent,
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
