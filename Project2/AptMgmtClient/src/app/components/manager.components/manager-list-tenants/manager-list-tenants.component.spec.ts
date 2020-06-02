import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerListTenantsComponent } from './manager-list-tenants.component';

describe('TenantsComponent', () => {
  let component: ManagerListTenantsComponent;
  let fixture: ComponentFixture<ManagerListTenantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagerListTenantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerListTenantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
