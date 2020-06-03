import { ActivatedRoute, RouterModule } from '@angular/router';
import { BillService } from 'src/app/services/bill.service';
import { Component, OnInit } from '@angular/core';
import { Bill } from 'src/app/model/bill';

@Component({
  selector: 'app-tenant-page-bill-pay',
  templateUrl: './tenant-page-bill-pay.component.html',
  styleUrls: ['./tenant-page-bill-pay.component.css']
})
export class TenantPageBillPayComponent implements OnInit {

  public bill: Bill;

  constructor(private billService: BillService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getBill();
  }

  getBill(): void {
    const billingPeriod = this.route.snapshot.queryParams['periodId'];
    const resource = this.route.snapshot.queryParams['resource'];

    this.billService
      .getBillsInPeriod(billingPeriod)
      .subscribe(bills => {
        this.bill = bills.filter(b => b.resource === Number(resource)).pop();
      });
  }

}
