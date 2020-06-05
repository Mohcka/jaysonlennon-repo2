import { ResourceUsageProjection } from './../../../model/resource-usage-projection';
import { ResourceUsageService } from './../../../services/resource-usage.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { MeteredResouceUsageEntry } from 'src/app/model/metered-resource-usage-entry';
import { Dictionary } from 'src/app/model/dictionary';

@Component({
  selector: 'app-tenant-page-view-resource-usage',
  templateUrl: './tenant-page-view-resource-usage.component.html',
})
export class TenantPageViewResourceUsageComponent implements OnInit {


  resourceUsageData: Dictionary<MeteredResouceUsageEntry[]>;
  resourceUsageSummaries: ResourceUsageProjection[];

  constructor(private resourceUsageService: ResourceUsageService) { }

  ngOnInit(): void {
    this.getUsageData();
    this.getSummaryData();
  }

  getUsageData() {
    this.resourceUsageService.getUsageEntries()
    .subscribe(data => this.resourceUsageData = data);
  }

  getSummaryData() {
    this.resourceUsageService.getProjections()
      .subscribe(summaries => this.resourceUsageSummaries = summaries);
  }

}
