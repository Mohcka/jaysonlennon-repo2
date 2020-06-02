export interface Agreement {
  agreementId: number;
  title: string;
  text: string;
  signedDate: Date | null;
  startDate: Date;
  endDate: Date;
}
