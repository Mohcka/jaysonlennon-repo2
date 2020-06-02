import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MaintenanceRequest } from '../model/maintenance-request';
import { ApiBase } from '../../ApiBase';
import { Observable } from 'rxjs';
import { handleError } from 'src/utils/error-handling';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class MaintenanceService {

  private apiUrl = ApiBase.url() + 'Maintenance';

  constructor(protected http: HttpClient) { }

   public getAll(): Observable<MaintenanceRequest[]> {
     return this.http
       .get<MaintenanceRequest[]>(this.apiUrl)
       .pipe(catchError(handleError('getMaintenanceRequests', [])));
   }
}
