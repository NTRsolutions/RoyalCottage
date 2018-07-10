import { NgModule } from '@angular/core';
import { EligibleEmployeesComponent } from './eligibleemployees.component';
import { EligibleemployeesService } from './eligibleemployees.service';
import { MessageService } from './message.service';
import { EligibleemployeesRepository } from './eligibleemployees.repository';
import { CoreModule } from '../core/core.module';
import { CwbAppModule } from '../cwbapp.module';
import { HttpModule } from '@angular/http';

@NgModule({
  imports: [],
  declarations: [],
  exports: [],
  providers: [EligibleemployeesService, MessageService, EligibleemployeesRepository]
})
export class EligibleemployeesModule { };
