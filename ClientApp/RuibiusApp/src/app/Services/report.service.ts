import { Injectable } from '@angular/core';
import { FilterReport, IReport } from '../models/Report.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http:HttpClient) { }

  private url = "https://localhost:7072/api/v1/Report/";

  getReport():Observable<IReport[]>
  {
    return this.http.get<IReport[]>(this.url + 'AverageSalary');
  }

  getFiltredReport(filtredData:FilterReport)
  {
    return this.http.post(this.url + 'FilterAverageSalary', filtredData);     
  }
}
