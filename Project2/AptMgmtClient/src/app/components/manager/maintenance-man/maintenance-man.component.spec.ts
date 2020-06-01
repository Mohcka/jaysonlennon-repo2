import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceManComponent } from './maintenance-man.component';

describe('MaintenanceManComponent', () => {
  let component: MaintenanceManComponent;
  let fixture: ComponentFixture<MaintenanceManComponent>;
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenanceManComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceManComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
