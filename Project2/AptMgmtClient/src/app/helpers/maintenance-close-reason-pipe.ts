// https://dzone.com/articles/why-we-shound-not-use-function-inside-angular-temp
import { Pipe, PipeTransform } from '@angular/core';
import { MaintenanceCloseReason } from 'src/enums/maintenance-close-reason';

@Pipe({
  name: 'maintenanceCloseReasonAsString',
  pure: true
})

export class MaintenanceCloseReasonEnumPipe implements PipeTransform {

  transform(value: MaintenanceCloseReason, args?: any): String {
    return this.resourceAsString(value);
  }

  resourceAsString(value: MaintenanceCloseReason): String {
      switch (value) {
          case MaintenanceCloseReason.Completed: return 'Completed';
          case MaintenanceCloseReason.CanceledByManagement: return 'Canceled by Management';
          case MaintenanceCloseReason.CanceledByTenant: return 'Canceled by Tenant';
      }
  }
}