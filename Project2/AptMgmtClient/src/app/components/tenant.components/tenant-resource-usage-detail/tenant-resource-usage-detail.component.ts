import { ResourceUsageProjection } from './../../../model/resource-usage-projection';
import { Component, OnInit, Input } from '@angular/core';
import { MeteredResouceUsageEntry } from 'src/app/model/metered-resource-usage-entry';
import { ChartType } from 'angular-google-charts';
import { Resource } from 'src/enums/Resource';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-tenant-resource-usage-detail',
  templateUrl: './tenant-resource-usage-detail.component.html',
  styleUrls: ['./tenant-resource-usage-detail.component.css']
})
export class TenantResourceUsageDetailComponent implements OnInit {

  @Input() usageSummary: ResourceUsageProjection;
  @Input() usageData: MeteredResouceUsageEntry[];

  chartOptionsReady = false;
  chartType: ChartType = ChartType.ColumnChart;
  chartData: (string | number)[][] = [];
  chartOptions: any;

  resourceType: Resource;
  unitName: string;

  constructor() { }

  ngOnInit(): void {
    this.resourceType = this.usageSummary.resource;
    this.buildChartData();
    this.configureOptions();
    this.configureUnitName();
    this.chartOptionsReady = true;
  }

  configureUnitName() {
    switch (this.resourceType) {
      case Resource.Power: this.unitName = 'kWh'; break;
      case Resource.Water: this.unitName = 'cu.ft.'; break;
      default: this.unitName = '';
    }
  }

  billingPeriodFormat(date: Date) {
    const dateObj = new Date(date);
    const month = new Intl.DateTimeFormat('en-US', { month: '2-digit' }).format(dateObj);
    const day = new Intl.DateTimeFormat('en-US', { day: '2-digit' }).format(dateObj);
    const year = new Intl.DateTimeFormat('en-US', { year: 'numeric' }).format(dateObj);
    return `${year}-${month}-${day}`;
  }

  buildChartData() {
    let firstSampleDate: Date;
    let secondSampleDate: Date;
    if (this.usageData.length > 1) {
      firstSampleDate = this.usageData[0].sampleTime;
      secondSampleDate = this.usageData[this.usageData.length - 1].sampleTime;
    } else if (this.usageData.length === 0) {
      firstSampleDate = null;
      secondSampleDate = null;
    } else {
      firstSampleDate = this.usageData[0].sampleTime;
      secondSampleDate = this.usageData[0].sampleTime;
    }

    this.expandChartData(firstSampleDate, secondSampleDate);
  }

  formatDate(dateStr: string): string {
    const date = new Date(dateStr);
    const month = new Intl.DateTimeFormat('en-US', { month: 'short' }).format(date);
    const day = new Intl.DateTimeFormat('en-US', { day: '2-digit' }).format(date);
    return `${month} ${day}`;
  }

  // Fills out the chart data until the end of the period.
  expandChartData(firstSampleDate: Date, lastSampleDate: Date) {
    // TODO: this hurts
    const periodStart = new Date(this.usageSummary.billingPeriodStart.toString());
    const periodEnd = new Date(this.usageSummary.billingPeriodEnd.toString());

    // Add empty entries prior to metered entries, if needed.
    const firstSampleDateObj = new Date(firstSampleDate.toString());
    let numEmptyStartDays = (firstSampleDateObj.getTime() - periodStart.getTime()) / 86400000;
    if (numEmptyStartDays < 1) {
      numEmptyStartDays = 0;
    }
    for (let i = 0; i < numEmptyStartDays; i++) {
      const date = new Date(periodStart);
      date.setDate(date.getDate() + i);
      this.chartData.push([this.formatDate(date.toString()), 0]);
    }

    // Add metered entries.
    for (let i = 0; i < this.usageData.length; i++) {
      const entry = this.usageData[i];
      const formattedDate = this.formatDate(entry.sampleTime.toString());
      this.chartData.push([formattedDate, entry.usageAmount]);
    }

    // Add empty entries after metered entries, if needed.
    const lastSampleDateObj = new Date(lastSampleDate.toString());
    let numEmptyEndDays = (periodEnd.getTime() - lastSampleDateObj.getTime()) / 86400000;
    if (numEmptyEndDays < 1) {
      numEmptyEndDays = 0;
    }
    for (let i = 1; i <= numEmptyEndDays; i++) {
      const date = new Date(lastSampleDateObj);
      date.setDate(date.getDate() + i);
      this.chartData.push([this.formatDate(date.toString()), 0]);
    }
  }

  configureOptions() {
    const options = {
      title: '',
      colors: [],
      hAxis: {
        title: 'Day',
        showTextEvery: 7
      },
      legend: {
        position: 'none'
      },
    };
    switch (this.resourceType) {
      case Resource.Water:
        options.title = 'Water Usage in cubic feet';
        options.colors = ['blue'];
        break;
      case Resource.Power:
        options.title = 'Power Usage in kWh';
        options.colors = ['green'];
        break;
      default: break;
    }
    this.chartOptions = options;
  }

}
