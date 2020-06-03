import { BillService } from 'src/app/services/bill.service';
import { Component, OnInit } from '@angular/core';
import { Bill } from 'src/app/model/bill';

@Component({
  selector: 'app-tenant-page-list-bills',
  templateUrl: './tenant-page-list-bills.component.html',
  styleUrls: ['./tenant-page-list-bills.component.css']
})
export class TenantPageListBillsComponent implements OnInit {

  public bills: Bill[];

  constructor(private billService: BillService) { }

  ngOnInit(): void {
  }

  getBillsThisPeriod(): void {
    this.billService.getBillsInCurrentPeriod().subscribe((bills) => this.bills = bills);
  }

}
