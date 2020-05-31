import { HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';

/**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
export function handleError<T>(operation = 'operation', result?: T) {
  return (error: HttpErrorResponse): Observable<T> => {
    if (error === null || error === undefined) {
      console.error(`${operation} failed: An unknown error occurred.`);
    } else {
      console.error(`${operation} failed (code ${error.status}): ${error.message}`);
    }
    // Let the app keep running by returning a valid result.
    return of(result as T);
  };
}
