import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../../Services/data.service';
import { ModalService } from 'src/app/Services/modal.service';
import {
  IDivisions,
  IPage,
  IUser,
  IUserPage,
  User,
  UserPage,
  FilterData,
} from 'src/app/models/User.model';
import { filter, isEmpty, map, max } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-window',
  templateUrl: './main-window.component.html',
  styleUrls: ['./main-window.component.css'],
  providers: [DataService, ModalService]
})
export class MainWindowComponent implements OnInit {
  title = 'RuibiusApp';

  userPage: IUserPage = new UserPage();
  users: IUser[] = [];
  pages: IPage;
  divisions: IDivisions[] = [];

  //Переменные для фильтрации
  selectedDivision:number[] = [];
  filtredData: FilterData = new FilterData();
  minSalary:number = 0;
  maxSalary:number;

  //TODO: Мои костыли для редактирования пользователя, желательно убрать
  editable: boolean = false;
  id: number = 0;
  currentUser: User = new User();

  //Переменные для пагинации
  selectedPage: number = 1;
  pageSize: number = 5;
  countPages: number[] = [];
  pagesSize = [{ id: 5 }, { id: 10 }, { id: 15 }, { id: 20 }];

  constructor(
    private dataService: DataService,
    public modalService: ModalService,
    private router:Router
  ) {}

  currentRouter = this.router.url;

  ngOnInit() {
    
    //Получение списка отделов с сервера
    this.dataService.getDivisions().subscribe((res) => {
      this.divisions = res;
    });

    //Получение списка пользователей с сервера
    this.callGetUsers()
  }

  //Добаваление/Редактирование (получаем данные из модального окна)
  onAdd(item: any) {

    if (this.editable) 
    {
      this.dataService
        .updateUser(item)
        .subscribe((data: any) => 
        {
          this.users.splice(this.id, 1, item);
        });
    } 
    else 
    {
     
      this.dataService
        .createUser(item)
        .subscribe((data: any) =>
        { 
          this.users.push(item);     
          this.callGetUsers()    
        });
    }
  }

  //Флаг для Редактирования элемента
  EditItem(id: number, user: User) {
    this.id = id;
    this.currentUser = user;
    this.editable = true;
  }

  //Удаление элемента
  DeleteItem(user: User) {
    var tempArray = this.users.slice();
    var check = tempArray.findIndex((data) => data == user);
    tempArray.splice(check, 1);
    this.users = tempArray.slice();
    var temp = this.dataService.deleteUser(user.id).subscribe(()=>
    {
      this.callGetUsers()
    });
  }

  //Флаг для Добавления элемента
  onItemSelect() {
    this.editable = false;
    this.currentUser = new User();
  }

  //Вывести фамилию с инициалами
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

  //Отфильтровать список пользователей
  filterResults(value: string) {
    this.filtredData.minSalary = this.minSalary;
    this.filtredData.maxSalary = this.maxSalary;
    this.filtredData.divisions = this.selectedDivision;
    this.filtredData.searchString = value;
    this.callFilterService(1)
  }

  //Изменение размера отображаемых элементов на странице
  onPageChanged(pageIndex: number) {

    if (pageIndex > this.pages.totalPages)
    {
      pageIndex = this.pages.totalPages;
    }
    else if (pageIndex <= 0)
    {
      pageIndex = 1
    }

    this.dataService
      .getFiltredUsers(this.filtredData, pageIndex, this.pageSize)
      .subscribe({
        next: (data: any) => {
          this.userPage = data;
          this.pages = data.pages;
          this.users = data.users;

          this.ChangeCountPages(this.pages.totalPages);
          this.selectedPage = data.pageNumber;
        },
        error: (error) => console.log(error),
      });
  }

  //Переключение между страницами
  CurrentCountPageChanged() {
    this.onPageChanged(1)
  }

  //Изменение количества отображаемых переключений страниц
  ChangeCountPages(pageCount: number) {
    this.countPages = [];
    for (let index = 1; index <= pageCount; index++) {
      this.countPages.push(index);
    }
  }

  callGetUsers(){
    this.dataService
      .getUsers(this.selectedPage, this.pageSize)
      .subscribe((data: IUserPage) => {
        this.userPage = data;
        this.pages = data.pages;
        this.users = this.userPage.users;
        this.ChangeCountPages(data.pages.totalPages);
      });
 }

 callFilterService(index:number)
  {
    this.dataService
      .getFiltredUsers(this.filtredData, 1, this.pageSize)
      .subscribe({
        next: (data: any) => {
          this.userPage = data;
          this.pages = data.pages;
          this.users = data.users;
          this.ChangeCountPages(this.pages.totalPages);
        },
        error: (error) => console.log(error),
      });
  }
}
