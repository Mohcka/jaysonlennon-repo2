import { Resource } from 'src/types/Resource';

export interface PayBillData {
  resource: Resource;
  billingPeriodId: number;
  amount: number;
}
