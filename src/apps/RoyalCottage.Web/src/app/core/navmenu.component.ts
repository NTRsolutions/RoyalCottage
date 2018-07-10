import { Component, OnInit } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbCollapse } from '@ng-bootstrap/ng-bootstrap';
import { Navigation } from './navigation';

@Component({
  selector: 'nav-menu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
  menus: Navigation[]
  isNavbarCollapsed = true;
  rlink: string;
  newApp = true;

  ngOnInit(): void {
    this.menus = <Navigation[]>[
      { id: 'Home', class: 'fa fa-calendar', title: 'Home', link: 'homepage', subItems: [], isParent: false },
      { id: 'plan', class: 'fa fa-calendar', title: 'Plan', link: 'planhorzontialtab', subItems: [], isParent: false },
      { id: 'plantype', class: 'fa fa-calendar-check-o', title: 'PlanType', link: 'plantypehorzontialtab', subItems: [], isParent: false },
      { id: 'settings', class: 'fa fa-cog', title: 'Settings', link: '/settings', subItems: [], isParent: false },
      { title: 'login', link: '/login', subItems: [], isParent: false }
    ];
    console.log(this.menus);
  }
  //{ id: 'plantype', class: 'fa fa-calendar-check-o', title: 'PlanType', link: 'plantypehorizontaltab', subItems: [], isParent: false },
      //{ class: 'fa fa-user-circle-o', title: 'Eligible Employees', link: '/eligibleemployees', subItems: [], isParent: false },
      //{ title: 'Ng2smartTable', link: '/ng2smarttable', subItems: [], isParent: false },
      //{ title: 'CTCBreakUpConfiguration', link: '/ctcbreakupconfiguration', subItems: [], isParent: false },
      // { title: 'Plan view', link: '/planview', subItems: [], isParent: false },

  constructor() { }
}
