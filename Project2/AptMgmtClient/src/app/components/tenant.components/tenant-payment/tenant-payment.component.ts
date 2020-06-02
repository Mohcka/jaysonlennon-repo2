import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tenant-payment',
  templateUrl: './tenant-payment.component.html',
  styleUrls: ['./tenant-payment.component.css'],
})
export class TenantPaymentComponent implements OnInit {
  paymentForm: FormGroup;
  /**
   * loading state provided to view component
   */
  loading = false;
  /**
   * State to determine of the form has been submitted
   */
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.paymentForm = this.formBuilder.group({
      amount: ['', Validators.required],
    });
  }

  // convencience getter for easy access to form fields
  get f() {
    return this.paymentForm.controls;
  }

  logit() {
    console.log('oh ok');
  }
}
