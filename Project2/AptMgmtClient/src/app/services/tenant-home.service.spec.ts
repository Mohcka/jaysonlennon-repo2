import { TestBed } from '@angular/core/testing';

import { TenantHomeService } from './tenant-home.service';

describe('TenantHomeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TenantHomeService = TestBed.get(TenantHomeService);
    expect(service).toBeTruthy();
  });
});
