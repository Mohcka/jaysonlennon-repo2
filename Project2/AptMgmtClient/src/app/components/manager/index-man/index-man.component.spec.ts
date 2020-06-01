import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexManComponent } from './index-man.component';

describe('IndexManComponent', () => {
  let component: IndexManComponent;
  let fixture: ComponentFixture<IndexManComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndexManComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexManComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
