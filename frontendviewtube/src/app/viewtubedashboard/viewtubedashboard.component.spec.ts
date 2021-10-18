import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewtubedashboardComponent } from './viewtubedashboard.component';

describe('ViewtubedashboardComponent', () => {
  let component: ViewtubedashboardComponent;
  let fixture: ComponentFixture<ViewtubedashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewtubedashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewtubedashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
