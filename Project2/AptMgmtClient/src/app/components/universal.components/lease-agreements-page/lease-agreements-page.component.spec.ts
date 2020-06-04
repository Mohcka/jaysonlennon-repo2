import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaseAgreementsOageComponent } from './lease-agreements-page.component';

describe('LeaseAgreementsOageComponent', () => {
  let component: LeaseAgreementsOageComponent;
  let fixture: ComponentFixture<LeaseAgreementsOageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeaseAgreementsOageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaseAgreementsOageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
