
export class User implements IUser
{
    id: number;
    surname:string;
    name:string;
    lastName:string;
    email:string;
    salary:number;
    divisions:IDivisions[];
}

export class UserPage implements IUserPage
{
  users: User[];
  pages: Page;
}

export class Page implements IPage
{
  totalPages: number;
  pageNumber: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}


export class FilterData
{
  minSalary:number;
  maxSalary:number;
  searchString:string;
  divisions:any[];
}


export interface IDivisions
{
  id:number;
  name:string;
  parent:IDivisions;
  children:IDivisions[];
}

export interface IUser
{
  id:number;
  surname:string;
  name:string;
  lastName:string;
  email:string;
  salary:number;
  divisions:IDivisions[];
}

export interface IUserPage
{
  users:IUser[];
  pages:IPage;
}

export interface IPage
{
  pageNumber:number;
  totalPages:number;
  hasPreviousPage:boolean;
  hasNextPage:boolean;
}