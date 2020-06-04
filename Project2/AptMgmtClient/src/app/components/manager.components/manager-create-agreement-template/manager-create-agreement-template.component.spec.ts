import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerCreateAgreementTempalteComponent } from './manager-create-agreement-template.component';

describe('ManagerCreateAgreementTempalteComponent', () => {
  let component: ManagerCreateAgreementTempalteComponent;
  let fixture: ComponentFixture<ManagerCreateAgreementTempalteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagerCreateAgreementTempalteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerCreateAgreementTempalteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
