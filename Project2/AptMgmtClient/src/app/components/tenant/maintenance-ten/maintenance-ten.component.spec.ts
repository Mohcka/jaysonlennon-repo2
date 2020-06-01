import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceTenComponent } from './maintenance-ten.component';

describe('MaintenanceTenComponent', () => {
  let component: MaintenanceTenComponent;
  let fixture: ComponentFixture<MaintenanceTenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaintenanceTenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceTenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
