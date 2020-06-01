import { Injectable } from '@angular/core';
import { GenericRest } from './generic-rest.service';
import { HttpClient } from '@angular/common/http';
import { Manager } from '../model/manager';
import { ApiBase } from 'src/ApiBase';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class ManagerService extends GenericRest<Manager> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'manager');
  }

  /**
   * Retreive details of specified tenant to view their details
   * such as their lease agreement, historical data, and when their lease expires
   * @param id Id of the tenant
   */
  getTenantDetails(id: number): Observable<any> {
    // TODO: set type of data for observable to use
    return this.http
      .post<any>(`${this.apiUrl}`, {}, this.httpOptions) // TODO: specify shape of data to send with post request
      .pipe(catchError(handleError<Manager>('managementGetTenantDetails')));
  }
}
