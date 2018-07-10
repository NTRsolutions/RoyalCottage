export interface CreateCTCBreakup {
  name: string;
  description: string;
  grade: string;
  status: boolean;
  basic: number;
  hra: number;
  conveyance: number;
  medical: number;
  supplementary: number;
  education: number;
  foodcoupon: number;
  professiontax: number;
  incometax: number;
  pf: number;
  createdBy: string,
  createdOn: Date,
  lastUpdatedOn: Date,
  lastUpdatedBy: string
}
