import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantResourceUsageDetailComponent } from './tenant-resource-usage-detail.component';

describe('TenantResourceUsageDetailComponent', () => {
  let component: TenantResourceUsageDetailComponent;
  let fixture: ComponentFixture<TenantResourceUsageDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantResourceUsageDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantResourceUsageDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
