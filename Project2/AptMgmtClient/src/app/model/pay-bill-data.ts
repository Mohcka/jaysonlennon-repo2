import { Resource } from 'src/enums/Resource';

export interface PayBillData {
  tenantId: number;
  resource: Resource;
  billingPeriodId: number;
  amount: number;
}
