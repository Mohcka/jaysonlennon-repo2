import { ResourceUsageProjection } from './../../../model/resource-usage-projection';
import { Component, OnInit, Input } from '@angular/core';
import { MeteredResouceUsageEntry } from 'src/app/model/metered-resource-usage-entry';

@Component({
  selector: 'app-tenant-resource-usage-detail',
  templateUrl: './tenant-resource-usage-detail.component.html',
  styleUrls: ['./tenant-resource-usage-detail.component.css']
})
export class TenantResourceUsageDetailComponent implements OnInit {

  @Input() usageSummary: ResourceUsageProjection;
  @Input() usageData: MeteredResouceUsageEntry[];

  constructor() { }

  ngOnInit(): void { }

}
