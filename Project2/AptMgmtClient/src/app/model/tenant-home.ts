import { Bill } from './bill';

export interface TenantHome {
    billingPeriodStart: Date;
    billingPeriodEnd: Date;
    bills: Bill[];
}