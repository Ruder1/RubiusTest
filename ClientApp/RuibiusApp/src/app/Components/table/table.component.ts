import {AfterViewInit, Component, Input, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { IUser, User } from 'src/app/models/User.model';
import { DataService } from 'src/app/Services/data.service';
import { ModalService } from 'src/app/Services/modal.service';


export interface UserData {
  id: string;
  name: string;
  progress: string;
  fruit: string;
}

/**
* @title Table with pagination
*/

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent  implements AfterViewInit{
  displayedColumns: string[] = ['id', 'fio', 'email', 'salary','control'];
  dataSource: MatTableDataSource<IUser>;
  filteredUserList:IUser[] =[];

  maxSalary:number;
  minSalary:number = 100;

  currentUser:User= new User()
  editable: boolean = false;
  id: number = 0;

  @Input() users:IUser[] = [];
  @ViewChild('paginator') paginator:MatPaginator
  @ViewChild(MatSort) sort: MatSort;

  constructor(private dataService:DataService, public modalService:ModalService) {}

  ngAfterViewInit() {
    this.dataService.getUsers().subscribe((res)=>
    {
      this.users = res
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  makeFio(user: User): string {
    var fio =
      user.Surname +
      ' ' +
      user.Name.substring(0, 1).toUpperCase() +
      '.' +
      user.LastName.substring(0, 1).toUpperCase() +
      '.';
    return fio;
  }

  EditItem(id: number, user: User) {
    this.id = id;
    this.currentUser = user;
    this.editable = true;
  }

  onAdd(item: any) {
    if (this.editable) {
      this.users.splice(this.id, 1, item);
    } else {
      this.users.push(item);
    }
    this.dataSource.data = this.users
  }

  DeleteItem(id: number, user: User) {
    var tempArray = this.dataSource.data.slice();
    var check = tempArray.findIndex(data=>data == user)
    tempArray.splice(check,1)
    this.dataSource.data = tempArray.slice()
  }

  filterResults(text: string) {
    if (!text) {
      this.filteredUserList = this.users;
    }
    
    //Использование фильтра
    this.filteredUserList = this.users
      .filter((users) => {
        //Проверка на Оклад
        if (this.maxSalary != undefined) {
          return (
            this.minSalary <= users.Salary && users.Salary <= this.maxSalary
          );
        } else {
          return this.minSalary <= users.Salary;
        }
      });
      this.dataSource.data = this.filteredUserList;
  }
}