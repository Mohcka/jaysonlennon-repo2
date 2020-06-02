import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceRequestFormComponent } from './maintenance-request-form.component';

describe('MaintenanceRequestFormComponent', () => {
  let component: MaintenanceRequestFormComponent;
  let fixture: ComponentFixture<MaintenanceRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenanceRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
