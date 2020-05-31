export enum MaintenanceCloseReason {
  Completed,
  CanceledByManagement,
  CanceledByTenant
}

export interface MaintenanceRequest {
  maintenanceRequestId: number;
  timeOpened: string;
  timeClosed: string | null;
  openingUserId: number;
  closingUserId: number | null;
  maintenanceRequestType: string;
  closeReason: MaintenanceCloseReason | null;
  openNotes: string;
  resolutionNotes: string;
  internalNotes: string;
  unitNumber: string;
}
