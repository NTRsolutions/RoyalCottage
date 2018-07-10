import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { map } from 'rxjs/operators';
import { Eligibleemployees } from './Eligibleemployees';
import { EligibleemployeesService } from './eligibleemployees.service';
import { debug } from 'util';
import { MessageService } from '../shared/message.service'
import { EmployeeDetails } from './employeedetails';
import { LocationDetails } from './locationdetails';
import { RoleDetails } from './roledetails';
import { HCCDetails } from './hccdetails';
import { GradeDetails } from './gradedetails';
import { LevelDetails } from './leveldetails';
import { GenderDetails } from './genderdetails';
import { CompanyDetails } from './companydetails';
import { StatusDetails } from './statusdetails';
import { ProjectDetails } from './projectdetails';

@Injectable()
export class EligibleemployeesRepository {

  private companydetails: Observable<CompanyDetails[]>
  private _companydetails: BehaviorSubject<CompanyDetails[]>;

  private selectedEligibleEmployees: Observable<EmployeeDetails[]>
  private _selectedEligibleEmployees: BehaviorSubject<EmployeeDetails[]>;

  private locationdetails: Observable<LocationDetails[]>
  private _locationdetails: BehaviorSubject<LocationDetails[]>;

  private employeedetails: Observable<EmployeeDetails[]>
  private _employeedetails: BehaviorSubject<EmployeeDetails[]>;

  private roledetails: Observable<RoleDetails[]>
  private _roledetails: BehaviorSubject<RoleDetails[]>;

  private hccdetails: Observable<HCCDetails[]>
  private _hccdetails: BehaviorSubject<HCCDetails[]>;

  private gradedetails: Observable<GradeDetails[]>
  private _gradedetails: BehaviorSubject<GradeDetails[]>;

  private leveldetails: Observable<LevelDetails[]>
  private _leveldetails: BehaviorSubject<LevelDetails[]>;

  private genderdetails: Observable<GenderDetails[]>
  private _genderdetails: BehaviorSubject<GenderDetails[]>;

  private employeestatus: Observable<StatusDetails[]>
  private _employeestatus: BehaviorSubject<StatusDetails[]>;

  private projectdetails: Observable<ProjectDetails[]>
  private _projectdetails: BehaviorSubject<ProjectDetails[]>;

  private dataStore: {
    companydetails: CompanyDetails[]
  };

  private selectedEligibleEmpdataStore: {
    selectedEligibleEmployees: EmployeeDetails[]
  };

  private locationdatastore: {
    locationdetails: LocationDetails[]
  };

  private employeedatastore: {
    employeedetails: EmployeeDetails[]
  };

  private roledatastore: {
    roledetails: RoleDetails[]
  };

  private hccdatastore: {
    hccdetails: HCCDetails[]
  };

  private gradedatastore: {
    gradedetails: GradeDetails[]
  };

  private leveldatastore: {
    leveldetails: LevelDetails[]
  };

  private genderdatastore: {
    genderdetails: GenderDetails[]
  };

  private statusdataStore: {
    employeestatus: StatusDetails[]
  };

  private projectdataStore: {
    projectdetails: ProjectDetails[]
  };

  private _companydetail: BehaviorSubject<CompanyDetails>;
  private _selectedEligibleEmployee: BehaviorSubject<EmployeeDetails>;
  private _employee: BehaviorSubject<CompanyDetails>;
  private _locationdetail: BehaviorSubject<LocationDetails>;
  private _employeedetail: BehaviorSubject<EmployeeDetails>;
  private _roledetail: BehaviorSubject<RoleDetails>;
  private _hccdetail: BehaviorSubject<HCCDetails>;
  private _gradedetail: BehaviorSubject<GradeDetails>;
  private _leveldetail: BehaviorSubject<LevelDetails>;
  private _genderdetail: BehaviorSubject<GenderDetails>;
  private _employeestatuses: BehaviorSubject<StatusDetails>;
  private _projectdetail: BehaviorSubject<ProjectDetails>;

