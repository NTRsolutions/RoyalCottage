import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CoreModule } from "./core/core.module";
import { SharedModule } from "./shared/shared.module";
import { PlanModule } from "./plan/plan.module";
import { PlanTypeModule } from "./plantype/plantype.module";
import { SettingsModule } from "./settings/tab/settingstab.module";
import { CreatePlanComponent } from './plan/createplan.component';
import { ListPlanComponent } from './plan/listplan.component';
import { PlanDetailComponent } from './plan/plandetail.component';
import { CreatePlanTypeComponent } from './plantype/createplantype.component';
import { appRoutes } from './routes';
import { CwbAppComponent } from './cwbapp.component';
import { ListPlanTypeComponent } from './plantype/listplantype.component';
import { PlanTypeDetailComponent } from './plantype/plantypedetail.component';
import { EligibleEmployeesComponent } from './eligibleemployees/eligibleemployees.component';
import { EligibleemployeesModule } from "./eligibleemployees/eligibleemployees.module";
import { PlanViewComponent } from './plan/planview.component';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { CtcComponent } from './settings/ctc/ctc.component';
import { SettingsTabComponent } from './settings/tab/settingstab.component';
import { LoginComponent } from './login/login.component';
import { CreateCTCBreakUpComponent } from './CTCBreakUpConfiguration/createCTCBreakUp.component';
import { CTCBreakUpConfigModule } from "./CTCBreakUpConfiguration/ctcbreakupconfig.module";
import { PlanhorzontialtabComponent } from './plan/planhorzontialtab/planhorzontialtab.component';
import { PlantypehorzontialtabComponent } from './plantype/plantypehorzontialtab/plantypehorzontialtab.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ButtonRenderComponent } from './eligibleemployees/textarea.component';
import { HomepageComponent } from './homepage/homepage.component';


@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    SettingsModule,
    BsDatepickerModule.forRoot(),
    NgbModule,    
    ReactiveFormsModule,
    HttpClientModule,
    CoreModule,
    SharedModule,
    PlanModule,
    PlanTypeModule,
    EligibleemployeesModule,
    CTCBreakUpConfigModule,
    RouterModule.forRoot(appRoutes),
    Ng2SmartTableModule
  ],
  entryComponents: [ButtonRenderComponent],
  declarations: [
    CwbAppComponent,
    CreatePlanComponent,
    ListPlanComponent,
    PlanDetailComponent,
    CreatePlanTypeComponent,
    ListPlanTypeComponent,
    PlanTypeDetailComponent,
    EligibleEmployeesComponent,
    ButtonRenderComponent,
    PlanViewComponent,
    CtcComponent,
    SettingsTabComponent,
    LoginComponent,  
    PlanViewComponent,
    CreateCTCBreakUpComponent,
    PlanhorzontialtabComponent,
    PlantypehorzontialtabComponent,
    HomepageComponent
  ],
  exports: [FormsModule, ReactiveFormsModule, NgbModule, CoreModule, SharedModule, PlanModule, PlanTypeModule,
    EligibleemployeesModule, CTCBreakUpConfigModule
  ],
  providers: [],
  bootstrap: [CwbAppComponent]
})
export class CwbAppModule { }
