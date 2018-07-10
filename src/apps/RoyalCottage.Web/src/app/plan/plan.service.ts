import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import { Plan } from './Plan';
import { CreatePlan } from './CreatePlan';
import { UpdatePlan } from './UpdatePlan';
import { ExcludedEmployee } from './ExcludedEmployee';
import { BusinessRules } from '../eligibleemployees/eligiblebusinessrules';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};


@Injectable()
export class PlanService {

  private baseUrl: string;
 

  constructor(private http: HttpClient) {
    this.baseUrl = 'http://localhost:52198/api/';
  }


  getPlans(): Observable<Plan[]> {
    return this.http.get<Plan[]>(this.baseUrl +'Plans');

  }


  getPlan(id: string): Observable<Plan> {
    return this.http.get<Plan>(this.baseUrl + 'Plans' + '/' + id);

  }

  createPlan(plan: CreatePlan) {
    return this.http.post(this.baseUrl + 'Plans', JSON.stringify(plan), httpOptions);

  }

  updatePlan(plan: UpdatePlan) {
    return this.http.put(this.baseUrl + 'Plans', JSON.stringify(plan), httpOptions);
  }

  updateSubDoc(planId: string, excludedemployee : ExcludedEmployee) {
    return this.http.post(this.baseUrl + 'Plans/' + planId + '/ExcludedEmployees', JSON.stringify(excludedemployee), httpOptions);
  }

  updateBusinessRulesSubDoc(planId: string, saveBusinesRules: BusinessRules) {
    return this.http.post(this.baseUrl + 'Plans/' + planId + '/BusinessRules', JSON.stringify(saveBusinesRules), httpOptions);
  }

  removePlan(planId: string) {
    return this.http.delete(this.baseUrl + 'Plans' + '/' + planId);
  }



}
