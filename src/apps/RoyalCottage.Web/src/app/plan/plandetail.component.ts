import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { Plan } from './Plan';
import { UpdatePlan } from './UpdatePlan';
import { PlanRepository } from './plan.repository';
import { PlanType } from '../plantype/Plantype';
import { PlanTypeRepository } from '../plantype/plantype.repository';
import { MessageService } from '../shared/message.service';
import 'rxjs/add/observable/of';
import { Subscription } from 'rxjs/Subscription'
@Component({
  selector: 'plandetail',
  templateUrl: './plandetail.component.html'
})
export class PlanDetailComponent implements OnInit {

  plan: Plan;
  PlanTypes: Observable<PlanType[]>;
  plantypeslist: PlanType[];

  constructor(private router: Router, private route: ActivatedRoute, private planRepository: PlanRepository, private planTypeRepository: PlanTypeRepository, private messageService: MessageService) {
    this.plan = new Plan();
  }

  ngOnInit() {
    this.plantypeslist = [];
    this.planTypeRepository.getPlanTypes();
    this.PlanTypes = this.planTypeRepository.PlanTypes;

    this.PlanTypes.subscribe((posts) => {
      posts.forEach(post => {
        this.plantypeslist.push(post);
      });
    });

    this.route.params.subscribe(params => {
      if (params['id']) {
        this.planRepository.getPlan(params['id']).subscribe(plan => {
          //console.log(plan);
          this.plan = this.resolveEditData(plan);;
        });
      }
    });
  
    this.messageService.clearSuccess();
    this.messageService.clearFailure();
  }

  resolveEditData(d) {
    for (var key in d) {
      if (key == "data") {
        return JSON.parse(JSON.stringify(<Plan>d[key]));
      }
    }
  }

  onSubmit() {
    //console.log("Form Submitted!");
    let updatePlan = <UpdatePlan>JSON.parse(JSON.stringify(this.plan));
    this.planRepository.updatePlan(updatePlan);
    this.router.navigate(['planhorzontialtab']);
  }

}
