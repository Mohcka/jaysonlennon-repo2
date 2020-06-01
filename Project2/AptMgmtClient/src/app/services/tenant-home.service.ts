import { ApiBase } from './../../ApiBase';
import { Injectable } from '@angular/core';
import { TenantHome } from '../model/tenant-home';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GenericRest } from './generic-rest.service';

@Injectable({
  providedIn: 'root'
})

export class TenantHomeService extends GenericRest<TenantHome> {
  constructor(protected http: HttpClient) {
    super(http, ApiBase.url() + 'Tenant/Home');
  }
}
