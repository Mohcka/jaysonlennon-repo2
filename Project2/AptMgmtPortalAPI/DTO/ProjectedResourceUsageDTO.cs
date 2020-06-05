using AptMgmtPortalAPI.DataModel;
using AptMgmtPortalAPI.Types;
using System;

namespace AptMgmtPortalAPI.DTO
{
    public class ProjectedResourceUsageDTO
    {
        public int TenantId { get; set; }
        public ResourceType Resource { get; set; }
        public int BillingPeriodId { get; set; }
        public DateTime BillingPeriodStart { get; set; }
        public DateTime BillingPeriodEnd { get; set; }
        public double ActualUsage { get; set; }
        public double ProjectedUsageTotal { get; set; }
        public double DaysRemainingInPeriod { get; set; }
        public double AverageDailyUsage { get; set; }
        public double Rate { get; set; }
        public double CurrentCost { get; set; }
        public double ProjectedCost { get; set; }

        public ProjectedResourceUsageDTO(ProjectedResourceUsage projection)
        {
            this.TenantId = projection.TenantId;
            this.Resource = projection.Resource;
            this.BillingPeriodId = projection.Period.BillingPeriodId;
            this.BillingPeriodStart = projection.Period.PeriodStart;
            this.BillingPeriodEnd = projection.Period.PeriodEnd;
            this.ActualUsage = projection.ActualUsage;
            this.ProjectedUsageTotal = projection.ProjectedUsageTotal;
            this.DaysRemainingInPeriod = projection.DaysRemainingInPeriod;
            this.AverageDailyUsage = projection.AverageDailyUsage;
            this.Rate = projection.Rate;
            this.CurrentCost = projection.CurrentCost();
            this.ProjectedCost = projection.ProjectedCost();
        }
    }
}