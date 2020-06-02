import { Resource } from 'src/types/Resource';

export interface PayBillData {
  tenantId: number;
  resource: Resource;
  billingPeriodId: number;
  amount: number;
}
