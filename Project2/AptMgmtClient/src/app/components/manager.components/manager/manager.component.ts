import { Component, OnInit } from '@angular/core';
import { Tenant } from 'src/app/Tenant';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TenantService } from 'src/app/services/tenant.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
  tenantList: Tenant[];
  constructor(private authService: AuthenticationService, private tenantSerivce: TenantService) { }

  ngOnInit(): void {
  }

  getTenantList(): void {
    // this
  }

}
