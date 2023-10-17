import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay, map, tap } from 'rxjs/operators';
import { Divisions, IUser, User } from '../models/User.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  getDivisions(): Observable<Divisions[]> {
    let items = getMockDivision();
    return of(items).pipe(delay(500));
}

  getUsers(): Observable<IUser[]>
  {
    let items = getMockUsers();
    return of(items).pipe(delay(500));
  }

}

function getMockDivision()
{
  return[
  { id: 1, name: 'Финансовый',subdivision: 'Финансовый' },
  { id: 2, name: 'Логистики', subdivision: 'Финансовый'  },
  { id: 3, name: 'Закупок', subdivision: 'Финансовый'  },
  { id: 4, name: 'Развлечений', subdivision: 'Развлечений'  },
  { id: 5, name: 'Кадров', subdivision: 'Финансовый'  },
  ]
}

function getDivision()
{
  return [{ id: 1, name: 'Финансовый',subdivision: 'Финансовый' }]
}

function getMockUsers()
{
  return [
    {      "id": 1, "Surname": "Иванов", "Name": "Иван", "LastName": "Иванович", "Email":"example@example.com", "Salary": 200, "Divisions": 
    getDivision()},
    

    {      "id": 2, "Surname": "Петров", "Name": "Петр", "LastName": "Петрович", "Email":"example@example.com", "Salary": 250, "Divisions": 
    getDivision()}, 
    {      "id": 3, "Surname": "Сизов", "Name": "Алексей", "LastName": "Иванович", "Email":"example@example.com", "Salary": 300, "Divisions": 
    getDivision()}, 
    {      "id": 4, "Surname": "Чистов", "Name": "Георгий", "LastName": "Степнович", "Email":"example@example.com", "Salary": 100, "Divisions": 
    getDivision()},
    {      "id": 5, "Surname": "Лушков", "Name": "Лаврентий", "LastName": "Львович", "Email":"example@example.com", "Salary": 150, "Divisions": 
    getDivision()},
    {      "id": 6, "Surname": "Иванов", "Name": "Иван", "LastName": "Иванович", "Email":"mymail@google.com", "Salary": 200, "Divisions": 
    getDivision()},
  ]
}