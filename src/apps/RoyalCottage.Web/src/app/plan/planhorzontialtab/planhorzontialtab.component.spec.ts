import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanhorzontialtabComponent } from './planhorzontialtab.component';

describe('PlanhorzontialtabComponent', () => {
  let component: PlanhorzontialtabComponent;
  let fixture: ComponentFixture<PlanhorzontialtabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlanhorzontialtabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanhorzontialtabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
