import { TestBed } from '@angular/core/testing';

import { TenantBillsService } from './tenant-home.service';

describe('TenantHomeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TenantBillsService = TestBed.get(TenantBillsService);
    expect(service).toBeTruthy();
  });
});
