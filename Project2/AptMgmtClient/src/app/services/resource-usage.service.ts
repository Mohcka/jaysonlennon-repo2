import { MeteredResouceUsageEntry } from './../model/metered-resource-usage-entry';
import { ResourceUsageProjection } from './../model/resource-usage-projection';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { handleError } from 'src/utils/error-handling';
import { ApiBase } from 'src/ApiBase';
import { Resource } from 'src/enums/Resource';
import { Dictionary } from '../model/dictionary';

@Injectable({
  providedIn: 'root'
})
export class ResourceUsageService {

  constructor(protected http: HttpClient) { }

  public getUsageEntries(): Observable<Dictionary<MeteredResouceUsageEntry[]>> {

    return new Observable(observer => {
      this.http
        .get<MeteredResouceUsageEntry[]>(ApiBase.url() + 'DailyUsages')
        .pipe(
          catchError(
            handleError<null>('resource-usage.service(getUsageEntries)')
          )
        )
        .subscribe(entries => {
          const collection: Dictionary<MeteredResouceUsageEntry[]> = {};

          entries.forEach(entry => {
            const resourceType = Number(entry.resourceType);
            if (collection[resourceType] === undefined) {
              collection[resourceType] = [];
            }
            collection[resourceType].push(entry);
          });

          observer.next(collection);
          observer.complete();

        });
    });
  }

  public getUsageEntriesForResource(resource: Resource): Observable<MeteredResouceUsageEntry[]> {
    return this.http
      .get<MeteredResouceUsageEntry[]>(ApiBase.url() + `DailyUsage?resource=${resource}`)
      .pipe(
        catchError(
          handleError<MeteredResouceUsageEntry[]>('resource-usage.service(getUsageEntriesForResource)')
        )
      );
  }

  public getProjections(): Observable<ResourceUsageProjection[]> {
    return this.http
      .get<ResourceUsageProjection[]>(ApiBase.url() + `ResourceProjections`)
      .pipe(
        catchError(
          handleError<ResourceUsageProjection[]>('resource-usage.service(getProjections)')
        )
      );
  }

  public getProjectionForResource(resource: Resource): Observable<ResourceUsageProjection[]> {
    return this.http
      .get<ResourceUsageProjection[]>(ApiBase.url() + `ResourceProjections`)
      .pipe(
        catchError(
          handleError<ResourceUsageProjection[]>('resource-usage.service(getProjectionForResource)')
        )
      );
  }

}
