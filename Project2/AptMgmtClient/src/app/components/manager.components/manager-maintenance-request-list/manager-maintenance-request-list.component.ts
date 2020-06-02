import { Component, OnInit } from '@angular/core';
import { MaintenanceService } from 'src/app/services/maintenance.service';
import { MaintenanceRequest } from 'src/app/model/maintenance-request';

@Component({
  selector: 'app-manager-maintenance-request-list',
  templateUrl: './manager-maintenance-request-list.component.html',
  styleUrls: ['./manager-maintenance-request-list.component.css']
})
export class ManagerMaintenanceRequestListComponent implements OnInit {

  public maintenanceRequests: MaintenanceRequest[];

  constructor(private maintenanceService: MaintenanceService) { }

  ngOnInit() {
    this.getRequests();
  }

  public getRequests() {
    this.maintenanceService.getAll().subscribe(data => this.maintenanceRequests = data);
  }

  public getOpenRequests() {
    this.maintenanceService.getAll().subscribe(data => {
      data = data.filter(r => r.timeClosed == null);
      this.maintenanceRequests = data;
    });
  }

  public getClosedRequests() {
    this.maintenanceService.getAll().subscribe(data => {
      data = data.filter(r => r.timeClosed != null);
      this.maintenanceRequests = data;
    });
  }

}
