import { Resource } from "src/enums/Resource";

export interface MeteredResouceUsageEntry
{
  TenantId: number;
  SampleTime: Date;
  UsageAmount: number;
  ResourceType: Resource;
}