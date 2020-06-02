import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';

import { User } from '../model/user';
import * as mockUsers from 'api/mock-users.json';
import { Tenant } from '../model/tenant';
import * as mockTenants from 'api/Tenant/index.json';
import { MaintenanceRequest } from '../model/maintenance-request';
import * as mockMaintenance from 'api/Tenant/Maintenance.json';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  constructor() {}

  /**
   * Creates the in memory database
   */
  public createDb(): { [key: string]: { id: number }[] } {
    const users: User[] = mockUsers.users;
    const tenant: Tenant[] = mockTenants.tenants;
    //const maintenance: MaintenanceRequest[] = mockMaintenance.requests;
    return { users, tenant };
  }

  public genId(resource: { id: number }[]): number {
    return resource.length > 0
      ? Math.max(...resource.map((user) => user.id)) + 1
      : 1;
  }
}
