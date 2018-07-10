import { Injectable } from '@angular/core';
//import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { map } from 'rxjs/operators';
import { CtcBreakUpConfigService } from './ctcbreakupconfig.service';
import { CreateCTCBreakup } from './CreateCTCBreakup';
import { MessageService } from '../shared/message.service'

@Injectable()
export class CTCBreakUpRepository {

  // variables
  private ctcConfigs: Observable<CreateCTCBreakup[]>
  private _ctcConfigs: BehaviorSubject<CreateCTCBreakup[]>;
  private dataStore: {
     ctcbreakupds: CreateCTCBreakup[]
  };
  private _ctcConfig: BehaviorSubject<CreateCTCBreakup>;


  // constructor starts
  constructor(private ctcBreakUpConfigService: CtcBreakUpConfigService, private messageService: MessageService) {
    this.dataStore = { ctcbreakupds: [] };
    this._ctcConfigs = <BehaviorSubject<CreateCTCBreakup[]>>new BehaviorSubject<CreateCTCBreakup[]>([]);
    this.ctcConfigs = this._ctcConfigs.asObservable();
    this._ctcConfig = <BehaviorSubject<CreateCTCBreakup>>{};
  }
  // constructor ends


  // properties
  get CTCConfigs() {
    return this._ctcConfigs.asObservable();
  }
  get CurrentCTCBreakUpConfig() {
    return this._ctcConfig;
  }
  // end properties


  getCTCConfigs(): void {
    this.ctcBreakUpConfigService.getCTCConfigs().subscribe(
      (data) => {
        this.resolveData(data);
      });
  }

  resolveData(data: CreateCTCBreakup[]) {
    this.dataStore.ctcbreakupds = [];
    data.forEach((ctcBreakupConfig) => {
      this.dataStore.ctcbreakupds.push(ctcBreakupConfig);
    });

    this._ctcConfigs.next(Object.assign({}, this.dataStore).ctcbreakupds);
  }

  getCTCConfig(id: string): Observable<CreateCTCBreakup> {
    return this.ctcBreakUpConfigService.getCTCConfig(id);
  }

  // CreateCTC call to service
  createCTC(ctcparam: CreateCTCBreakup) {
    this.ctcBreakUpConfigService.createCTCBreakUp(ctcparam).subscribe(
      () => { this.logSuccess(`CTC BreakUp Configured Successfully!`) },
      error => {
        this.handleError('createCTCBreakUp', error)
      });
  }

  //updatePlan(plan: UpdatePlan) {
  //  this.planService.updatePlan(plan).subscribe(
  //    () => {
  //      this.logSuccess(`Plan updated successfully!`);    // Update this when working on edit functionality
  //    },
  //    error => {
  //      this.handleError('updatePlan', error)
  //    });
  //}

  //removePlan(id: string) {
  //  this.planService.removePlan(id).
  //    subscribe(
  //      () => {
  //        this.logSuccess(`Plan deleted successfully!`)  // Update this when working on delete functionality
  //      },
  //      error => {
  //        this.handleError('remove', error)
  //      });
  //}

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
