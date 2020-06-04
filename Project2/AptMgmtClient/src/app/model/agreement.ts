export interface Agreement {
  agreementId: number;
  agreementTemplateId: number;
  tenantId: number;
  title: string;
  text: string;
  signedDate: Date | string | null;
  startDate: Date | string | null;
  endDate: Date | string | null;
}
