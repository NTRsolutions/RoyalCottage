import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Eligibleemployees } from './Eligibleemployees';
import { Router } from '@angular/router';
import { EligibleemployeesRepository } from './eligibleemployees.repository';
import { EmployeeDetails } from './employeedetails';
import { LocationDetails } from './locationdetails';
import { RoleDetails } from './roledetails';
import { HCCDetails } from './hccdetails';
import { GradeDetails } from './gradedetails';
import { LevelDetails } from './leveldetails';
import { GenderDetails } from './genderdetails';
import { Options } from './options';
import { flatten, forEach } from '@angular/router/src/utils/collection';
import { NgForm } from '@angular/forms';
import { Location } from '@angular/common';
import { CompanyDetails } from './companydetails';
import { StatusDetails } from './statusdetails';
import { ProjectDetails } from './projectdetails';
import { BusinessRulesLevelOne } from './eligiblebusinessruleslevelone';
import { BusinessRulesLevelTwo } from './eligiblebusinessrulesleveltwo';
import { BusinessRulesLevelThree } from './eligiblebusinessruleslevelthree';
//import { Router, ActivatedRoute } from '@angular/router';
import { ExcludedEmployee } from '../plan/ExcludedEmployee';
import { LocalDataSource } from 'ng2-smart-table';
import { ButtonRenderComponent } from './textarea.component';
import { PlanRepository } from '../plan/plan.repository';
import { UpdatePlan } from '../plan/UpdatePlan';
import { BusinessRules } from './eligiblebusinessrules';

