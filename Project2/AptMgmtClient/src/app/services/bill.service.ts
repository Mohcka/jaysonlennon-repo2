import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { GenericRest } from './generic-rest.service';
import { ApiBase } from 'src/ApiBase';
import { PayBillData } from '../model/pay-bill-data';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';
import { Bill } from '../model/bill';

@Injectable({
  providedIn: 'root',
})
export class BillService extends GenericRest<Bill | Bill[]> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'bills');
  }

  public payBill(billData: PayBillData): Observable<Bill> {
    return this.http
      .post<Bill>(ApiBase.url() + 'Bill', billData, this.httpOptions)
      .pipe(catchError(handleError<Bill>('bill.service(payBill)')));
  }

  public getBillsInCurrentPeriod(): Observable<Bill[]> {
    return this.http
      .get<Bill[]>(ApiBase.url() + 'Bills')
      .pipe(
        catchError(
          handleError<Bill[]>('bill.serice(getBillsInCurrentPeriod)', [])
        )
      );
  }

  public getBillsInPeriod(period: number): Observable<Bill[]> {
    return this.http
      .get<Bill[]>(ApiBase.url() + `Bills/${period}`)
      .pipe(
        catchError(handleError<Bill[]>('bill.serice(getBillsInPeriod)', []))
      );
  }

  public getUnpaidBills(): Observable<Bill[]> {
    return this.http
      .get<Bill[]>(this.apiUrl + '/Unpaid')
      .pipe(catchError(handleError<Bill[]>('getUnpaidBills')));
  }
}
