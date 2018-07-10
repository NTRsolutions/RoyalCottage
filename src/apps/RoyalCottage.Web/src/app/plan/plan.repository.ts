import { Injectable } from '@angular/core';
//import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { map } from 'rxjs/operators';
import { Plan } from './Plan';
import { PlanService } from './plan.service';
import { CreatePlan } from './CreatePlan';
import { UpdatePlan } from './UpdatePlan';
import { Router } from '@angular/router';
import { MessageService } from '../shared/message.service'
import { ExcludedEmployee } from './ExcludedEmployee';
import { BusinessRules } from '../eligibleemployees/eligiblebusinessrules';

@Injectable()
export class PlanRepository {

  private plans: Observable<Plan[]>
  private _plans: BehaviorSubject<Plan[]>;
  private dataStore: {
    plans: Plan[]
  };
  private _plan: BehaviorSubject<Plan>;

  //, private router: Router
  constructor(private planService: PlanService, private messageService: MessageService) {
    this.dataStore = { plans: [] };
    this._plans = <BehaviorSubject<Plan[]>>new BehaviorSubject<Plan[]>([]);
    this.plans = this._plans.asObservable();
    this._plan = <BehaviorSubject<Plan>>{};

  }

  get Plans() {
    return this._plans.asObservable();
  }

  get CurrentPlan() {

    return this._plan;
  }

  getPlans(): void {
    this.planService.getPlans().subscribe(
      (data) => {

        this.resolveData(data);
      });
  }

  resolveData(data: any[]) {
    this.dataStore.plans = [];
    for (var key in data) {
      if (key == "dataList") {
        this.dataStore.plans = JSON.parse(JSON.stringify(<Plan[]>data[key]));

        this._plans.next(Object.assign({}, this.dataStore).plans);
      }
    }
  }

  getPlan(id: string): Observable<Plan> {
    return this.planService.getPlan(id);

  }

  createPlan(plan: CreatePlan) {
    this.planService.createPlan(plan).subscribe(
      () => { this.logSuccess(`Plan created successfully!`) },
      error => {
        this.handleError('createPlan', error)
      });
    //    this.dataStore.plans.push(data);
    //    this._plans.next(Object.assign({}, this.dataStore).plans);
    // });
  }

  updatePlan(plan: UpdatePlan) {
    this.planService.updatePlan(plan).subscribe(
      () => {
        this.logSuccess(`Plan updated successfully!`);
      //  this.router.navigate(['planhorzontialtab']);
      },
      error => {
        this.handleError('updatePlan', error)
      });
    //.subscribe(data => {
    //      this.dataStore.plans.forEach((t, i) => {
    //          if (t.EntityId === plan.entityId) {
    //              //this.dataStore.plans[i] = plan;

    //          }
    //      });

    //  this._plans.next(Object.assign({}, this.dataStore).plans);
    //  () => { this.logSuccess(`Plan updated successfully!`) }
    //},  error => { this.handleError('updateplan', error) });
  }

  updateSubDoc(planId: string, excludedemployee: ExcludedEmployee) {
    this.planService.updateSubDoc(planId, excludedemployee).subscribe(
      () => { this.logSuccess(`Employees excluded successfully!`) },
      error => {
        this.handleError('ShowEmployees', error)
      });
  }

  updateBusinessRulesSubDoc(planId: string, businessrules: BusinessRules) {
    this.planService.updateBusinessRulesSubDoc(planId, businessrules).subscribe(
      () => { this.logSuccess(`BusinessRules Created successfully!`) },
      error => {
        this.handleError('BusinessRules', error)
      });
  }
  
  removePlan(id: string) {
    this.planService.removePlan(id).
      subscribe(
      () => {
        this.logSuccess(`Plan deleted successfully!`)
      },
      error => {
        this.handleError('remove', error)
      });

    //subscribe(response => {
    //    this.dataStore.plans.forEach((t, i) => {
    //        if (t.EntityId === id) { this.dataStore.plans.splice(i, 1); }
    //    });

    //  this._plans.next(Object.assign({}, this.dataStore).plans);
    //  () => { this.logSuccess(`Plan deleted successfully!`) }
    //}, error => { this.handleError('remove', error) });
  }

  private handleError(operation, error) {

    this.logFailure(operation + ' failed: ' + error['error']);

  }

  private logFailure(message: string) {

    this.messageService.addFailure(message);
  }

  private logSuccess(message: string) {

    this.messageService.addSuccess(message);
  }

}
