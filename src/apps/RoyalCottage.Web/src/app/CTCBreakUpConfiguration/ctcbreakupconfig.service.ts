import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import { CreateCTCBreakup } from './CreateCTCBreakup';
//import { UpdatePlan } from './UpdatePlan';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};


@Injectable()
export class CtcBreakUpConfigService {

  private baseUrl: string;


  constructor(private http: HttpClient) {
    // Need to change this according to current project
    this.baseUrl = 'http://localhost:51098/CTCBreakUpConfiguration/';         // Need to change this
  }

  getCTCConfigs(): Observable<CreateCTCBreakup[]> {
    return this.http.get<CreateCTCBreakup[]>(this.baseUrl + 'Get');
  }


  getCTCConfig(id: string): Observable<CreateCTCBreakup> {
    return this.http.get<CreateCTCBreakup>(this.baseUrl + 'Get' + '/' + id);
  }

  createCTCBreakUp(param: CreateCTCBreakup) {
    return this.http.post(this.baseUrl + 'Post', JSON.stringify(param), httpOptions);
  }

  //updateCTCBreakUp(plan: CreateCTCBreakup) {
  //  return this.http.put(this.baseUrl + 'UpdateCTCBreakUpConfig', JSON.stringify(plan), httpOptions);   // Need to add method to Update   
  //}

  //removeCTCBreakpConfig(planId: string) {
  //  return this.http.delete(this.baseUrl + 'DeletePlan' + '/' + planId);          // Need to add method to Update
  //}
}
