import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericRest } from './generic-rest.service';
import { ApiBase } from '../../ApiBase';
import { MaintenanceRequestData } from '../model/maintenance-request-data';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root',
})
export class MaintenanceService extends GenericRest<any> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'maintenance');
  }

  createNewRequest(data: MaintenanceRequestData): Observable<any> {
    return this.http
      .post<any>(this.apiUrl, data, this.httpOptions)
      .pipe(catchError(handleError<any>('maintenance: createNewRequest')));
  }

  cancelRequest(): Observable<any> {
    return; // TODO: implement
  }
}
