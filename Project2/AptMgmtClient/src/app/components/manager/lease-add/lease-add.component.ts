import { Component, OnInit } from '@angular/core';
import { Tenant } from './../../../Tenant';

@Component({
  selector: 'app-lease-add',
  templateUrl: './lease-add.component.html',
  styleUrls: ['./lease-add.component.css']
})
export class LeaseAddComponent implements OnInit {
  apt = ['100', '101', '102', '200', '201', '202', '300', '301', '302'];
  model = new Tenant(1,"","","","","");
  constructor() { }

  ngOnInit() {
  }

}
