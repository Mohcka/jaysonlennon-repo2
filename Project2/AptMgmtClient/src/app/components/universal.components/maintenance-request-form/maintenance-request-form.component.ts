import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MaintenanceService } from 'src/app/services/maintenance.service';

@Component({
  selector: 'app-maintenance-request-form',
  templateUrl: './maintenance-request-form.component.html',
  styleUrls: ['./maintenance-request-form.component.css'],
})
export class MaintenanceRequestFormComponent implements OnInit {
  public maintenanceRequestForm: FormGroup;
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

  // TODO: Get maintenance request type samples from server
  public maintenanceRequestTypes: string[] = [
    'Plumbing',
    'Upholstry',
    'Electrical',
  ];

  constructor(
    private maintenanceService: MaintenanceService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.maintenanceRequestForm = this.formBuilder.group({
      type: ['Electrical', Validators.required],
      notes: ['', Validators.required],
    });
  }

  get f() {
    return this.maintenanceRequestForm.controls;
  }

  onSubmit(): void {
    // TODO: submit form to server
    console.log('maintenance request submitted');
    console.log(this.f.type.value);
    console.log(this.f.notes.value);

    this.submitted = true;

    // stop if form is invalid
    if (this.maintenanceRequestForm.invalid) {
      return;
    }

    this.maintenanceService
      .createNewRequest({
        openNotes: this.f.notes.value,
        maintenanceRequestType: this.f.type.value,
      })
      .subscribe((_) => this.router.navigate(['/tenant/maintenance/list']));
  }
}
