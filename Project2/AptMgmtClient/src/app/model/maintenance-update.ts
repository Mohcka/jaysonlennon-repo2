import { MaintenanceCloseReason } from 'src/enums/maintenance-close-reason';

export interface MaintenanceRequestUpdate {
  maintenanceRequestId: number;
  maintenanceRequestType: string;
  openNotes: string;
  unitNumber: string;
  closeReason: MaintenanceCloseReason;
}
