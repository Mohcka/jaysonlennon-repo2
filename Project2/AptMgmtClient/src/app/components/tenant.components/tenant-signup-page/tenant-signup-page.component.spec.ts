import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantSignupPageComponent } from './tenant-signup-page.component';

describe('TenantSignupPageComponent', () => {
  let component: TenantSignupPageComponent;
  let fixture: ComponentFixture<TenantSignupPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantSignupPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantSignupPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
