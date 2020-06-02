import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerMaintenanceRequestListComponent } from './manager-maintenance-request-list.component';

describe('ManagerMaintenanceRequestListComponent', () => {
  let component: ManagerMaintenanceRequestListComponent;
  let fixture: ComponentFixture<ManagerMaintenanceRequestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagerMaintenanceRequestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerMaintenanceRequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
