import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { PlanRepository } from './plan.repository'
import { CreatePlan } from './CreatePlan'
import { Plan } from './Plan';
import { PlanType } from '../plantype/Plantype';
import { PlanTypeRepository } from '../plantype/plantype.repository';
import { MessageService } from '../shared/message.service';


@Component({
  selector: 'createplan',
  templateUrl: './createplan.component.html',
  styleUrls: ['./createplan.component.css']
})

export class CreatePlanComponent implements OnInit {

  plan: Observable<Plan>;
  newPlan: Plan;
  PlanTypes: Observable<PlanType[]>
  constructor(private router: Router, private planRepository: PlanRepository, private planTypeRepository: PlanTypeRepository, private messageService: MessageService) {
    this.newPlan = <Plan>{};

  }

  ngOnInit(): void {
    this.plan = Observable.create(observer => { observer.next(this.newPlan) });
    this.planTypeRepository.getPlanTypes();
    this.PlanTypes = this.planTypeRepository.PlanTypes;
    this.messageService.clearSuccess();
    this.messageService.clearFailure();
  }



  onSubmit() {
    this.plan.subscribe(plan => {
      let createPlan = <CreatePlan>JSON.parse(JSON.stringify(plan));
      this.planRepository.createPlan(createPlan);
      this.router.navigate(['listplan']);
    });
  }


}


