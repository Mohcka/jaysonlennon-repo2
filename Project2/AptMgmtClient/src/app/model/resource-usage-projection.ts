import { Resource } from 'src/enums/Resource';

export interface ResourceUsageProjection {
    tenantId: number;
    resource: Resource;
    billingPeriodId: number;
    billingPeriodStart: Date;
    billingPeriodEnd: Date;
    actualUsage: number;
    projectedUsageTotal: number;
    daysRemainingInPeriod: number;
    averageDailyUsage: number;
    rate: number;
    currentCost: number;
    projectedCost: number;
}
