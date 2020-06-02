import { Resource } from 'src/types/Resource';

export interface Bill {
  billingPeriodId: number;
  /**
   * The type of resource that is being charged for
   */
  resource: Resource;
  periodStart: Date;
  periodEnd: Date;
  usage: number;
  rate: number;
  paid: number;
  cost: number;
  owed: number;
}
