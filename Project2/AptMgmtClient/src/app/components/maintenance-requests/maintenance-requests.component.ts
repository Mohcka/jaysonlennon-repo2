import { Component, OnInit } from '@angular/core';
import { Maintenance } from '../../model/maintenance';
import { MaintenanceService } from '../../services/maintenance.service';

@Component({
  selector: 'app-maintenance-requests',
  templateUrl: './maintenance-requests.component.html',
  styleUrls: ['./maintenance-requests.component.css']
})
export class MaintenanceRequestsComponent implements OnInit {
  public maintenanceRequests: Maintenance[];
  constructor(private maintenanceService: MaintenanceService) { }

  ngOnInit() {
    this.getAllRequests();
  }

  public getAllRequests(): void {
    this.maintenanceService.getAll().subscribe(requests => this.maintenanceRequests = requests);
  }
}
