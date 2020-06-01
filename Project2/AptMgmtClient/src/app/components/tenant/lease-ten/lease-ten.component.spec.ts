import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaseTenComponent } from './lease-ten.component';

describe('LeaseTenComponent', () => {
  let component: LeaseTenComponent;
  let fixture: ComponentFixture<LeaseTenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeaseTenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaseTenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
