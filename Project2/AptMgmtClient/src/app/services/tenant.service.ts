import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tenant } from '../model/tenant';
import { catchError, tap } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';
import { GenericRest } from './generic-rest.service';
import { ApiBase } from '../../ApiBase';
import { Resource } from 'src/enums/Resource';
import { Bill } from '../model/bill';
import { PayBillData } from '../model/pay-bill-data';

@Injectable({
  providedIn: 'root',
})
export class TenantService extends GenericRest<Tenant> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'tenant');
  }

  /**
   * Processes a payment request on behalf of the tenant
   * @param id Id of the tenant making rent payment request
   */
  registerPayment(id: number, data: PayBillData): Observable<any> {
    return this.http
      .post<Tenant[]>(
        // TODO: send expected data when api is setup
        `${this.apiUrl}/${id}/rent`,
        data,
        this.httpOptions
      )
      .pipe(catchError(handleError<Tenant>('registerTenantPayment')));
  }

  /**
   * Sends a request to the server for a tenant to make a payment
   * @param billData Data the server expects to process the payment
   */
  payBill(billData: PayBillData): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}/bill`, billData, this.httpOptions)
      .pipe(catchError(handleError<PayBillData>('tenantPayBill')));
  }

  /**
   * Posts a maintenance request for the server to process
   * @param id The id of the tenant making the request
   */
  postMaintenanceRequest(id: number): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}/${id}/maintenance`, {}, this.httpOptions)
      .pipe(catchError(handleError<any>('tenantMaintenanceRequest')));
  }
}
