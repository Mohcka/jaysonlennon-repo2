import { Resource } from 'src/enums/Resource';

export interface MeteredResouceUsageEntry
{
  tenantId: number;
  sampleTime: Date;
  usageAmount: number;
  resourceType: Resource;
}