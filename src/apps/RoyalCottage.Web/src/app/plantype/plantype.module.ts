import { NgModule } from '@angular/core';
import { CreatePlanTypeComponent } from './createplantype.component';
import { ListPlanTypeComponent } from './listplantype.component';
import { PlanTypeDetailComponent } from './plantypedetail.component';
import { PlanTypeService } from './plantype.service';
import { PlanTypeRepository } from './plantype.repository';
import {CoreModule} from '../core/core.module';
import { CwbAppModule } from '../cwbapp.module';


@NgModule({
  imports: [],
  declarations: [],
  exports: [],
  providers: [PlanTypeService, PlanTypeRepository]
})
export class PlanTypeModule { };
