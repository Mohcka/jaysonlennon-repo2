using System;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Entity 
{ 
    public class Payment
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public ResourceType ResourceType { get; set; }
        public DateTime TimePaid { get; set; }
        public int BillingPeriodId { get; set; }
        public int TenantId { get; set; }
    }
}