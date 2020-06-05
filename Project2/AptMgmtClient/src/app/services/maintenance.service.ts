import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiBase } from '../../ApiBase';
import { MaintenanceRequestData } from '../model/maintenance-request-data';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';
import { MaintenanceRequest } from '../model/maintenance-request';
import { MaintenanceRequestUpdate } from '../model/maintenance-update';

@Injectable({
  providedIn: 'root',
})
export class MaintenanceService {

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  private apiUrl = ApiBase.url() + 'Maintenance';

  constructor(protected http: HttpClient) {}

  public createNewRequest(data: MaintenanceRequestData): Observable<MaintenanceRequest> {
    return this.http
      .post<MaintenanceRequest>(this.apiUrl, data, this.httpOptions)
      .pipe(/* catchError(handleError<null>('maintenance.service(createNewRequest)')) */);
  }

  public cancelRequest(data: MaintenanceRequestUpdate): Observable<MaintenanceRequest> {
    return this.http
      .post<MaintenanceRequest>(this.apiUrl, data, this.httpOptions)
      .pipe(catchError(handleError<null>('maintenance.service(createNewRequest)')));
  }

  public updateRequest(data: MaintenanceRequestUpdate): Observable<MaintenanceRequest> {
    return this.http
      .post<MaintenanceRequest>(this.apiUrl, data, this.httpOptions)
      .pipe(/* catchError(handleError<null>('maintenance.service(updateRequest)')) */);
  }

  public getAll(): Observable<MaintenanceRequest[]> {
    return this.http
      .get<MaintenanceRequest[]>(this.apiUrl)
      .pipe(catchError(handleError<MaintenanceRequest[]>('maintenance.service(getAll)', [])));
  }
}
