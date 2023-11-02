import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../../Services/data.service';
import { ModalService } from 'src/app/Services/modal.service';
import { Divisions, IPage, IUser, IUserPage, User, UserPage } from 'src/app/models/User.model';
import { isEmpty, map, max } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-main-window',
  templateUrl: './main-window.component.html',
  styleUrls: ['./main-window.component.css'],
})
export class MainWindowComponent implements OnInit {
  title = 'RuibiusApp';

  displayedColumns: string[] = ['id', 'fio', 'email', 'salary','control'];
  dataSource: MatTableDataSource<IUser>;
  
  @ViewChild('paginator') paginator:MatPaginator
  @ViewChild(MatSort) sort: MatSort;

  currentUser: User = new User();
  userPage:IUserPage = new UserPage;
  users: IUser[] = [];
  pages:IPage;
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

    this.dataService.getUsersController()
    .subscribe((data:IUserPage)=>    
      {
        this.userPage = data;
        this.pages = data.pages;
        this.users = this.userPage.users
        this.filteredUserList = this.users;
        this.dataSource = new MatTableDataSource(this.users)

        //TODO: Измненить сортировку и пагинацию на серверную
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort; 
      })  
  }

  //TODO: Добавить отправку на сервер
  onAdd(item: any) {
    if (this.editable) {
      this.users.splice(this.id, 1, item);
    } else {
      this.users.push(item);
    }
    this.dataSource.data = this.users
  }

  //TODO: Добавить отправку на сервер
  EditItem(id: number, user: User) {
    this.id = id;
    this.currentUser = user;
    this.editable = true;
  }

  //TODO: Добавить отправку на сервер
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
      user.surname +
      ' ' +
      user.name.substring(0, 1).toUpperCase() +
      '.' +
      user.lastName.substring(0, 1).toUpperCase() +
      '.';
    return fio;
  }

  filterResults(text: string) {


    //TODO:Убрать, есть фильтрация через сервер
    if (!text) {
      this.filteredUserList = this.users;
    }
    
    //Использование фильтра
    this.filteredUserList = this.users
    .filter((users) => {
      return (
        //Проверка на поиск
        users?.surname.toLowerCase().includes(text.toLowerCase()) ||
        users?.name.toLowerCase().includes(text.toLowerCase()) ||
        users?.lastName.toLowerCase().includes(text.toLowerCase()) ||
        users?.email.toLowerCase().includes(text.toLowerCase())
      );
    })
      .filter((users) => {
        //Проверка на Оклад
        if (this.maxSalary != undefined) {
          return (
            this.minSalary <= users.salary && users.salary <= this.maxSalary
          );
        } else {
          return this.minSalary <= users.salary;
        }
      });
      this.dataSource.data = this.filteredUserList;
  }  
}
