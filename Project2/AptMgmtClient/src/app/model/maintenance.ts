export enum MaintenanceCloseReason {
  Completed,
  CanceledByManagement,
  CanceledByTenant,
}

/**
 * A standard maintance request issued by a tenant
 */
export interface MaintenanceRequest {
  maintenanceRequestId: number;
  timeOpened: string;
  timeClosed: string | null;
  openedBy: string;
  closedBy: string;
  maintenanceRequestType: string;
  closeReason: MaintenanceCloseReason | null;
  openNotes: string;
  resolutionNotes: string;
  unitNumber: string;
}
