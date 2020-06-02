import { Resource } from 'src/enums/Resource';

export interface Bill {
    tenantId: number;
    resource: Resource;
    periodStart: Date;
    periodEnd: Date;
    billingPeriodId: number;
    usage: number;
    rate: number;
    paid: number;
    cost: number;
    owed: number;
}
