import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';

import { User } from './user';
import * as mockUsers from 'api/mock-users.json';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  constructor() {}

  /**
   * Creates the in memory database
   */
  public createDb(): {[key: string]: {id: number}[]} {
    const users: User[] = mockUsers.users;
    return { users };
  }

  public genId(resource: {id: number}[]): number {
    return resource.length > 0 ? Math.max(...resource.map((user) => user.id)) + 1 : 1;
  }
}
