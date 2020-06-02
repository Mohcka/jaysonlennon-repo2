import { Tenant } from './../../../Tenant';
import { Component, OnInit } from '@angular/core';
import { LeaseViewComponent } from './../lease-view/lease-view.component';
import { LeaseAddComponent } from './../lease-add/lease-add.component';

@Component({
  selector: 'app-lease-man',
  templateUrl: './lease-man.component.html',
  styleUrls: ['./lease-man.component.css']
})
export class LeaseManComponent implements OnInit {
  headers = ["Id", "Apartment", "Lease Start", "Lease End"]
  apt = ['100', '101', '102', '200', '201', '202', '300', '301', '302'];
  model = new Tenant(1,"","","","","");

  constructor() { }

  ngOnInit(): void {
  }

}