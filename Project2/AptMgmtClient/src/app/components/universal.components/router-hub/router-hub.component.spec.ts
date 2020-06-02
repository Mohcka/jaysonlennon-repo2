import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RouterHubComponent } from './router-hub.component';

describe('RouterHubComponent', () => {
  let component: RouterHubComponent;
  let fixture: ComponentFixture<RouterHubComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RouterHubComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RouterHubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
