import { AgreementTemplate } from './../model/agreement-template';
import { Injectable } from '@angular/core';
import { Agreement } from '../model/agreement';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiBase } from 'src/ApiBase';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class AgreementService {
  constructor(protected http: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  public getAgreements(): Observable<Agreement[]> {
    return this.http
      .get<Agreement[]>(ApiBase.url() + 'Agreements')
      .pipe(catchError(handleError<Agreement[]>('agreement.service(getAgreements)', [])));
  }

  public signAgreement(data: Agreement): Observable<Agreement> {
    return this.http
      .post<Agreement>(ApiBase.url() + 'Agreement', data, this.httpOptions)
      .pipe(/* catchError(handleError<null>('agreement.service(signAgreement)')) */);
  }

  public getAgreementTemplates(): Observable<Agreement[]> {
    return this.http
      .get<Agreement[]>(ApiBase.url() + 'AgreementTemplates')
      .pipe(catchError(handleError<Agreement[]>('agreement.service(getAgreementTemplates)', [])));
  }

  public addAgreementTemplate(data: AgreementTemplate): Observable<AgreementTemplate> {
    return this.http
      .post<AgreementTemplate>(ApiBase.url() + 'AgreementTemplate', data, this.httpOptions)
      .pipe(catchError(handleError<null>('agreement.service(addAgreementTemplate)')));
  }
}
