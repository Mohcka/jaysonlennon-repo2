import { ApiBase } from './../../ApiBase';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GenericRest } from './generic-rest.service';
import { Bill } from '../model/bill';

@Injectable({
  providedIn: 'root'
})

export class TenantBillsService extends GenericRest<Bill[]> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'Bills');
  }
}
