using AptMgmtPortal.Entity;

namespace AptMgmtPortal.DataModel
{
    public class TenantResourceUsageSummary
    {
        public ResourceType ResourceType { get; set; }
        public decimal Usage { get; set; }
    }
}
