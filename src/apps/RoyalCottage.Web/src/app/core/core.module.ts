import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavMenuComponent } from './navmenu.component';

@NgModule({
  imports: [CommonModule, RouterModule, NgbModule],
  exports: [NavMenuComponent, CommonModule, RouterModule, NgbModule],
  declarations: [NavMenuComponent],
  providers: []
})
export class CoreModule { };
