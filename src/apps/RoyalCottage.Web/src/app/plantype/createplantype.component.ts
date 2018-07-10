import { Component, OnInit, Directive } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { PlanTypeRepository } from './plantype.repository'
import { CreatePlanType } from './CreatePlanType'
import { PlanType } from './PlanType';
import { MessageService } from '../shared/message.service';


@Component({
  selector: 'createplantype',
  templateUrl: './createplantype.component.html',
  styleUrls: ['./createplantype.component.css']
})

export class CreatePlanTypeComponent implements OnInit {

  planType: Observable<PlanType>;
  newPlanType: PlanType;

  constructor(private router: Router, private planTypeRepository: PlanTypeRepository, private messageService: MessageService) {
    this.newPlanType = <PlanType>{};
  }

  ngOnInit(): void {
    this.planType = Observable.create(observer => { observer.next(this.newPlanType) });
    this.messageService.clearSuccess();
    this.messageService.clearFailure();
  }


    onSubmit() {
      this.planType.subscribe(plan => {
        //console.log(JSON.stringify(plan));
          let createPlanType = <CreatePlanType>JSON.parse(JSON.stringify(plan));
             this.planTypeRepository.createPlanType(createPlanType);
             //this.router.navigate(['listplantype']);
            });
    }
    
}
