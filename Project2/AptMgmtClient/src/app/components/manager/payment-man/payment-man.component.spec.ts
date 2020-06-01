import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentManComponent } from './payment-man.component';

describe('PaymentManComponent', () => {
  let component: PaymentManComponent;
  let fixture: ComponentFixture<PaymentManComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentManComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentManComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
