import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerPageListAgreementsComponent } from './manager-page-list-agreements.component';

describe('ManagerPageListAgreementsComponent', () => {
  let component: ManagerPageListAgreementsComponent;
  let fixture: ComponentFixture<ManagerPageListAgreementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagerPageListAgreementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerPageListAgreementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
