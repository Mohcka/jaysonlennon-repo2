import { Component, OnInit, Input } from '@angular/core';
import { Bill } from 'src/app/model/bill';
import { Resource } from 'src/enums/Resource';
import { BillService } from 'src/app/services/bill.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css'],
})
export class BillComponent implements OnInit {
  billId: number;
  resource: Resource;
  bill: Bill;

  constructor(
    private billService: BillService,
    private route: ActivatedRoute,
    private router: Router,
    public authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.billId = +params['id'];
      this.resource = Resource[`${params['resource']}`];

      this.getBill(this.billId);
    });
  }

  getBill(id: number) {
    // Retreive the specific resource from the list of bills from
    // the billing period
    this.billService.getOne(id).subscribe((bills: Bill[]) => {
      this.bill = bills.find((bill: Bill) => bill.resource === this.resource);
    });
  }

  public payBill(
    resource: Resource,
    billingPeriodId: number,
    amount: number
  ): void {
    this.billService
      .payBill({
        // Signed in user should be tenant
        tenantId: this.authService.currentUserValue.userId,
        resource: resource,
        billingPeriodId: billingPeriodId,
        amount: amount,
      })
      .subscribe((_) => this.router.navigate(['/tenant']));
  }
}
