import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tenant } from '../model/tenant';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';
import { GenericRest } from './generic-rest.service';
import { ApiBase } from '../../ApiUrls';

@Injectable({
  providedIn: 'root',
})
export class TenantService extends GenericRest<Tenant> {
  // private readonly tenantUrl = 'api/tenant';

  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'tenant');
  }

  // public getTenants(): Observable<Tenant[]> {
  //   return this.http
  //     .get<Tenant[]>(this.tenantUrl)
  //     .pipe(catchError(handleError<Tenant[]>('getTenants', [])));
  // }

  // public getTenant(id: number): Observable<Tenant> {
  //   return this.http
  //     .get<Tenant>(`${this.tenantUrl}/${id}`)
  //     .pipe(catchError(handleError<Tenant>('getTenant', undefined)));
  // }
}
