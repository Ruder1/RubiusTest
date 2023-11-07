import { NgModule } from '@angular/core';
import { NgSelectModule } from '@ng-select/ng-select';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { ModalComponent } from './Components/modal/modal.component';
import { MainWindowComponent } from './Components/main-window/main-window.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule } from '@angular/common/http';
import { ReportComponent } from './Components/report/report.component';
import { Route, RouterModule, Routes } from '@angular/router';

const appRoutes: Routes =
[
  { path: '', component: MainWindowComponent },
  { path: 'report', component: ReportComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    ModalComponent,
    MainWindowComponent,
    ReportComponent
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgSelectModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule, 
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
