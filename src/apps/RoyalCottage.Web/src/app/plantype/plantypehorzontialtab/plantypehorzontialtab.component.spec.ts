import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantypehorzontialtabComponent } from './plantypehorzontialtab.component';

describe('PlantypehorzontialtabComponent', () => {
  let component: PlantypehorzontialtabComponent;
  let fixture: ComponentFixture<PlantypehorzontialtabComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlantypehorzontialtabComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantypehorzontialtabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
