import { Resource } from 'src/types/Resource';

export interface Bill {
    resource: Resource;
    periodStart: Date;
    periodEnd: Date;
    usage: number;
    rate: number;
    paid: number;
    cost: number;
    owed: number;
}
