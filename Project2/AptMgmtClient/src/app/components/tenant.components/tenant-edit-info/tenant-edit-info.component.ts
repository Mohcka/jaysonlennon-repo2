import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-tenant-edit-info',
  templateUrl: './tenant-edit-info.component.html',
  styleUrls: ['./tenant-edit-info.component.css'],
})
export class TenantEditInfoComponent implements OnInit {
  public tenantForm: FormGroup;
  /**
   * loading state provided to view component
   */
  public loading = false;
  /**
   * State to determine of the form has been submitted
   */
  public submitted = false;
  public returnUrl: string;
  public error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService
  ) {
    // go back home if logged in
    if (this.authService.currentUserValue) {
      this.router.navigate([this.authService.getHomeRoute()]);
    }
  }

  // convencience getter for easy access to form fields
  get f() {
    return this.tenantForm.controls;
  }

  ngOnInit() {
    this.tenantForm = this.formBuilder.group({
      firstName: [this.authService.currentUserValue.firstName, Validators.required],
      lastName: [this.authService.currentUserValue.lastName, Validators.required],
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit() {
    this.submitted = true;

    // stop if form is invalid
    if (this.tenantForm.invalid) {
      return;
    }

    this.loading = true;
    // TODO: finish
  }
}
