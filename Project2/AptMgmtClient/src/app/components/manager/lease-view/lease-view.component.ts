import { Component, OnInit } from '@angular/core';
import { Tenant } from './../../../Tenant';
@Component({
  selector: 'app-lease-view',
  templateUrl: './lease-view.component.html',
  styleUrls: ['./lease-view.component.css']
})
export class LeaseViewComponent implements OnInit {
  headers = ["Id", "Apartment", "Lease Start", "Lease End"]
  apt = ['100', '101', '102', '200', '201', '202', '300', '301', '302'];
  model = new Tenant(1,"","","","","");
  constructor() { }

  ngOnInit() {
  }

}
