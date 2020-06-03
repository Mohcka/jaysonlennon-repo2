import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantEditInfoComponent } from './tenant-edit-info.component';

describe('TenantEditInfoComponent', () => {
  let component: TenantEditInfoComponent;
  let fixture: ComponentFixture<TenantEditInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantEditInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantEditInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
