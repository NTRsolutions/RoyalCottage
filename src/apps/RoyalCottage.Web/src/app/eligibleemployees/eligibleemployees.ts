import { LocationDetails } from "./locationdetails";
import { HCCDetails } from "./hccdetails";
import { RoleDetails } from "./roledetails";
import { LevelDetails } from "./leveldetails";
import { GradeDetails } from "./gradedetails";
import { GenderDetails } from "./genderdetails";
import { EmployeeDetails } from "./employeedetails";
import { StatusDetails } from "./statusdetails";
import { CompanyDetails } from "./companydetails";

export interface Eligibleemployees {
  company: CompanyDetails[],
  location: LocationDetails[],
  hccdetails: HCCDetails[],
  roledetails: RoleDetails[],
  leveldetails: LevelDetails[],
  gradedetails: GradeDetails[],
  genderdetails: GenderDetails[],
  statusdetails: StatusDetails[],
  empldetails: EmployeeDetails[]
}
