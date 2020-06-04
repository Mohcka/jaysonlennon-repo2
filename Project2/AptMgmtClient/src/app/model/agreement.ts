export interface Agreement {
  agreementId: number;
  agreementTemplateId: number;
  tenantId: number;
  title: string;
  text: string;
  signedDate: Date | null;
  startDate: Date | null;
  endDate: Date | null;
}
