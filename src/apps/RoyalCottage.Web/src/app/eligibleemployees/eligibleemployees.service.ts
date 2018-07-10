import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import { Eligibleemployees } from './Eligibleemployees';
import { MessageService } from '../shared/message.service';
import { EmployeeDetails } from './employeedetails';
import { LocationDetails } from './locationdetails';
import { RoleDetails } from './roledetails';
import { HCCDetails } from './hccdetails';
import { GradeDetails } from './gradedetails';
import { LevelDetails } from './leveldetails';
import { GenderDetails } from './genderdetails';
import { StatusDetails } from './statusdetails';
import { ProjectDetails } from './projectdetails';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable()
export class EligibleemployeesService {

  private baseUrl: string;
  private employee_baseUrl: string;
  private Masterdata_baseUrl: string;

  constructor(private http: HttpClient, private messageService: MessageService) {
    this.baseUrl = 'http://localhost:51098/api/';
    this.employee_baseUrl = 'http://localhost:58237/api/';
    this.Masterdata_baseUrl = 'http://localhost:58234/api/';
  }

  //getCompnayDetails(): Observable<Eligibleemployees[]> {
  //  return this.http.get<Eligibleemployees[]>(this.baseUrl + 'EmployeeMaster/GetAllEmployeeMasterData');
  //}

  excludeEmployees(showEmps: EmployeeDetails) {
    return this.http.post(this.baseUrl + 'EmployeeMaster/ExcludeEmps', JSON.stringify(showEmps), httpOptions);
  }

  getFilterEmployeeDetails(): Observable<EmployeeDetails[]> {
    //return this.http.get<EmployeeDetails[]>(this.baseUrl + 'EmployeeDetails/GetEligibleEmployees');
    return this.http.get<EmployeeDetails[]>(this.employee_baseUrl + 'Employee');
  }

  //Restruc Code
  getCompnayDetails(): Observable<Eligibleemployees[]> {
    return this.http.get<Eligibleemployees[]>(this.Masterdata_baseUrl + 'Companies');//'EmployeeMaster/GetAllEmployeeMasterData');
  }

  getlocationDetails(): Observable<any[]> {
    return this.http.get<any[]>(this.Masterdata_baseUrl + 'Locations');
  }

  getEmployeeDetails(): Observable<any[]> {
    return this.http.get<EmployeeDetails[]>(this.employee_baseUrl + 'Employee');
  }

  getRoleDetails(): Observable<any[]> {
    return this.http.get<RoleDetails[]>(this.Masterdata_baseUrl + 'Roles');
  }

  getHccDetails(): Observable<any[]> {
    return this.http.get<HCCDetails[]>(this.Masterdata_baseUrl + 'HCCies');
  }

  getGradeDetails(): Observable<any[]> {
    return this.http.get<GradeDetails[]>(this.Masterdata_baseUrl + 'Grades');
  }

  getLevelDetails(): Observable<any[]> {
    return this.http.get<LevelDetails[]>(this.Masterdata_baseUrl + 'Levels');
  }

  getGenderDetails(): Observable<GenderDetails[]> {
    return this.http.get<GenderDetails[]>(this.Masterdata_baseUrl + 'Genders');
  }

  getProjectDetails(): Observable<any[]> {
    return this.http.get<ProjectDetails[]>(this.Masterdata_baseUrl + 'Projects');
  }

  getStatusDetails(): Observable<any[]> {
    return this.http.get<StatusDetails[]>(this.Masterdata_baseUrl + 'Statuses');
  }

  //getProfLevelsDetails(): Observable<GenderDetails[]> {
  //  return this.http.get<GenderDetails[]>(this.Masterdata_baseUrl + 'ProficiencyLevels');
  //}
}
