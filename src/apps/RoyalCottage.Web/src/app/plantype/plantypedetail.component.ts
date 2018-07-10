import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { PlanType } from './Plantype';
import { PlanTypeRepository } from './plantype.repository';
import { UpdatePlanType } from './UpdatePlanType';
import { MessageService } from '../shared/message.service';

@Component({
  selector: 'plantypedetail',
  templateUrl: './plantypedetail.component.html'
})

export class PlanTypeDetailComponent implements OnInit {

  //planType: Observable<PlanType>;
  planType: PlanType;

  constructor(private router: Router, private route: ActivatedRoute, private planTypeRepository: PlanTypeRepository, private messageService: MessageService) {
    //this.planType = new Observable<PlanType>();
    this.planType = new PlanType();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.planTypeRepository.getPlanType(params['id']).subscribe(planType => {
          this.planType = this.resolveEditData(planType);
        });
      }

    });
    this.messageService.clearSuccess();
    this.messageService.clearFailure();
  }

  resolveEditData(d) {
    for (var key in d) {
      if (key == "data") {
        return JSON.parse(JSON.stringify(<PlanType>d[key]));
      }
    }
  }
  onSubmit() {
    let updatePlanType = <UpdatePlanType>JSON.parse(JSON.stringify(this.planType));
    this.planTypeRepository.updatePlanType(updatePlanType);
    this.router.navigate(['listplantype']);
  }
}


