import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

/**
 * A generic service that provides all the basic capabilities for
 * CRUD operations
 */
@Injectable()
export abstract class GenericRest<T> {
  constructor(protected http: HttpClient, protected apiUrl: string) {}

  public getAll(): Observable<T[]> {
    return this.http
      .get<T[]>(this.apiUrl)
      .pipe(catchError(handleError<T[]>('getAll', [])));
  }

  public getOne(id: number): Observable<T> {
    return this.http
      .get<T>(`${this.apiUrl}/${id}`)
      .pipe(catchError(handleError<T>('getResource', undefined)));
  }
}
