import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericRest } from './generic-rest.service';
import { ApiBase } from 'src/ApiBase';
import { PayBillData } from '../model/pay-bill-data';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class BillService extends GenericRest<any> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'bill');
  }

  /**
   * Sends a request to the server for a tenant to make a payment
   * @param billData Data the server expects to process the payment
   */
  payBill(billData: PayBillData): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}`, billData, this.httpOptions)
      .pipe(catchError(handleError<PayBillData>('tenantPayBill')));
  }
}
