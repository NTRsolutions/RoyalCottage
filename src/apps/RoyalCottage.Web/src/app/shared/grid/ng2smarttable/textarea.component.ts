
import { Component, Input, OnInit } from '@angular/core';
import { ViewCell } from 'ng2-smart-table';


@Component({
  template: `
    <textarea rows="2" width="100%" (ngModelChange)="commentsfetch($event)">
</textarea>
  `,
})
export class ButtonRenderComponent implements OnInit {

  public renderValue;

  @Input() value;

  constructor() { }

  ngOnInit() {
    this.renderValue = this.value;
  }

  example() {
    alert(this.renderValue);
  }
  commentsfetch(event) {
    console.log(event);
  }

}
