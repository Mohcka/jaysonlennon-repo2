using System;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Entity
{
    public class ResourceUsageRate
    {
        public int ResourceUsageRateId { get; set; }
        public ResourceType ResourceType { get; set; }
        public double Rate { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}

