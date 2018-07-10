import {Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs/Rx';
import { Plan } from './Plan';
import { UpdatePlan } from './UpdatePlan';
import { PlanRepository } from './plan.repository';
import { MessageService } from '../shared/message.service';

@Component({
    selector: 'planview',
    templateUrl: './planview.component.html'
})
export class PlanViewComponent implements OnInit {

    plan: Observable<Plan>;
  

  constructor(private router: Router, private route: ActivatedRoute, private planRepository: PlanRepository, private messageService: MessageService) {
      
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            if (params['id']) {
                 this.planRepository.getPlan(params['id']).subscribe(plan => {
                 console.log(plan);
                //this.plan =of(JSON.parse(JSON.stringify(plan)));
                this.plan=Observable.create(observer => {observer.next(plan)});
                });
            }
        });
      this.messageService.clearSuccess();
      this.messageService.clearFailure();
    }

 

   

}