@Component({
  selector: 'eligibleemployees',
  templateUrl: './eligibleemployees.component.html',
  styleUrls: ['./eligibleemployees.component.css']
})
export class EligibleEmployeesComponent implements OnInit {
  selectedhcc: any;
  isValidFormSubmitted = false;
  masterdata: Observable<Eligibleemployees[]>;
  locationslst: Observable<LocationDetails[]>;
  locations: LocationDetails[];
  //dolocations: LocationDetails;
  employeeslst: Observable<EmployeeDetails[]>;
  employees: EmployeeDetails[];
  roles: RoleDetails[];
  doroleslst: RoleDetails;
  roleslst: Observable<RoleDetails[]>;
  hccdetail: HCCDetails[];
  dohccdetaillst: HCCDetails;
  hccdetaillst: Observable<HCCDetails[]>;
  grades: GradeDetails[];
  dogradeslst: GradeDetails;
  gradeslst: Observable<GradeDetails[]>;
  levelslst: Observable<LevelDetails[]>;
  levels: LevelDetails[];
  dolevelslst: LevelDetails;
  genders: GenderDetails[];
  genderslst: Observable<GenderDetails[]>;
  company: CompanyDetails[];
  companylst: Observable<CompanyDetails[]>;
  status: StatusDetails[];
  statuslst: Observable<StatusDetails[]>;
  projects: ProjectDetails[];
  projectslst: Observable<ProjectDetails[]>;
  Filteredemployees: Observable<EmployeeDetails[]>;
  option: Options[];
  showExcludeemployees: EmployeeDetails[];
  showemployees: Observable<EmployeeDetails>;
  offshore: boolean = true;
  display = 'none';
  excludeempID: string;
  excludeempComments: string;
  excludeFlag: boolean;
  str: string;
  toggleDisplayState: boolean = false;
  toggleDisplayState1: boolean = false;
  editRow: any = '';
  // Table Columns
  TableData: any = [];
  ShowEditTable: Boolean = false;
  EditRowID: any = '';
  multiselectedparams: string;
  selectedparams: HCCDetails[];
  alllocations: LocationDetails[];
  selectedhccbl: HCCDetails[];
  TableDataLevels: LevelDetails[];
  getrolesbyhcc: HCCDetails[];
  isgrade: boolean = false;
  isonelevelsselected: boolean = false;
  istwolevelsselected: boolean = false;
  isthreelevelsselected: boolean = false;
  isgetallgrades: boolean = false;
  accordianfalse: boolean = true;
  getrolesbyhcclevelone: BusinessRulesLevelOne[];
  getrolesbyhcclevetwo: BusinessRulesLevelTwo[];
  getrolesbyhcclevelthree: BusinessRulesLevelThree[];
  businessrules:BusinessRules[];
  allrolesarray: RoleDetails[];
  allgradesarray:GradeDetails[];
  // currentSelection: CompanyName;
  selectedEmps: ExcludedEmployee[];
  source: LocalDataSource;
  jsondata: EmployeeDetails[];
  updateplanSubDoc: UpdatePlan;
  planId: string;
  ishccselected: boolean = false;
  isroleselected: boolean = false;
  islevelselected: boolean = false;
  isrolegrade: boolean = false;
  isgradeselected: boolean = false;
  isgenderselected: boolean = false;
  filteredhcc: EmployeeDetails[];
  filteredcbfroles: EmployeeDetails[];
  filteredlevels: EmployeeDetails[];
  filteredgrades: EmployeeDetails[];
  filteredgender: EmployeeDetails[];
  settings1 = {
    mode: 'inline', // inline|external|click-to-edit
    selectMode: 'multi',  // single|multi
    pager: {
      display: true,
      perPage: 10
    },
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
      employeE_ID: {
        title: 'EmpID'
      },
      employeE_NAME: {
        title: 'Emp Name'
      },
      employeE_DOJ: {
        title: 'Date of Joining'
      },
      employeE_ORGANIZATION: {
        title: 'HCC'
      },
      projecT_NAME: {
        title: 'Project'
      },
      grade: {
        title: 'Band'
      },
      gender: {
        title: 'Gender'
      },
      vppCode: {
        title: 'VPP Code'
      },
      company_Name: {
        title: 'Company Name'
      },
      homE_LOCATION: {
        title: 'Location'
      },
      perfCategory: {
        title: 'Performance Category'
      },
      emP_ROLE: {
        title: 'CBF Role'
      },
      emP_ROLE_LEVEL: {
        title: 'CBF Level'
      },
      status: {
        title: 'Status Of Employee'
      },
      CTC: {
        title: 'CTC'
      },
      RecommendedRange: {
        title: 'Recommended % Range'
      },
      comments: {
        title: 'Comments',
        type: 'custom',
        renderComponent: ButtonRenderComponent,
        selector: 'textareacol'
      },
    }
    //attr: {
    //  class: 'table table-bordered'
    //}
  };


  constructor(private eligibleemployeesrepository: EligibleemployeesRepository, private planRepository: PlanRepository, private router: Router) {
    this.masterdata = new Observable<Eligibleemployees[]>();
    this.locations = [];
    this.locationslst = new Observable<LocationDetails[]>();
    this.employees = [];
    this.employeeslst = new Observable<EmployeeDetails[]>();
    this.roles = [];
    this.roleslst = new Observable<RoleDetails[]>();
    this.hccdetail = [];
    this.hccdetaillst = new Observable<HCCDetails[]>();
    this.grades = [];
    this.gradeslst = new Observable<GradeDetails[]>();
    this.levels = [];
    this.levelslst = new Observable<LevelDetails[]>();
    this.genders = [];;
    this.genderslst = new Observable<GenderDetails[]>();
    this.status = [];
    this.statuslst = new Observable<StatusDetails[]>();
    this.projects = [];
    this.projectslst = new Observable<ProjectDetails[]>();
    this.company = [];
    this.companylst = new Observable<CompanyDetails[]>();
    this.Filteredemployees = new Observable<EmployeeDetails[]>();
    this.selectedparams = [];
    this.selectedhccbl = [];
    this.TableDataLevels = [];
    this.getrolesbyhcclevelone = [];
    this.getrolesbyhcclevetwo = [];
    this.getrolesbyhcclevelthree = [];
    this.allrolesarray = [];
    this.allgradesarray = [];
    this.selectedEmps = [];
    this.source = new LocalDataSource();
    this.planId = "1cd56b83-2e20-47bf-bc9d-1c969462c855"; //Plan ID
    this.businessrules = [];
    this.jsondata = [];
    this.filteredhcc = [];
    this.filteredcbfroles = [];
    this.filteredlevels = [];
    this.filteredgrades = [];
    this.filteredgender = [];
    //Table Data Array
    this.TableData =
      {
        "Cat": [
          { id: '1', name: 'Cat1' },
          { id: '2', name: 'Cat2' },
          { id: '3', name: 'Cat3' },
          { id: '3', name: 'Cat4' }
        ]
      }
  }

  Edit(val) {
    this.EditRowID = val;
  }


  toggleDisplay(form: NgForm) {
    this.selectedhccbl = [];
    let multiselectedhcc: any[] = form.controls['hccdetails'].value;
    let multiselectedcbflevels: any[] = form.controls['leveldetails'].value;
    let multiselectedcbfroles: any[] = form.controls['roledetails'].value;
    if (multiselectedhcc == undefined || multiselectedcbflevels == undefined || multiselectedcbfroles == undefined
      || multiselectedhcc.length == 0 || multiselectedcbflevels.length == 0 || multiselectedcbfroles.length == 0) {
      alert('Please select atleast One HCC, One CBF Role, and One CCBF Level');

      return false;
    }
    else if (multiselectedhcc.length > 0) {
      for (var i = 0; i < multiselectedhcc.length; i++) {
        if (multiselectedhcc[i] != 'All') {
          let newName = {
            hcc: null,
            key: i.toString(),
            role: null,
            value: multiselectedhcc[i]
          };
          this.selectedhccbl.push(newName);
        }
        else if (multiselectedhcc[i] == 'All') {
          //this.hccdetaillst.subscribe((posts) => {
          //  posts.forEach(post => {
          //    //console.log(post);
          //    this.selectedhccbl.push(post);
          //  });
          //});
         
          this.selectedhccbl = this.hccdetail;
        }
      }
      this.toggleDisplayState = !this.toggleDisplayState;

    }
    else {

    }

  }
  toggleDisplay1(index) {
    this.editRow = index;
  }


  ngOnInit(): void {
    this.option = [
      { optionId: '0', description: 'Role' },
      { optionId: '1', description: 'Grade' },
      { optionId: '2', description: 'Band' }
    ];

    this.getallOffshorehrole();

    //this.eligibleemployeesrepository.getSelectedEligibleEmployees();
    //this.masterdata = this.eligibleemployeesrepository.Eligiblecompanydetails;
   // this.Filteredemployees = this.eligibleemployeesrepository.SelectedEligibleEmployees;
    //this.eligibleemployeesrepository.getEmployeeDetails;
    this.eligibleemployeesrepository.getlocationDetails();
    this.eligibleemployeesrepository.getLevelDetails();
    this.eligibleemployeesrepository.getHccDetails();
    this.eligibleemployeesrepository.getRoleDetails();
    this.eligibleemployeesrepository.getGradeDetails();
    this.eligibleemployeesrepository.getGenderDetails();
    this.eligibleemployeesrepository.getCompnayDetails();
    this.eligibleemployeesrepository.getEmployeeDetails();
    this.eligibleemployeesrepository.getStausDetails();
    this.eligibleemployeesrepository.getProjectDetails();

    this.locationslst = this.eligibleemployeesrepository.Eligiblelocationdetails;
    this.locationslst.subscribe((posts) => {
      posts.forEach(post => {
        this.locations.push(post);
      });
    });

    this.employeeslst = this.eligibleemployeesrepository.Eligibleemployeedetails;
    this.employeeslst.subscribe((posts) => {
      posts.forEach(post => {
        this.employees.push(post);
      });
    });

    this.hccdetaillst = this.eligibleemployeesrepository.Eligiblehccdetails;
    this.hccdetaillst.subscribe((posts) => {
      posts.forEach(post => {
        this.hccdetail.push(post);
      });
    });

    this.levelslst = this.eligibleemployeesrepository.Eligibleleveldetails;
    this.levelslst.subscribe((posts) => {
      posts.forEach(post => {
        this.levels.push(post);
      });
    });

    this.roleslst = this.eligibleemployeesrepository.Eligibleroledetails;
    this.roleslst.subscribe((posts) => {
      posts.forEach(post => {
        this.roles.push(post);
      });
    });

    this.gradeslst = this.eligibleemployeesrepository.Eligiblegradedetails;
    this.gradeslst.subscribe((posts) => {
      posts.forEach(post => {
        this.grades.push(post);
      });
    });

    this.genderslst = this.eligibleemployeesrepository.Eligiblegendersdetails;
    this.genderslst.subscribe((posts) => {
      posts.forEach(post => {
        this.genders.push(post);
      });
    });

    this.companylst = this.eligibleemployeesrepository.Eligiblecompanydetails;
    this.companylst.subscribe((posts) => {
      posts.forEach(post => {
        this.company.push(post);
      });
    });

    this.statuslst = this.eligibleemployeesrepository.EmployeeStausDetails;
    this.statuslst.subscribe((posts) => {
      posts.forEach(post => {
        this.status.push(post);
      });
    });

    this.projectslst = this.eligibleemployeesrepository.EmployeeProjectDetails;
    this.projectslst.subscribe((posts) => {
      posts.forEach(post => {
        this.projects.push(post);
      });
    });

    //this.levels = this.eligibleemployeesrepository.Eligibleleveldetails;
    // this.hccdetail = this.eligibleemployeesrepository.Eligiblehccdetails;
    //this.roles = this.eligibleemployeesrepository.Eligibleroledetails;
    //this.grades = this.eligibleemployeesrepository.Eligiblegradedetails;
    //this.genders = this.eligibleemployeesrepository.Eligiblegendersdetails;
    //this.company = this.eligibleemployeesrepository.Eligiblecompanydetails;
    //this.employees = this.eligibleemployeesrepository.Eligibleemployeedetails;
    //this.status = this.eligibleemployeesrepository.EmployeeStausDetails;
    // this.projects = this.eligibleemployeesrepository.EmployeeProjectDetails;
  }

  onFormSubmit(form: NgForm) {
    this.isValidFormSubmitted = false;
    if (form.valid) {
      this.isValidFormSubmitted = true;
    } else {
      return;
    }
    let userTechnologies: LocationDetails[] = form.controls['locations'].value;
    alert(userTechnologies);
  }

  getallOffshorehrole() {
  }
  onSelectionChange(entry: string) {
    if (this.offshore) {
      if (entry.trim() == "0") {
        this.isgrade = false;
      }
      else if (entry.trim() == "1") {
        this.isgrade = true;

      }
      else if (entry.trim() == "2") {
      }
    }
    else {
      if (entry.trim() == "0") {
        this.isgrade = false;
      }
      else if (entry.trim() == "1") {
        this.isgrade = true;
      }
      else if (entry.trim() == "2") {
      }

    }
  }
  Offshore() {

  }
  Onsite() {
    this.offshore = false;
  }
  GetRolesByHcc(selectedhcc, form: NgForm) {
    ////Binding Grades
    if (this.isgrade) {
      this.getrolesbyhcc = [];
      let multiselectedgrades: any[] = form.controls['gradedetails'].value;
      if (multiselectedgrades == undefined) {
        alert('Please select atleast one Grade');
        this.accordianfalse = false;
        return false;

      }
      else if (multiselectedgrades.length > 0) {
        this.accordianfalse = true;
        for (var i = 0; i < multiselectedgrades.length; i++) {
          if (multiselectedgrades[i] != 'All') {
            let newName = {
              hcc: null,
              key: i.toString(),
              role: multiselectedgrades[i],
              value: null
            };
            this.getrolesbyhcc.push(newName);
          }
          if (multiselectedgrades[i] == 'All') {
            this.gradeslst.subscribe((posts) => {
              posts.forEach(post => {
                this.allgradesarray.push(post);
              });
            });
            for (var g = 0; g < this.allgradesarray.length; g++) {
              let newName = {
                hcc: null,
                key: g.toString(),
                role: this.allgradesarray[g].value,
                value: null
              };
              this.getrolesbyhcc.push(newName);
            }
          }
        }
        this.isgetallgrades = false;
      }
      else {
        this.isgetallgrades = true;
      }
    }
    else {
      this.getrolesbyhcc = [];
      ////Binding Roles
      let multiselectedcbfroles: any[] = form.controls['roledetails'].value;
      if (multiselectedcbfroles.length > 0) {
        for (var i = 0; i < multiselectedcbfroles.length; i++) {
          if (multiselectedcbfroles[i] != 'All') {
            let newName = {
              hcc: null,
              key: i.toString(),
              role: multiselectedcbfroles[i],
              value: null
            };
            this.getrolesbyhcc.push(newName);
          }
          if (multiselectedcbfroles[i] == 'All') {
            this.roleslst.subscribe((posts) => {
              posts.forEach(post => {
                this.allrolesarray.push(post);
              });
            });
            for (var g = 0; g < this.allrolesarray.length; g++) {
              let newName = {
                hcc: null,
                key: g.toString(),
                role: this.allrolesarray[g].value,
                value: null
              };
              this.getrolesbyhcc.push(newName);
            }

          }
        }

      }
      else {
        //this.eligibleemployeesrepository.getRolesByhcc(selectedhcc).subscribe(roles => {
        //  this.getrolesbyhcc = roles;
        //});
        //this.getrolesbyhcc = this.getrolesbyhcc.filter(function (item) {
        //  return item.hcc == selectedhcc;
        //})
      }
      selectedhcc = null;
    }
    let multiselectedcbflevels: any[] = form.controls['leveldetails'].value;
    ////Binding CBF Levels
    
    if (multiselectedcbflevels.length > 0) {
      this.TableDataLevels = [];
      var i = 0;
      var levl1 = '';
      var levl2 = '';
      var levl3 = '';
      var all = '';
      for (i = 0; i < multiselectedcbflevels.length; i++) {
        if (multiselectedcbflevels[i] != 'All') {
          let Levels = {
            id: i.toString(),
            level: multiselectedcbflevels[i],
            value: null
          };
          this.TableDataLevels.push(Levels);
          if (multiselectedcbflevels[i] =='Level 1') {
            levl1 = multiselectedcbflevels[i];
          }
          if (multiselectedcbflevels[i] == 'Level 2') {
            levl2 = multiselectedcbflevels[i];
          }
          if (multiselectedcbflevels[i] == 'Level 3') {
            levl3 = multiselectedcbflevels[i];
          }
        }
        else {
          all = multiselectedcbflevels[i]; 
        }
      }
      if (i == 2 && levl1 == 'Level 1' && levl2 == 'Level 2') {
        this.isonelevelsselected = true;
        this.istwolevelsselected = true;

      }
      if (i == 2 && levl2 == 'Level 2' && levl3 == 'Level 3') {
        this.isthreelevelsselected = true;
        this.istwolevelsselected = true;
      }
      if (i == 2 && levl1 == 'Level 1' && levl3 == 'Level 3') {
        this.isthreelevelsselected = true;
        this.isonelevelsselected = true;
      }
      if (i==3) {
        this.isonelevelsselected = true;
        this.istwolevelsselected = true;
        this.isthreelevelsselected = true;
      }
      if (levl1 == 'Level 1') {
        this.isonelevelsselected = true;

      }
      if (levl2 == 'Level 2') {
        //this.isonelevelsselected = true;
        this.istwolevelsselected = true;

      }
      else if (levl3 == 'Level 3') {
        //this.isonelevelsselected = true;
       //this.istwolevelsselected = true;
        this.isthreelevelsselected = true;
      }
      else if (all=='All') {
        this.isonelevelsselected = true;
        this.istwolevelsselected = true;
        this.isthreelevelsselected = true;
        this.TableDataLevels =
          [
            { id: '1', level: 'Level1', value: null },
            { id: '2', level: 'Level2', value: null },
            { id: '3', level: 'Level3', value: null }
          ]
      }
      }
    }
  openModalDialog() {
    this.display = 'block';
  }

  closeModalDialog() {
    this.display = 'none';
  }

  //multiselectparams() {
  //  this.display = 'block';
  //  this.selectedparams = [];
  //  for (var i = 0; i < this.multiselectedparams.length; i++) {
  //    let newName = {
  //      hcc: this.multiselectedparams[i],
  //      key: i.toString(),
  //      role: null
  //    };
  //    this.selectedparams.push(newName);
  //  }
  //  console.log(this);
  //}

  multiselectngform(form: NgForm) {
    this.display = 'block';

    let selectedhcc: any[] = form.controls['hccdetails'].value;
    let selectedlocation: any[] = form.controls['location_valid'].value;
    let selectedroles: any[] = form.controls['roledetails'].value;
    let selectedlevel: any[] = form.controls['leveldetails'].value;
    let selectedgrade: any[] = form.controls['gradedetails'].value;
    let selectedgender: any[] = form.controls['gendersdetails'].value;

    //this.filteredgender

    var location = "";
    var hcc = "";
    var roles = "";
    var levels = "";
    var grades = "";
    var gender = "";

    //this.employeeslst.subscribe(workarounds => {
    //  // prevent datatables from mutating the data
    //  this.jsondata = JSON.parse(JSON.stringify(<EmployeeDetails[]>workarounds));
    //});
    if (selectedlocation != undefined || selectedlocation != null) {
      if (selectedlocation.length > 0) {
        for (var i = 0; i < selectedlocation.length; i++) {
          if (selectedlocation[i] != 'All') {
            location = selectedlocation[i]
            break;
          }
          else if (selectedlocation[i] == 'All') {
          }
        }
      }
    }
    if (selectedhcc != undefined || selectedhcc != null) {
      if (selectedhcc.length > 0) {
        for (var i = 0; i < selectedhcc.length; i++) {
          if (selectedhcc[i] != 'All') {
            var temp = this.employees.filter(n => n.employeE_ORGANIZATION == selectedhcc[i]);
            temp.forEach(hc => { this.filteredhcc.push(hc) });
          }
          else if (selectedhcc[i] == 'All') {
            this.filteredhcc = this.employees;
            break;
          }
        }
        this.ishccselected = true;
      }
    }

    if (selectedroles != undefined || selectedroles != null) {
      if (selectedroles.length > 0) {
        for (var i = 0; i < selectedroles.length; i++) {
          if (selectedroles[i] != 'All') {
            if (this.ishccselected) {
              var temp = this.filteredhcc.filter(n => n.emP_ROLE == selectedroles[i]);
              temp.forEach(r => { this.filteredcbfroles.push(r) });
            }
            else {
              var temp = this.employees.filter(n => n.emP_ROLE == selectedroles[i]);
              temp.forEach(r => { this.filteredcbfroles.push(r) });
            }
          }
          else if (selectedroles[i] == 'All') {
            if (!this.ishccselected) {
              this.filteredcbfroles = this.employees;
            }
            else {
              this.filteredcbfroles = this.filteredhcc;
              break;
            }
          }
        }
        this.isroleselected = true;
      }
    }

    if (selectedlevel != undefined || selectedlevel != null) {
      if (selectedlevel.length > 0) {
        for (var i = 0; i < selectedlevel.length; i++) {
          if (selectedlevel[i] != 'All') {
            if (this.ishccselected && this.isroleselected) {
              var temp = this.filteredcbfroles.filter(l => l.emP_ROLE_LEVEL == selectedlevel[i]);
              temp.forEach(r => { this.filteredlevels.push(r) });
            }
            else if (this.ishccselected && !this.isroleselected) {
              var temp = this.filteredhcc.filter(l => l.emP_ROLE_LEVEL == selectedlevel[i]);
              temp.forEach(r => { this.filteredlevels.push(r) });
            }
            else if (!this.ishccselected && this.isroleselected) {
              var temp = this.filteredcbfroles.filter(l => l.emP_ROLE_LEVEL == selectedlevel[i]);
              temp.forEach(r => { this.filteredlevels.push(r) });
            }
          }
          else if (selectedlevel[i] == 'All') {
            if (!this.ishccselected && !this.isroleselected) {
              this.filteredlevels = this.employees;
            }
            else if (this.ishccselected && !this.isroleselected) {
              this.filteredlevels = this.filteredhcc;
            }
            else if (!this.ishccselected && this.isroleselected){
              this.filteredlevels = this.filteredcbfroles;
            }
            else if (this.ishccselected && this.isroleselected) {
              this.filteredlevels = this.filteredcbfroles;
            }
            break;
          }
        }
        this.islevelselected = true;
      }
    }

  if (selectedgrade != undefined || selectedgrade != null) {
      if (selectedgrade.length > 0) {
        for (var i = 0; i < selectedgrade.length; i++) {
          if (selectedgrade[i] != 'All') {

            if (this.ishccselected && !this.isroleselected && this.islevelselected) {
              var temp = this.filteredlevels.filter(l => l.grade == selectedgrade[i]);
              temp.forEach(r => { this.filteredgrades.push(r) });
            }
            else if (this.ishccselected && !this.isroleselected && !this.islevelselected) {
              var temp = this.filteredhcc.filter(l => l.grade == selectedgrade[i]);
              temp.forEach(r => { this.filteredgrades.push(r) });
            }
            else if (!this.ishccselected && !this.isroleselected && !this.islevelselected) {
              var temp = this.employees.filter(l => l.grade == selectedgrade[i]);
              temp.forEach(r => { this.filteredgrades.push(r) });
            }
          }
          else if (selectedgrade[i] == 'All') {
            if (!this.ishccselected && !this.isroleselected && !this.islevelselected) {
              this.filteredgrades = this.employees;
            }
            else if (!this.ishccselected && !this.isroleselected && this.islevelselected) {
              this.filteredgrades = this.filteredlevels;
            }
            else if (!this.ishccselected && this.isroleselected && this.islevelselected) {
              this.filteredgrades = this.filteredlevels;
            }
            else if (this.ishccselected && this.isroleselected && this.islevelselected) {
              this.filteredgrades = this.filteredlevels;
            }
            break
          }
          this.isgradeselected = true;
        }
      }
    }

   if (selectedgender != undefined || selectedgender != null) {
      if (selectedgender.length > 0) {
        for (var i = 0; i < selectedgender.length; i++) {
          if (selectedgender[i] == 'Female') {
            if (this.ishccselected && this.isroleselected && this.islevelselected) {
              var temp = this.filteredlevels.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (this.ishccselected && this.isroleselected && !this.islevelselected && this.isgradeselected) {
              var temp = this.filteredlevels.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (!this.ishccselected && this.isroleselected && !this.islevelselected && !this.isgradeselected) {
              var temp = this.filteredcbfroles.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (!this.ishccselected && this.isroleselected && this.islevelselected && !this.isgradeselected) {
              var temp = this.filteredlevels.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (!this.ishccselected && !this.isroleselected && !this.islevelselected && !this.isgradeselected) {
              var temp = this.employees.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
          }

          else if (selectedgender[i] == 'Male') {
            if (this.ishccselected && this.isroleselected && this.islevelselected) {
              var temp = this.filteredlevels.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (this.ishccselected && this.isroleselected && !this.islevelselected && this.isgradeselected) {
              var temp = this.filteredlevels.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (!this.ishccselected && this.isroleselected && !this.islevelselected && !this.isgradeselected) {
              var temp = this.filteredcbfroles.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (!this.ishccselected && this.isroleselected && this.islevelselected && !this.isgradeselected) {
              var temp = this.filteredlevels.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }
            else if (!this.ishccselected && !this.isroleselected && !this.islevelselected && !this.isgradeselected) {
              var temp = this.employees.filter(l => l.gender == selectedgender[i]);
              temp.forEach(r => { this.filteredgender.push(r) });
            }

          }
          else if (selectedgender[i] == 'Both') {
            if (this.ishccselected && this.isroleselected && this.islevelselected) {
              this.filteredgender = this.filteredlevels;
            }
            else if (this.ishccselected && this.isroleselected && !this.islevelselected && this.isgradeselected) {
              this.filteredgender = this.filteredlevels
            }
            else if (!this.ishccselected && this.isroleselected && !this.islevelselected && !this.isgradeselected) {
              this.filteredgender = this.filteredcbfroles;
            }
            else if (!this.ishccselected && this.isroleselected && this.islevelselected && !this.isgradeselected) {
              this.filteredgender = this.filteredlevels;
            }
            else if (!this.ishccselected && !this.isroleselected && !this.islevelselected && !this.isgradeselected) {
              this.filteredgender = this.employees;
            }

          }
          this.isgenderselected = true;
        }
      }

     if (this.ishccselected && this.isroleselected && this.islevelselected) {
        this.source.load(this.filteredlevels);
      }
      
      else if (this.ishccselected && this.isroleselected && !this.islevelselected && this.isgradeselected) {
        this.source.load(this.filteredgrades);
      }
      else if (this.ishccselected && !this.isroleselected && this.islevelselected && !this.isgradeselected) {
        this.source.load(this.filteredlevels);
      }
      else if (this.ishccselected && this.isroleselected && !this.islevelselected && !this.isgradeselected) {
        var temp = this.filteredcbfroles.filter(l => l.gender == selectedgender[i]);
        this.source.load(this.filteredcbfroles);
      }
      else if (this.ishccselected && !this.isroleselected && !this.islevelselected && this.isgradeselected) {
        this.source.load(this.filteredgrades);
      }
      else if (this.ishccselected && !this.isroleselected && !this.islevelselected && !this.isgradeselected) {
        this.source.load(this.filteredhcc);
      }
      else if (this.ishccselected && !this.isroleselected && this.islevelselected && this.isgradeselected) {
        this.source.load(this.filteredgrades);
      }
      else if (!this.ishccselected && this.isroleselected && !this.islevelselected && !this.isgradeselected) {
        this.source.load(this.filteredcbfroles);
      }
      else if (!this.ishccselected && !this.isroleselected && this.islevelselected && !this.isgradeselected) {
        this.source.load(this.filteredlevels);
      }
      else if (!this.ishccselected && !this.isroleselected && !this.islevelselected && this.isgradeselected) {
        this.source.load(this.filteredgrades);
      }
      else if (!this.ishccselected && !this.isroleselected && !this.islevelselected && !this.isgradeselected && this.filteredgender) {
        if (this.filteredgender.length>0) {
          this.source.load(this.filteredgender);
        }
        else {
          this.employeeslst.subscribe(workarounds => {
            // prevent datatables from mutating the data
            this.jsondata = JSON.parse(JSON.stringify(<EmployeeDetails[]>workarounds));
          });
          this.source.load(this.jsondata);
        }
      }
      //if (!this.ishccselected && !this.isroleselected && !this.islevelselected && !this.isgradeselected && !this.filteredgender) {
        
      //}
    }
  }

  handleGridSelected(event) {
    let selectedEmp = this.jsondata.find(x => x.employeE_ID == event.data.employeE_ID);
    selectedEmp.excludeFlag = event.isSelected ? "true" : "false";
  }

  exclude() {
    this.selectedEmps = [];

    for (var i = 0; i < this.jsondata.length; i++) {
      if (this.jsondata[i].excludeFlag == "true") {
        
        let excludeEmp = {
          Name: this.jsondata[i].employeE_NAME,
          EmployeeId: this.jsondata[i].employeE_ID,
          Id: this.jsondata[i].id,
          Comments: this.jsondata[i].comments,
        };

        this.selectedEmps.push(excludeEmp);
      }
    }

    let updatePlanSubDoc = <ExcludedEmployee>JSON.parse(JSON.stringify(this.selectedEmps));
    
    this.planRepository.updateSubDoc(this.planId, updatePlanSubDoc);
        
    this.closeModalDialog();
  }
  onSubmit() {
    //var result = this.getrolesbyhcc;
    //var result1 = this.getrolesbyhcclevelone;
    //var result2 = this.getrolesbyhcclevetwo;
    //var result3 = this.getrolesbyhcclevelthree;
    var r = this.businessrules;
    if (this.businessrules.length > 0 && this.businessrules != undefined) {
      let updatePlanSubDoc = <BusinessRules>JSON.parse(JSON.stringify(this.businessrules));
      this.planRepository.updateBusinessRulesSubDoc(this.planId, updatePlanSubDoc);

    }
    //For clearing the objects
    //this.getrolesbyhcclevelone=[];
    //this.getrolesbyhcclevetwo=[];
    //this.getrolesbyhcclevelthree=[];
    this.businessrules = [];
    
  }

  onRowClick(event, hcc, role, l, c) {
    if (event == null || event == '') {
      return;
    }
    if (this.isgrade) {
      if (l == "1") {
        if (c == 1) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat1",
            cbfLevel: "Level1",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 2) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            cat: "Cat2",
            value: event,
            cbfLevel: "Level1",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }

        if (c == 3) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            cat: "Cat3",
            value: event,
            cbfLevel: "Level1",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 4) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            cat: "Cat4",
            value: event,
            cbfLevel: "Level1",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
      }
      if (l == "2") {
        if (c == 1) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat1",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 2) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat2",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }

        if (c == 3) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat3",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 4) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat4",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
      }
      if (l == "3") {
        if (c == 1) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat1",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 2) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat2",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }

        if (c == 3) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat3",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 4) {
          let newName = {
            hcc: hcc,
            cbfRole: "",
            value: event,
            cat: "Cat4",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: role,
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
      }

    } else {
      if (l == "1") {
        if (c == 1) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat1",
            cbfLevel: "Level1",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 2) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat2",
            cbfLevel: "Level1",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }

        if (c == 3) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat3",
            cbfLevel: "Level1",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 4) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat4",
            cbfLevel: "Level1",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
      }
      if (l == "2") {
        if (c == 1) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat1",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 2) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat2",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }

        if (c == 3) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat3",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 4) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat4",
            cbfLevel: "Level2",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
      }
      if (l == "3") {
        if (c == 1) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat1",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 2) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat2",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }

        if (c == 3) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat3",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
        if (c == 4) {
          let newName = {
            hcc: hcc,
            cbfRole: role,
            value: event,
            cat: "Cat4",
            cbfLevel: "Level3",
            plan: this.planId,
            grade: "",
            Id: this.planId
          };
          this.businessrules.push(newName);

        }
      }
    }
  }
}
