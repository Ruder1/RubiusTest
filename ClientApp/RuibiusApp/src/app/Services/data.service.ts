import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { delay, map, tap } from 'rxjs/operators';
import { IDivisions, IUser, IUserPage, User, UserPage } from '../models/User.model';
import {HttpClient, HttpParams} from '@angular/common/http'

@Injectable(
  {
  providedIn: 'root'
}
)
export class DataService {

  constructor(private http:HttpClient) { }

  private url = "https://localhost:7072/api/v1/User/";
  // private url = "https://localhost:7072/api/v1/User/Users?page=1&pageSize=5";

   getUsersController(page: number, pageSize: number): Observable<IUserPage>
  {
    const params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize)
    return this.http.get<IUserPage>(this.url + 'Users',{params}); 
  }

  getDivisions(): Observable<IDivisions[]> {

    let items = this.http.get<IDivisions[]>(this.url + 'GetDivision');
    return items;
  }

//   getMock(): Observable<any[]> {
//     let items = getMockDivision();
//     return of(items).pipe(delay(500));
// }
}

// function getMockDivision()
// {
//   return[
//   { id: 1, name: 'Финансовый',subdivision: 'Финансовый' },
//   { id: 2, name: 'Логистики', subdivision: 'Финансовый'  },
//   { id: 3, name: 'Закупок', subdivision: 'Финансовый'  },
//   { id: 4, name: 'Развлечений', subdivision: 'Развлечений'  },
//   { id: 5, name: 'Кадров', subdivision: 'Финансовый'  },
//   ]
// }
