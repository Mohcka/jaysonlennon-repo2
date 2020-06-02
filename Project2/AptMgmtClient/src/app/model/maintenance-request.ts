import { MaintenanceCloseReason } from 'src/enums/maintenance-close-reason';

export interface MaintenanceRequest {
  maintenanceRequestId: number;
  timeOpened: Date;
  timeClosed: Date | null;
  openedBy: string;
  closedBy: string | null;
  maintenanceRequestType: string;
  closeReason: MaintenanceCloseReason | null;
  openNotes: string;
  resolutionNotes: string | null;
  unitNumber: string;
}
