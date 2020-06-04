import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerCreateTenantPageComponent } from './manager-create-tenant-page.component';

describe('ManagerCreateTenantPageComponent', () => {
  let component: ManagerCreateTenantPageComponent;
  let fixture: ComponentFixture<ManagerCreateTenantPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagerCreateTenantPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerCreateTenantPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
