import { Component, OnInit } from '@angular/core';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { MaintenanceRequest } from 'src/app/model/maintenance-request';

@Component({
  selector: 'app-maintenance-requests',
  templateUrl: './maintenance-requests.component.html',
  styleUrls: ['./maintenance-requests.component.css']
})
export class MaintenanceRequestsComponent implements OnInit {
  public maintenanceRequests: MaintenanceRequest[];
  constructor(private maintenanceService: MaintenanceService) { }

  ngOnInit() {
    this.getAllRequests();
  }

  public getAllRequests(): void {
    this.maintenanceService.getAll().subscribe(requests => this.maintenanceRequests = requests);
  }
}
