import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PlanType } from './Plantype';
import { PlanTypeRepository } from './plantype.repository';
import { PlanTypeModule } from './plantype.module';
import { Router } from '@angular/router';
import { isString, isNullOrUndefined } from 'util';
import { Alert } from 'selenium-webdriver';

@Component({
  selector: 'listplantype',
  templateUrl: './listplantype.component.html',
  styleUrls: ['./listplantype.component.css']
})

export class ListPlanTypeComponent implements OnInit {

  PlanTypes: Observable<PlanType[]>
  error: string;

  constructor(private planTypeRepository: PlanTypeRepository, private router: Router) {
    this.PlanTypes = new Observable<PlanType[]>();

  }

  ngOnInit(): void {
    this.planTypeRepository.getPlanTypes();
    this.PlanTypes = this.planTypeRepository.PlanTypes;
  }

  onEdit(id: string): void {
    this.router.navigate(['plantypedetail', id]);
  }


  onDelete(id: string, name: string): void {

    if (window.confirm("Are you sure to delete " + name)) {
      this.planTypeRepository.removePlanType(id);
      this.PlanTypes = this.planTypeRepository.PlanTypes;
    }

  }

}
