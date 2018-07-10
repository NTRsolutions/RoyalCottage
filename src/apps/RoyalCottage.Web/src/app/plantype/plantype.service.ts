import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { PlanType } from './Plantype';
import { CreatePlanType } from './CreatePlantype';
import { UpdatePlanType } from './UpdatePlanType';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'        
    })
};


@Injectable()
export class PlanTypeService {

    private baseUrl: string;
    

  constructor(private http: HttpClient) {
        this.baseUrl = 'http://localhost:52198/api/';
    }

    
  getPlanTypes(): Observable<PlanType[]> {
    return this.http.get<PlanType[]>(this.baseUrl +'PlanTypes');
        
    }

  getPlanType(id: string){
    return this.http.get(this.baseUrl + 'PlanTypes' + '/' + id);
  }
    createPlanType(planType: CreatePlanType) {
      return this.http.post(this.baseUrl + 'PlanTypes', JSON.stringify(planType), httpOptions);
       
    }

  updatePlanType(planType: UpdatePlanType) {
    return this.http.put(this.baseUrl + 'PlanTypes', JSON.stringify(planType), httpOptions);
    }

  removePlanType(planTypeId: string) {
    return this.http.delete(this.baseUrl + 'PlanTypes' + '/' + planTypeId);
    }
   
}
