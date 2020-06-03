import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantPageListAgreementsComponent } from './tenant-page-list-agreements.component';

describe('TenantPageListAgreementsComponent', () => {
  let component: TenantPageListAgreementsComponent;
  let fixture: ComponentFixture<TenantPageListAgreementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantPageListAgreementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantPageListAgreementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
