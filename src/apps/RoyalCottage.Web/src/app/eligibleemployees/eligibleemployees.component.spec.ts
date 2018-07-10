import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EligibleEmployeesComponent } from './eligibleemployees.component';

describe('EligibleEmployeesComponent', () => {
  let component: EligibleEmployeesComponent;
  let fixture: ComponentFixture<EligibleEmployeesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EligibleEmployeesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EligibleEmployeesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
