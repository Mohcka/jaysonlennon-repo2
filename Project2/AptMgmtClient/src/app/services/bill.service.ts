import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GenericRest } from './generic-rest.service';
import { ApiBase } from 'src/ApiBase';

@Injectable({
  providedIn: 'root',
})
export class BillService extends GenericRest<any> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'bill');
  }
}
