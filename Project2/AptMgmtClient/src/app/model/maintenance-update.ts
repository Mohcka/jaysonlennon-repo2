export interface MaintenanceRequestUpdate {
  maintenanceRequestId: number;
  maintenanceRequestType: string;
  openNotes: string;
  unitNumber: string;
  closed: boolean;
}
