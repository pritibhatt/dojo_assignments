import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RewiewComponent } from './rewiew.component';

describe('RewiewComponent', () => {
  let component: RewiewComponent;
  let fixture: ComponentFixture<RewiewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RewiewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RewiewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
