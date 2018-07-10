import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { CTCBreakUpRepository } from './ctcbreakupconfig.repository'
import { CreateCTCBreakup } from './CreateCTCBreakup'
import { MessageService } from '../shared/message.service';


@Component({
  selector: 'createCTCBreakUp',
  templateUrl: './createCTCBreakUp.component.html',
  styleUrls: ['./createCTCBreakUp.component.css']
})

export class CreateCTCBreakUpComponent implements OnInit {

  ctcbreakup: Observable<CreateCTCBreakup>;
  newctcbreakup: CreateCTCBreakup;
  constructor(private router: Router, private ctcbreakUpRepository: CTCBreakUpRepository, private messageService: MessageService) {
    this.newctcbreakup = <CreateCTCBreakup>{};
  }

  ngOnInit(): void {
    this.ctcbreakup = Observable.create(observer => { observer.next(this.newctcbreakup) });
    //this.planTypeRepository.getPlanTypes();
    //this.PlanTypes = this.planTypeRepository.PlanTypes;
    this.messageService.clearSuccess();
    this.messageService.clearFailure();
  }
  

  onSubmit() {
    this.ctcbreakup.subscribe(ctcbreakup => {
      let createctcbreakup = <CreateCTCBreakup>JSON.parse(JSON.stringify(ctcbreakup));
      this.ctcbreakUpRepository.createCTC(createctcbreakup);
      //this.router.navigate(['listplan']);
    });
  }
}
