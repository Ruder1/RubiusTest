import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../../Services/data.service';
import { ModalService } from 'src/app/Services/modal.service';
import { Divisions, IUser, User } from 'src/app/models/User.model';
import { isEmpty, max } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-main-window',
  templateUrl: './main-window.component.html',
  styleUrls: ['./main-window.component.css'],
})
export class MainWindowComponent implements OnInit, AfterViewInit {
  title = 'RuibiusApp';

  displayedColumns: string[] = ['id', 'fio', 'email', 'salary','control'];
  dataSource: MatTableDataSource<IUser>;
  
  @ViewChild('paginator') paginator:MatPaginator
  @ViewChild(MatSort) sort: MatSort;

  currentUser: User = new User();
  users: IUser[] = [];
  selectedDivision: number[] = [];
  division: Divisions[] = [];

  //Переменные для фильтрации
  filteredUserList: IUser[] = [];
  minSalary: number = 0;
  maxSalary: number;

  //TODO: Мои костыли, желательно убрать
  editable: boolean = false;
  id: number = 0;

  constructor(
    private dataService: DataService,
    public modalService: ModalService
  ) {}

  ngOnInit() {
    this.dataService.getDivisions().subscribe((res) => {
      this.division = res;
    });
  }

  ngAfterViewInit() {
    this.dataService.getUsers().subscribe((res)=>
    {
      this.users = res
      this.filteredUserList = this.users;
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      
    });
  }

  onAdd(item: any) {
    if (this.editable) {
      this.users.splice(this.id, 1, item);
    } else {
      this.users.push(item);
    }
    this.dataSource.data = this.users
  }

  EditItem(id: number, user: User) {
    this.id = id;
    this.currentUser = user;
    this.editable = true;
  }

  DeleteItem(id: number, user: User) {
    var tempArray = this.dataSource.data.slice();
    var check = tempArray.findIndex(data=>data == user)
    tempArray.splice(check,1)
    this.dataSource.data = tempArray.slice()
  }

  onItemSelect() {
    this.editable = false;
    this.currentUser = new User();
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

  filterResults(text: string) {
    if (!text) {
      this.filteredUserList = this.users;
    }
    
    //Использование фильтра
    this.filteredUserList = this.users
    .filter((users) => {
      return (
        //Проверка на поиск
        users?.Surname.toLowerCase().includes(text.toLowerCase()) ||
        users?.Name.toLowerCase().includes(text.toLowerCase()) ||
        users?.LastName.toLowerCase().includes(text.toLowerCase()) ||
        users?.Email.toLowerCase().includes(text.toLowerCase())
      );
    })
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

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
