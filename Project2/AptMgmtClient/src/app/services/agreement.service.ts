import { Injectable } from '@angular/core';
import { GenericRest } from './generic-rest.service';
import { Agreement } from '../model/agreement';
import { HttpClient } from '@angular/common/http';
import { ApiBase } from 'src/ApiBase';

@Injectable({
  providedIn: 'root',
})
export class AgreementService extends GenericRest<any> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'agreements');
  }
}
