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
import { isEmpty, map, max } from 'rxjs';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

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
  selectedDivision: any;
  filtredData: FilterData = new FilterData();

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
    public modalService: ModalService
  ) {}

  ngOnInit() {
    console.log('Init Main');
    //Получение списка отделов с сервера
    this.dataService.getDivisions().subscribe((res) => {
      this.divisions = res;
    });

    //Получение списка пользователей с сервера
    this.dataService
      .getUsers(this.selectedPage, this.pageSize)
      .subscribe((data: IUserPage) => {
        this.userPage = data;
        this.pages = data.pages;
        this.users = this.userPage.users;
        this.ChangeCountPages(data.pages.totalPages);
      });
  }

  //Добаваление/Редактирование (получаем данные из модального окна)
  onAdd(item: any) {
    console.log(item);
    if (this.editable) {
      this.users.splice(this.id, 1, item);
      this.dataService
        .updateUser(item)
        .subscribe((data: any) => console.log(data));
    } else {
      this.users.push(item);
      this.dataService
        .createUser(item)
        .subscribe((data: any) => console.log(data));
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

    var temp = this.dataService.deleteUser(user.id).subscribe();
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
    this.filtredData.divisions = this.selectedDivision;
    this.filtredData.searchString = value;
    console.log(this.filtredData);
    this.dataService
      .getFiltredUsers(this.filtredData, this.selectedPage, this.pageSize)
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

  //Изменение размера отображаемых элементов на странице
  onPageChanged(pageIndex: number) {
    console.log(this.selectedPage);
    if (this.selectedPage == undefined) {
      this.selectedPage = 1;
    } else if (this.pages.totalPages >= pageIndex) {
      this.pages.pageNumber;
      this.selectedPage = pageIndex;
    }
    this.dataService
      .getFiltredUsers(this.filtredData, this.selectedPage, this.pageSize)
      .subscribe({
        next: (data: any) => {
          this.userPage = data;
          this.pages = data.pages;
          this.users = data.users;

          this.ChangeCountPages(this.pages.totalPages);
          this.CurrentPageChanged(this.pages.totalPages);
          this.selectedPage = data.pageNumber;
        },
        error: (error) => console.log(error),
      });
  }

  //Переключение между страницами
  CurrentPageChanged(pageIndex: number) {
    if (this.pages.hasNextPage || this.pages.hasPreviousPage) {
      this.selectedPage = pageIndex;
    }
  }

  //Изменение количества отображаемых переключений страниц
  ChangeCountPages(pageCount: number) {
    this.countPages = [];
    for (let index = 0; index < pageCount; index++) {
      this.countPages.push(index);
    }
  }
}
