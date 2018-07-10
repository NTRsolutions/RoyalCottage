import { NgModule } from '@angular/core';
import { CreatePlanComponent } from './createplan.component';
import { ListPlanComponent } from './listplan.component';
import { PlanDetailComponent } from './plandetail.component';
import { PlanService } from './plan.service';
import { PlanRepository } from './plan.repository';
import {CoreModule} from '../core/core.module';
import {CwbAppModule} from '../cwbapp.module';

@NgModule({
  imports: [],
  declarations: [],
  exports: [],
  providers: [PlanService, PlanRepository]
})
export class PlanModule { };
