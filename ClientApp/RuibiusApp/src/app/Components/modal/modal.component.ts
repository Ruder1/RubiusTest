import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DataService } from '../../Services/data.service';
import { ModalService } from 'src/app/Services/modal.service';
import { Divisions, User } from 'src/app/models/User.model';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit{
  @Input()user:User = new User();
  @Output() userChange = new EventEmitter<User>();
  
  tempUser:User = new User();
  division:Divisions[] = [];


  constructor(public modalService:ModalService, 
    private dataService: DataService){}

  ngOnInit() {
    this.dataService.getDivisions()
    .subscribe((res)=>{
    this.division = res;
  })
    //TODO: Исправить копирование элементов (По значение, а не по ссылке)
    this.tempUser.Surname = this.user.Surname,
    this.tempUser.Name = this.user.Name
    this.tempUser.LastName = this.user.LastName
    this.tempUser.Email = this.user.Email
    this.tempUser.Salary = this.user.Salary
    this.tempUser.Divisions = this.user.Divisions
  }

  Add()
  {
    this.user = this.tempUser
    this.userChange.emit(this.user)
  }

  ChooseDivision(item:any)
  {
    console.log(item)
    this.user.Divisions.push(item)
  }
}
