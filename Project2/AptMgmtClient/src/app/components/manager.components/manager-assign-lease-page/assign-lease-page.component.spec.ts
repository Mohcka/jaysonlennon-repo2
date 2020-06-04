import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignLeasePageComponent } from './assign-lease-page.component';

describe('AssignLeasePageComponent', () => {
  let component: AssignLeasePageComponent;
  let fixture: ComponentFixture<AssignLeasePageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignLeasePageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignLeasePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
