import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/Services/data.service';
import { ReportService } from 'src/app/Services/report.service';
import { FilterReport, IReport } from 'src/app/models/Report.model';
import { FilterData, IDivisions } from 'src/app/models/User.model';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css'],
  providers: [DataService, ReportService]
})
export class ReportComponent implements OnInit {
  report:IReport[] = []
  filtredData: FilterData = new FilterData();

  constructor(private reportService: ReportService,
    private dataService:DataService) {}

  ngOnInit(): void {
    this.reportService.getReport().subscribe((result)=>
    {
      this.report = result;
      console.log(this.report)
    })
  }

  filterResults() {
    this.reportService
      .getFiltredReport(new FilterReport())
      .subscribe({
        next: (data: any) => {
        },
        error: (error) => console.log(error),
      });
  }
}
