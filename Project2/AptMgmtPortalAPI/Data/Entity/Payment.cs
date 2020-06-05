using AptMgmtPortalAPI.Types;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AptMgmtPortalAPI.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public ResourceType ResourceType { get; set; }

        [Column(TypeName = "NVARCHAR(48)")]
        public DateTime TimePaid { get; set; }
        public int BillingPeriodId { get; set; }
        public int TenantId { get; set; }
    }
}