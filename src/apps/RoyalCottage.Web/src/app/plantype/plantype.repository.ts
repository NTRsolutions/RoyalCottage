import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { map } from 'rxjs/operators';
import { PlanType } from './Plantype';
import { PlanTypeService } from './plantype.service';
import { CreatePlanType } from './CreatePlanType';
import { UpdatePlanType } from './UpdatePlanType';
import { MessageService } from '../shared/message.service';
import { SharedModule } from '../shared/shared.module';
import { Router } from '@angular/router';
import { Plan } from '../plan/Plan';

@Injectable()
export class PlanTypeRepository {

  private planTypes: Observable<PlanType[]>



  private _planTypes: BehaviorSubject<PlanType[]>;

  private planTypesOnEdit: Observable<PlanType>;
    private dataStore: {
     planTypes: PlanType[]
  };

    private _planType: BehaviorSubject<PlanType>;


  constructor(private planTypeService: PlanTypeService, private messageService: MessageService, private router: Router) {
    this.dataStore = { planTypes: [] };
        this._planTypes = <BehaviorSubject<PlanType[]>>new BehaviorSubject<PlanType[]>([]);
        this.planTypes = this._planTypes.asObservable();
        this._planType = <BehaviorSubject<PlanType>>{};
        
    }

    get PlanTypes() {
      return this._planTypes.asObservable();
    }
    get CurrentPlanType() {

      return this._planType;
    }
  
  getPlanTypes(): void {
      this.planTypeService.getPlanTypes().subscribe(
            (data) => {
                this.resolveData(data);
            });
  }


  getPlanType(id: string){
    return this.planTypeService.getPlanType(id);
  }


  resolveData(data: any[]) {
    for (var key in data) {
      if (key == "dataList") {
        this.dataStore.planTypes = JSON.parse(JSON.stringify(<PlanType[]>data[key]));
        this._planTypes.next(Object.assign({}, this.dataStore).planTypes);
      }
    }
  }

    createPlanType(planType: CreatePlanType) {
      this.planTypeService.createPlanType(planType).subscribe(
        () => {
          this.logSuccess(`PlanType created successfully!`);
          this.getPlanTypes();
          this.router.navigate(['listplantype']);
        },
        error => {
          this.handleError('createPlanType', error)
        });
    }

    updatePlanType(planType: UpdatePlanType) {
        this.planTypeService.updatePlanType(planType)
          .subscribe(
          () => {
            this.logSuccess(`Plantype updated successfully!`);
            this.router.navigate(['plantypehorzontialtab']);
          },
          //data => {
          //      this.dataStore.planTypes.forEach((t, i) => {
          //          if (t.EntityId === planType.entityId) {
          //          }
          //      });

          //      this._planTypes.next(Object.assign({}, this.dataStore).planTypes);
          //},
          error => {
            this.handleError('updatePlanType', error)
          });
    }

    removePlanType(id: string) {
      this.planTypeService.removePlanType(id).subscribe(
        () => {
          this.logSuccess(`Plantype deleted successfully!`),
          this.getPlanTypes();
        },
        error => {
          this.handleError('removePlanType', error)
        }

    );
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
