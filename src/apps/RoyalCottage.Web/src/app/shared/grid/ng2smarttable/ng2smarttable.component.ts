import { Component, OnInit } from '@angular/core';
import { ButtonRenderComponent } from './textarea.component';

@Component({
  selector: 'app-ng2smarttable',
  templateUrl: './ng2smarttable.component.html',
  styleUrls: ['./ng2smarttable.component.css']
})
export class Ng2smarttableComponent implements OnInit {

//table column
  settings1 = {
    pager: {
      display: true,
      perPage: 3
    },
    selectMode: 'multi',
    actions: {
      delete: {
        confirmDelete: false,
      },
      add: {
        confirmCreate: false,
      },
      edit: {
        confirmSave: false,
      }
    },
    columns: {
      EmpID: {
        title: 'EmpID'
      },
      EmpName: {
        title: 'Emp Name'
      },
      DateofJoining: {
        title: 'Date of Joining'
      },
      HCC: {
        title: 'HCC'
      },
      Project: {
        title: 'Project'
      },
      Band: {
        title: 'Band'
      },
      Gender: {
        title: 'Gender'
      },
      VPPCode: {
        title: 'VPP Code'
      },
      CompanyName: {
        title: 'Company Name'
      },
      Location: {
        title: 'Location'
      },
      PerformanceCategory: {
        title: 'Performance Category'
      },
      CBFRole: {
        title: 'CBF Role'
      },
      CBFLevel: {
        title: 'CBF Level'
      },
      StatusofEmployee: {
        title: 'Status Of Employee'
      },
      CTC: {
        title: 'CTC'
      },
      RecommendedRange: {
        title: 'Recommended % Range'
      },
      Comments: {
        title: 'Comments',
        type: 'custom',
        renderComponent: ButtonRenderComponent

      },
    }
    //attr: {
    //  class: 'table table-bordered'
    //}
  };

  data = [
    {
      EmpID: "581",
      EmpName: "Amit Mukerji",
      DateofJoining: "10-04-2015",
      HCC: "HCC1",
      Project: "TUI",
      Grade: "B1",
      Gender: "Female",
      VPPCode: "JM",
      CompanyName: "Sonata",
      Location: "Hyderabad",
      PerformanceCategory: "Performance Category1",
      CBFRole: "Developer",
      CBFLevel: "CBF Level1",
      StatusofEmployee: "Inprogress",
      CTC: "7 Lacks",
      RecommendedRange: "5",
      //Comments: ' textarea'
    },
    {
      EmpID: "582",
      EmpName: "Amit",
      DateofJoining: "10-05-2015",
      HCC: "HCC2",
      Project: "Avery",
      Grade: "B2",
      Gender: "Male",
      VPPCode: "JM",
      CompanyName: "Sonata",
      Location: "Hyderabad",
      PerformanceCategory: "Performance Category1",
      CBFRole: "Developer",
      CBFLevel: "CBF Level2",
      StatusofEmployee: "Inprogress",
      CTC: "7.5 Lacks",
      RecommendedRange: "6",
    },
    // ... list of items
    {
      EmpID: "581",
      EmpName: "Bhanu",
      DateofJoining: "10-03-2015",
      HCC: "HCC4",
      Project: "Pepsico",
      Grade: "B2",
      Gender: "Male",
      VPPCode: "JM",
      CompanyName: "Sonata",
      Location: "Hyderabad",
      PerformanceCategory: "Performance Category1",
      CBFRole: "Developer",
      CBFLevel: "CBF Level1",
      StatusofEmployee: "Inprogress",
      CTC: "8 Lacks",
      RecommendedRange: "4",
    },
    {
      EmpID: "582",
      EmpName: "Amit Mukerji",
      DateofJoining: "10-04-2015",
      HCC: "HCC3",
      Project: "TUI",
      Grade: "B2",
      Gender: "Male",
      VPPCode: "JM",
      CompanyName: "Sonata",
      Location: "Bangalore",
      PerformanceCategory: "Performance Category1",
      CBFRole: "Developer",
      CBFLevel: "CBF Level2",
      StatusofEmployee: "Inprogress",
      CTC: "8 Lacks",
      RecommendedRange: "4",
    },
    {
      EmpID: "584",
      EmpName: "Amit Mukerji",
      DateofJoining: "11-01-2016",
      HCC: "HCC4",
      Project: "Qatera",
      Grade: "B3",
      Gender: "Female",
      VPPCode: "JM2",
      CompanyName: "Sonata",
      Location: "Bangalore",
      PerformanceCategory: "Performance Category1",
      CBFRole: "Developer",
      CBFLevel: "CBF Level2",
      StatusofEmployee: "Inprogress",
      CTC: "9 Lacks",
      RecommendedRange: "5",
    }
  ];

  // Table Columns
  constructor() { }

  ngOnInit() {

  }

}

