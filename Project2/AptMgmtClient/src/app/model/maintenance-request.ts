import { MaintenanceCloseReason } from 'src/enums/maintenance-close-reason';

export interface MaintenanceRequest {
  maintenanceRequestId: Number;
  timeOpened: Date;
  timeClosed: Date;
  openedBy: string;
  closedBy: string;
  maintenanceRequestType: string;
  closeReason: MaintenanceCloseReason;
  openNotes: string;
  resolutionNotes: string;
  unitNumber: string;
}