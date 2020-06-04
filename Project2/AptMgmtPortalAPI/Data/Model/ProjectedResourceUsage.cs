using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DataModel {
    public class ProjectedResourceUsage {
        public int TenantId { get; set; }
        public ResourceType Resource { get; set; }
        public BillingPeriod Period { get; set; }
        public double ActualUsage { get; set; }
        public double ProjectedUsageTotal { get; set; }
        public double DaysRemainingInPeriod { get; set; }
        public double AverageDailyUsage { get; set; }
        public double Rate { get; set; }
        public double CurrentCost() => ActualUsage * Rate;
        public double ProjectedCost() => ProjectedUsageTotal * Rate;
    }
}