  constructor(private eligibleemployeesService: EligibleemployeesService, private messageService: MessageService) {

    this.dataStore = { companydetails: [] };
    this.selectedEligibleEmpdataStore = { selectedEligibleEmployees: [] };
    // this.employeedataStore = { employees: [] };
    this.locationdatastore = { locationdetails: [] };
    this.employeedatastore = { employeedetails: [] };
    this.roledatastore = { roledetails: [] };
    this.hccdatastore = { hccdetails: [] };
    this.gradedatastore = { gradedetails: [] };
    this.leveldatastore = { leveldetails: [] };
    this.genderdatastore = { genderdetails: [] };
    this.statusdataStore = { employeestatus: [] };
    this.projectdataStore = { projectdetails: [] };

    this._companydetails = <BehaviorSubject<CompanyDetails[]>>new BehaviorSubject<CompanyDetails[]>([]);
    this.companydetails = this._companydetails.asObservable();
    this._selectedEligibleEmployees = <BehaviorSubject<EmployeeDetails[]>>new BehaviorSubject<EmployeeDetails[]>([]);
    this.selectedEligibleEmployees = this._selectedEligibleEmployees.asObservable();
    this._locationdetails = <BehaviorSubject<LocationDetails[]>>new BehaviorSubject<LocationDetails[]>([]);
    this.locationdetails = this._locationdetails.asObservable();
    this._employeedetails = <BehaviorSubject<EmployeeDetails[]>>new BehaviorSubject<EmployeeDetails[]>([]);
    this.employeedetails = this._employeedetails.asObservable();
    this._roledetails = <BehaviorSubject<RoleDetails[]>>new BehaviorSubject<RoleDetails[]>([]);
    this.roledetails = this._roledetails.asObservable();
    this._hccdetails = <BehaviorSubject<HCCDetails[]>>new BehaviorSubject<HCCDetails[]>([]);
    this.hccdetails = this._hccdetails.asObservable();
    this._gradedetails = <BehaviorSubject<GradeDetails[]>>new BehaviorSubject<GradeDetails[]>([]);
    this.gradedetails = this._gradedetails.asObservable();
    this._leveldetails = <BehaviorSubject<LevelDetails[]>>new BehaviorSubject<LevelDetails[]>([]);
    this.leveldetails = this._leveldetails.asObservable();
    this._genderdetails = <BehaviorSubject<GenderDetails[]>>new BehaviorSubject<GenderDetails[]>([]);
    this.genderdetails = this._genderdetails.asObservable();
    this._employeestatus = <BehaviorSubject<StatusDetails[]>>new BehaviorSubject<StatusDetails[]>([]);
    this.employeestatus = this._employeestatus.asObservable();
    this._projectdetails = <BehaviorSubject<ProjectDetails[]>>new BehaviorSubject<ProjectDetails[]>([]);
    this.projectdetails = this._projectdetails.asObservable();

    this._companydetail = <BehaviorSubject<CompanyDetails>>{};
    this._selectedEligibleEmployee = <BehaviorSubject<EmployeeDetails>>{};
    this._employee = <BehaviorSubject<CompanyDetails>>{};
    this._locationdetail = <BehaviorSubject<LocationDetails>>{};
    this._employeedetail = <BehaviorSubject<EmployeeDetails>>{};
    this._roledetail = <BehaviorSubject<RoleDetails>>{};
    this._hccdetail = <BehaviorSubject<HCCDetails>>{};
    this._gradedetail = <BehaviorSubject<GradeDetails>>{};
    this._leveldetail = <BehaviorSubject<LevelDetails>>{};
    this._genderdetail = <BehaviorSubject<GenderDetails>>{};
    this._employeestatuses = <BehaviorSubject<StatusDetails>>{};
    this._projectdetail = <BehaviorSubject<ProjectDetails>>{};
  }

  get Eligiblecompanydetails() {
    return this._companydetails.asObservable();
  }
  get SelectedEligibleEmployees() {
    return this._selectedEligibleEmployees.asObservable();
  }
  get Eligiblelocationdetails() {
    return this._locationdetails.asObservable();
  }
  get Eligibleemployeedetails() {
    return this._employeedetails.asObservable();
  }
  get Eligibleroledetails() {
    return this._roledetails.asObservable();
  }
  get Eligiblehccdetails() {
    return this._hccdetails.asObservable();
  }
  get Eligiblegradedetails() {
    return this._gradedetails.asObservable();
  }
  get Eligibleleveldetails() {
    return this._leveldetails.asObservable();
  }
  get Eligiblegendersdetails() {
    return this._genderdetails.asObservable();
  }
  get EmployeeStausDetails() {
    return this._employeestatus.asObservable();
  }
  get EmployeeProjectDetails() {
    return this._projectdetails.asObservable();
  }

