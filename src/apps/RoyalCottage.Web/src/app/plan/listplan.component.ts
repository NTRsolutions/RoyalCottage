import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { Plan } from './Plan';
import { PlanRepository } from './plan.repository'
import { MessageService } from '../shared/message.service';

@Component({
    selector: 'listplan',
    templateUrl: './listplan.component.html',
    styleUrls: ['./listplan.component.css']
})

export class ListPlanComponent implements OnInit  {

    Plans: Observable<Plan[]>
       
  constructor(private planRepository: PlanRepository, private router: Router, private messageService: MessageService) {
        this.Plans = new Observable<Plan[]>();
    }

    
    ngOnInit(): void {
        this.planRepository.getPlans();
      this.Plans = this.planRepository.Plans;
      this.messageService.clearSuccess();
      this.messageService.clearFailure();
    }

    onEdit(id: string): void {
         this.router.navigate(['plandetail', id]);
    }

  onDelete(id: string, name: string): void {
    if (window.confirm("Are you sure to delete the Plan:" + name)) {
      this.planRepository.removePlan(id);
      this.planRepository.getPlans();
      this.Plans = this.planRepository.Plans;
    }
  }

}




