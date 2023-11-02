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
    this.tempUser.surname = this.user.surname,
    this.tempUser.name = this.user.name
    this.tempUser.lastName = this.user.lastName
    this.tempUser.email = this.user.email
    this.tempUser.salary = this.user.salary
    this.tempUser.divisions = this.user.divisions
  }

  Add()
  {
    this.user = this.tempUser
    this.userChange.emit(this.user)
  }

  ChooseDivision(item:any)
  {
    console.log(item)
    this.user.divisions.push(item)
  }
}
