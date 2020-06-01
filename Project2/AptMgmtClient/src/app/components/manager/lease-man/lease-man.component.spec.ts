import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaseManComponent } from './lease-man.component';

describe('LeaseManComponent', () => {
  let component: LeaseManComponent;
  let fixture: ComponentFixture<LeaseManComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeaseManComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaseManComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
