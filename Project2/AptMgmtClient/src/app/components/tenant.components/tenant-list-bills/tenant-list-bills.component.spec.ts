import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantListBillsComponent } from './tenant-list-bills.component';

describe('TenantListBillsComponent', () => {
  let component: TenantListBillsComponent;
  let fixture: ComponentFixture<TenantListBillsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantListBillsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantListBillsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
