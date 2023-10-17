import { NgModule } from '@angular/core';
import { NgSelectModule } from '@ng-select/ng-select';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { ModalComponent } from './Components/modal/modal.component';
import { MainWindowComponent } from './Components/main-window/main-window.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { TableModule } from './Components/table/table.module';
import { TableComponent } from './Components/table/table.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    ModalComponent,
    MainWindowComponent,TableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgSelectModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule,
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
