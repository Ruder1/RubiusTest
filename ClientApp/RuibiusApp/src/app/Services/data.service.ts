import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay, map, tap } from 'rxjs/operators';
import { FilterData, IDivisions, IUser, IUserPage, User, UserPage } from '../models/User.model';
import {HttpClient, HttpParams} from '@angular/common/http'

@Injectable(
  {
  providedIn: 'root'
}
)
export class DataService {

  constructor(private http:HttpClient) { }

  private url = "https://localhost:7072/api/v1/User/";

   getUsers(page: number, pageSize: number): Observable<IUserPage>
  {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize)
    return this.http.get<IUserPage>(this.url + 'Users',{params}); 
  }

  getDivisions(): Observable<IDivisions[]> {
    return this.http.get<IDivisions[]>(this.url + 'GetDivisions');
  }

  createUser(User:IUser)
  {
    return this.http.post(this.url + 'CreateUser', User);
  }

  updateUser(User: IUser) {
    return this.http.put(this.url + 'ChangeUser', User);
  }

  deleteUser(id: number) {
    return this.http.delete(this.url + 'DeleteUser/' + id);
  }

  getFiltredUsers(filtredData:FilterData, page:number, pageSize:number)
  {
    const params = new HttpParams()
    .set('page', page)
    .set('pageSize', pageSize)
    return this.http.post(this.url + 'FiltredUsers', filtredData, {params});     
  }

}