  get CurrentEligibleemployees() {
    return this._companydetails;
  }
  get CurrentSelectedEligibleEmployees() {
    return this._selectedEligibleEmployees;
  }
  get Currentlocationdetails() {
    return this._locationdetails;
  }
  get Currentemployeedetails() {
    return this._employeedetails;
  }
  get Currentroledetails() {
    return this._roledetails;
  }
  get Currenthccdetails() {
    return this._hccdetails;
  }
  get Currentgradedetails() {
    return this._gradedetails;
  }
  get Currentleveldetails() {
    return this._leveldetails;
  }
  get Currentgenderdetails() {
    return this._leveldetails;
  }
  get CurrentEmployeeStautsDetails() {
    return this._employeestatus;
  }
  get CurrentprojectDetails() {
    return this._projectdetails;
  }

  getCompnayDetails(): void {
    this.eligibleemployeesService.getCompnayDetails().subscribe(
      (data) => {
        this.resolveData(data);
      });
  }

  getSelectedEligibleEmployees(): void {
    this.eligibleemployeesService.getFilterEmployeeDetails().subscribe(
      (data) => {
        this.FilterEmployeeresolveData(data);
      });
  }

  FilterEmployeeresolveData(data: EmployeeDetails[]) {

    this.selectedEligibleEmpdataStore.selectedEligibleEmployees = [];
    data.forEach((employeeDetails) => {
      this.selectedEligibleEmpdataStore.selectedEligibleEmployees.push(employeeDetails);
    })
    this._selectedEligibleEmployees.next(Object.assign({}, this.selectedEligibleEmpdataStore).selectedEligibleEmployees);
  };

  getlocationDetails(): void {
    this.eligibleemployeesService.getlocationDetails().subscribe(
      (locationdata) => {
        this.resolveLocationData(locationdata);
      });
  }

  getEmployeeDetails(): void {
    this.eligibleemployeesService.getEmployeeDetails().subscribe(
      (employeedata) => {
        this.EmployeeresolveData(employeedata);
      });
  }

  getRoleDetails(): void {
    this.eligibleemployeesService.getRoleDetails().subscribe(
      (roledata) => {
        this.resolveRoleData(roledata);
      });
  }

  getHccDetails(): void {
    this.eligibleemployeesService.getHccDetails().subscribe(
      (hccdata) => {
        this.resolvehccData(hccdata);
      });
  }

  getGradeDetails(): void {
    this.eligibleemployeesService.getGradeDetails().subscribe(
      (gradedata) => {
        this.resolvegradeData(gradedata);
      });
  }

  getLevelDetails(): void {
    this.eligibleemployeesService.getLevelDetails().subscribe(
      (leveldata) => {
        this.resolvelevelData(leveldata);
      });
  }

  getGenderDetails(): void {
    this.eligibleemployeesService.getGenderDetails().subscribe(
      (genderdata) => {
        this.resolvegenderData(genderdata);
      });
  }

  getStausDetails(): void {
    this.eligibleemployeesService.getStatusDetails().subscribe(
      (statusdata) => {
        this.resolvestatusData(statusdata);
      });
  }

  getProjectDetails(): void {
    this.eligibleemployeesService.getProjectDetails().subscribe(
      (projectdata) => {
        this.resolveprojectData(projectdata);
      });
  }

  EmployeeresolveData(employeedata: any[]) {
    this.employeedatastore.employeedetails = [];
    for (var key in employeedata) {
      if (key == "dataList") {
        this.employeedatastore.employeedetails = JSON.parse(JSON.stringify(<EmployeeDetails[]>employeedata[key]));

        this._employeedetails.next(Object.assign({}, this.employeedatastore).employeedetails);
      }
    }
  };

  resolvestatusData(statusdata: any[]) {
    this.statusdataStore.employeestatus = [];
    for (var key in statusdata) {
      if (key == "dataList") {
        this.statusdataStore.employeestatus = JSON.parse(JSON.stringify(<StatusDetails[]>statusdata[key]));

        this._employeestatus.next(Object.assign({}, this.statusdataStore).employeestatus);
      }
    }
  };

