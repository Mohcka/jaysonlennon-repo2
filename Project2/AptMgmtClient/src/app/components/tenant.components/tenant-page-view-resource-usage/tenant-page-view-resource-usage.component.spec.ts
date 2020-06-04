import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantPageViewResourceUsageComponent } from './tenant-page-view-resource-usage.component';

describe('TenantPageViewResourceUsageComponent', () => {
  let component: TenantPageViewResourceUsageComponent;
  let fixture: ComponentFixture<TenantPageViewResourceUsageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantPageViewResourceUsageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantPageViewResourceUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
