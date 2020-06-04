import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaseAgreementTextComponent } from './lease-agreement-text.component';

describe('LeaseAgreementTextComponent', () => {
  let component: LeaseAgreementTextComponent;
  let fixture: ComponentFixture<LeaseAgreementTextComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeaseAgreementTextComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaseAgreementTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
