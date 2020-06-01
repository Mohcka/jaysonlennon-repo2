import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentTenComponent } from './payment-ten.component';

describe('PaymentTenComponent', () => {
  let component: PaymentTenComponent;
  let fixture: ComponentFixture<PaymentTenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentTenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentTenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
