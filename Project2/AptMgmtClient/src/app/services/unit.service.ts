import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Unit } from '../model/unit';
import { ApiBase } from 'src/ApiBase';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) { }

  public getUnits(): Observable<Unit[]> {
    return this.http
      .get<Unit[]>(ApiBase.url() + 'Units')
      .pipe(catchError(handleError<Unit[]>('unit.service(getUnits)', [])));
  }

  public getUnitById(id: number): Observable<Unit> {
    return this.http
      .get<Unit>(ApiBase.url() + `Unit/${id}`)
      .pipe(catchError(handleError<null>('unit.service(getUnitById)')));
  }

  public updateUnit(tenant: Unit): Observable<Unit> {
    return this.http.post<Unit>(ApiBase.url() + 'Unit', tenant, this.httpOptions)
      .pipe(
        catchError(handleError<Unit>('tenant.service(updateUnit)'))
      );
  }
}
