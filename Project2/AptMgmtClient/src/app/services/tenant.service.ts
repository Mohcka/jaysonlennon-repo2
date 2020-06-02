import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Tenant } from '../model/tenant';
import { Observable } from 'rxjs';
import { ApiBase } from 'src/ApiBase';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class TenantService {
  constructor(protected http: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  getTenants(): Observable<Tenant[]> {
    return this.http
      .get<Tenant[]>(ApiBase.url() + 'Tenants')
      .pipe(catchError(handleError<Tenant[]>('tenant.service(getTenants)', [])));
  }

  getTenant(): Observable<Tenant> {
    return this.http
      .get<Tenant>(ApiBase.url() + `Tenant`)
      .pipe(catchError(handleError<null>('tenant.service(getTenant)')));
  }

  getTenantById(id: number): Observable<Tenant> {
    return this.http
      .get<Tenant>(ApiBase.url() + `Tenant/${id}`)
      .pipe(catchError(handleError<null>('tenant.service(getTenantById)')));
  }


}
