import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';

/**
 * A generic service that provides all the basic capabilities for
 * CRUD operations
 */
@Injectable()
export abstract class GenericRest<T> {
  protected httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

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

  public update(entity: T): Observable<any> {
    return this.http
      .put(this.apiUrl, entity, this.httpOptions)
      .pipe(catchError(handleError<any>('updateResource', undefined)));
  }

  public add(entity: T): Observable<T> {
    return this.http
      .post<T>(this.apiUrl, entity, this.httpOptions)
      .pipe(catchError(handleError<T>('addResource', undefined)));
  }

  /**
   * Send a request to the server to delete the specified entity
   * @param entity Either the entity or the entity's id
   */
  public delete(entity: T | number): Observable<T> {
    const id = typeof entity === 'number' ? entity : (entity as any).id;
    const url = `${this.apiUrl}/${id}`;

    return this.http
      .delete<T>(url, this.httpOptions)
      .pipe(catchError(handleError<T>('deleteResource', undefined)));
  }
}
