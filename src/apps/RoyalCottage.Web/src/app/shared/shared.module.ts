import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MessageService } from './message.service';
import { MessagesComponent } from './messages.component';
import { Ng2smarttableComponent } from './grid/ng2smarttable/ng2smarttable.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';

@NgModule({
  imports: [CommonModule, RouterModule, Ng2SmartTableModule],
  exports: [MessagesComponent,CommonModule, RouterModule],
  declarations: [MessagesComponent, Ng2smarttableComponent],
  providers: [MessageService]
})
export class SharedModule { };
