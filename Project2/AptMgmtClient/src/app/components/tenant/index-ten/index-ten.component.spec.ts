import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexTenComponent } from './index-ten.component';

describe('IndexTenComponent', () => {
  let component: IndexTenComponent;
  let fixture: ComponentFixture<IndexTenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndexTenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexTenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
