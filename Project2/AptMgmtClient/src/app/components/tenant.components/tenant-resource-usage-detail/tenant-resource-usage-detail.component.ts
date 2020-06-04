import { ResourceUsageProjection } from './../../../model/resource-usage-projection';
import { Component, OnInit, Input } from '@angular/core';
import { MeteredResouceUsageEntry } from 'src/app/model/metered-resource-usage-entry';
import { ChartType } from 'angular-google-charts';
import { Resource } from 'src/enums/Resource';

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

  constructor() { }

  ngOnInit(): void {
    this.resourceType = this.usageSummary.resource;
    this.buildChartData();
    this.configureOptions();
    this.chartOptionsReady = true;
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

    this.chartData = this.usageData.map(e => [this.formatDate(e.sampleTime.toString()), e.usageAmount]);

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
    const paddedChartData: (string | number)[][] = [];

    const periodStart = new Date(this.usageSummary.billingPeriodStart.toString());
    const periodEnd = new Date(this.usageSummary.billingPeriodEnd.toString());
    const daysRemaining = this.usageSummary.daysRemainingInPeriod;

    let firstSampleDate2 = new Date(firstSampleDate.toString());
    let way = firstSampleDate2.getTime() - periodStart.getTime();
    const numDaysEnd = new Date(firstSampleDate.toString());

    const lastSamplingDate = new Date(periodEnd);
    lastSamplingDate.setDate(lastSamplingDate.getDate() - daysRemaining);

    for (let i = 1; i <= daysRemaining; i++) {
      const date = new Date(lastSamplingDate);
      date.setDate(date.getDate() + i);

      this.chartData.push([this.formatDate(date.toString()), 0]);
    }
  }

  configureOptions() {
    const options = {
      title: '',
      colors: [],
      legend: {
        position: 'none'
      },
    };
    switch (this.resourceType) {
      case Resource.Water:
        options.title = 'Water Usage in cu.ft./day';
        options.colors = ['blue'];
        break;
      case Resource.Power:
        options.title = 'Power Usage in kWh/day';
        options.colors = ['green'];
        break;
      default: break;
    }
    this.chartOptions = options;
  }

}
