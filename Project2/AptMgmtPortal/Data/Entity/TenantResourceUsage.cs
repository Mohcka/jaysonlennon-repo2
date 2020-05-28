using System;
using AptMgmtPortal.Types;
namespace AptMgmtPortal.Entity
{
    public class TenantResourceUsage
    {
        public int TenantResourceUsageId { get; set; }
        public DateTime SampleTime { get; set; }
        public double UsageAmount { get; set; }
        public ResourceType ResourceType { get; set; }
        public int TenantId { get; set; }
    }
}
