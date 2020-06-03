import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantPageBillPayComponent } from './tenant-page-bill-pay.component';

describe('TenantPageBillPayComponent', () => {
  let component: TenantPageBillPayComponent;
  let fixture: ComponentFixture<TenantPageBillPayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantPageBillPayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantPageBillPayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