  resolveprojectData(projectdata: any[]) {
    this.projectdataStore.projectdetails = [];
    for (var key in projectdata) {
      if (key == "dataList") {
        this.projectdataStore.projectdetails = JSON.parse(JSON.stringify(<ProjectDetails[]>projectdata[key]));

        this._projectdetails.next(Object.assign({}, this.projectdataStore).projectdetails);
      }
    }
  };

  resolveLocationData(locationdata: any[]) {
    this.locationdatastore.locationdetails = [];
    for (var key in locationdata) {
      if (key == "dataList") {
        this.locationdatastore.locationdetails = JSON.parse(JSON.stringify(<LocationDetails[]>locationdata[key]));

        this._locationdetails.next(Object.assign({}, this.locationdatastore).locationdetails);
      }
    }
  };

  resolvehccData(hccdata: any[]) {
    this.hccdatastore.hccdetails = [];
    for (var key in hccdata) {
      if (key == "dataList") {
        this.hccdatastore.hccdetails = JSON.parse(JSON.stringify(<HCCDetails[]>hccdata[key]));

        this._hccdetails.next(Object.assign({}, this.hccdatastore).hccdetails);
      }
    }
  };

  resolvelevelData(leveldata: any[]) {
    this.leveldatastore.leveldetails = [];
    for (var key in leveldata) {
      if (key == "dataList") {
        this.leveldatastore.leveldetails = JSON.parse(JSON.stringify(<LevelDetails[]>leveldata[key]));

        this._leveldetails.next(Object.assign({}, this.leveldatastore).leveldetails);
      }
    }
  };

  resolveRoleData(roledata: any[]) {
    this.roledatastore.roledetails = [];
    for (var key in roledata) {
      if (key == "dataList") {
        this.roledatastore.roledetails = JSON.parse(JSON.stringify(<RoleDetails[]>roledata[key]));
        this._roledetails.next(Object.assign({}, this.roledatastore).roledetails);
      }
    }
  };

  resolvegradeData(gradedata: any[]) {
    this.gradedatastore.gradedetails = [];
    for (var key in gradedata) {
      if (key == "dataList") {
        this.gradedatastore.gradedetails = JSON.parse(JSON.stringify(<GradeDetails[]>gradedata[key]));
        this._gradedetails.next(Object.assign({}, this.gradedatastore).gradedetails);
      }
    }
  };

  resolvegenderData(genderdata: any[]) {
    this.genderdatastore.genderdetails = [];
    for (var key in genderdata) {
      if (key == "dataList") {
        this.genderdatastore.genderdetails = JSON.parse(JSON.stringify(<GenderDetails[]>genderdata[key]));
        this._genderdetails.next(Object.assign({}, this.genderdatastore).genderdetails);
      }
    }
  };

  resolveData(dataStore: any[]) {
    this.dataStore.companydetails = [];
    for (var key in dataStore) {
      if (key == "dataList") {
        this.dataStore.companydetails = JSON.parse(JSON.stringify(<CompanyDetails[]>dataStore[key]));
        this._companydetails.next(Object.assign({}, this.dataStore).companydetails);
      }
    }

    this._companydetails.next(Object.assign({}, this.dataStore).companydetails);
    this._locationdetails.next(Object.assign({}, this.locationdatastore).locationdetails);
    this._employeedetails.next(Object.assign({}, this.employeedatastore).employeedetails);
    this._roledetails.next(Object.assign({}, this.roledatastore).roledetails);
    this._hccdetails.next(Object.assign({}, this.hccdatastore).hccdetails);
    this._gradedetails.next(Object.assign({}, this.gradedatastore).gradedetails);
    this._leveldetails.next(Object.assign({}, this.leveldatastore).leveldetails);
    this._genderdetails.next(Object.assign({}, this.genderdatastore).genderdetails);
  }

  excludeEmployees(showEmps: EmployeeDetails) {
    this.eligibleemployeesService.excludeEmployees(showEmps).subscribe(
      () => { this.logSuccess(`Employees excluded successfully!`) },
      error => {
        this.handleError('ShowEmployees', error)
      });
  }

  private handleError(operation, error) {
    this.logFailure(operation + ' failed: ' + error['error']);
  }

  private logFailure(message: string) {
    this.messageService.addFailure(message);
  }

  private logSuccess(message: string) {
    this.messageService.addSuccess(message);
  }

}
