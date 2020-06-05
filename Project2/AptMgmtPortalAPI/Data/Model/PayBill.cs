using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DataModel
{
    public class PayBill
    {
        public int TenantId { get; set; }
        public ResourceType Resource { get; set; }
        public int BillingPeriodId { get; set; }
        public double Amount { get; set; }
    }
}