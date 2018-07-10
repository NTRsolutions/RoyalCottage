import { Component, Input, OnInit } from '@angular/core';
import { ViewCell } from 'ng2-smart-table';
import { EligibleEmployeesComponent } from './eligibleemployees.component';

import { Router } from '@angular/router';
import { EligibleemployeesRepository } from './eligibleemployees.repository';

@Component({
  selector: "textareacol",
  template: `
    <textarea rows="2" width="100%" #txtComments name="txtComments" (change)="commentsEntered(this, $event)">
    </textarea>
  `
})
export class ButtonRenderComponent implements OnInit {

  public renderValue;

  @Input() value;

  constructor() { }

  ngOnInit() {
    
    
  }

  clearComments(item) {
    this.value = this.renderValue = item.comments;
  }

  commentsEntered(item, event) {
    
    item.rowData.comments = event.target.value;
    this.value = event.target.value;

    //let eligibleemployeesrepository : EligibleemployeesRepository;
    //let router:  Router;

    //let saro = new EligibleEmployeesComponent(eligibleemployeesrepository, router);
    //saro.commentsEntered(item.target.value);


    //let index = this.selectedEmps.findIndex(x => x.employee_ID == item.rowData.employee_ID);
    //if (index != -1) {
    //  this.selectedEmps[index].comments = item.target.value;
    //}
  }
}
