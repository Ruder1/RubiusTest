
export class User implements IUser
{
    id: number;
    Surname:string;
    Name:string;
    LastName:string;
    Email:string;
    Salary:number;
    Divisions:Divisions[];
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
  Surname:string;
  Name:string;
  LastName:string;
  Email:string;
  Salary:number;
  Divisions:Divisions[];
}