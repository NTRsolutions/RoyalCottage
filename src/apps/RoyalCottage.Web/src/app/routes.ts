import { Routes } from '@angular/router';
import { CreatePlanComponent } from './plan/createplan.component';
import { ListPlanComponent } from './plan/listplan.component';
import { PlanDetailComponent } from './plan/plandetail.component';
import { CreatePlanTypeComponent } from './plantype/createplantype.component';
import { ListPlanTypeComponent } from './plantype/listplantype.component';
import { PlanTypeDetailComponent } from './plantype/plantypedetail.component';
import { EligibleEmployeesComponent } from './eligibleemployees/eligibleemployees.component';
import { PlanViewComponent } from './plan/planview.component';
import { LoginComponent } from './login/login.component';
import { Ng2smarttableComponent } from './shared/grid/ng2smarttable/ng2smarttable.component';
import { CreateCTCBreakUpComponent } from './CTCBreakUpConfiguration/createCTCBreakUp.component';
import { PlanhorzontialtabComponent } from './plan/planhorzontialtab/planhorzontialtab.component';
import { PlantypehorzontialtabComponent } from './plantype/plantypehorzontialtab/plantypehorzontialtab.component';
import { SettingsTabComponent } from './settings/tab/settingstab.component';

export const appRoutes: Routes = [
  //{ path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '', redirectTo: '/planhorzontialtab', pathMatch: 'full' },
  { path: 'createplan', component: CreatePlanComponent },
  { path: 'listplan', component: ListPlanComponent },
  { path: 'plandetail/:id', component: PlanDetailComponent },
  { path: 'createplantype', component: CreatePlanTypeComponent },
  { path: 'listplantype', component: ListPlanTypeComponent },
  { path: 'plantypedetail/:id', component: PlanTypeDetailComponent },
  { path: 'eligibleemployees', component: EligibleEmployeesComponent },
  { path: 'ng2smarttable', component: Ng2smarttableComponent },
  { path: 'planview', component: PlanViewComponent },
  { path: 'login', component: LoginComponent },
  { path: 'createCTCBreakUp', component: CreateCTCBreakUpComponent },
  { path: 'planhorzontialtab', component: PlanhorzontialtabComponent },
  { path: 'plantypehorzontialtab', component: PlantypehorzontialtabComponent },
  { path: 'settings', component: SettingsTabComponent }
];
