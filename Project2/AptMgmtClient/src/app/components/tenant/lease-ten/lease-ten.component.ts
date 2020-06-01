import { Component, OnInit } from '@angular/core';
import { Tenant } from './../../../Tenant';
@Component({
  selector: 'app-lease-ten',
  templateUrl: './lease-ten.component.html',
  styleUrls: ['./lease-ten.component.css']
})
export class LeaseTenComponent implements OnInit {
  row = [];
  constructor() { }

  ngOnInit(): void {
  }

}
