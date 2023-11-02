
export class User implements IUser
{
    id: number;
    surname:string;
    name:string;
    lastName:string;
    email:string;
    salary:number;
    divisions:Divisions[];
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


export interface Divisions
{
  id:number;
  subdivision:string;
  name:string;
}

export interface IUser
{
  id:number;
  surname:string;
  name:string;
  lastName:string;
  email:string;
  salary:number;
  divisions:Divisions[];
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