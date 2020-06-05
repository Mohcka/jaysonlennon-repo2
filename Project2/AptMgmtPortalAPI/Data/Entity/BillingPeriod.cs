using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AptMgmtPortalAPI.Entity
{
    public class BillingPeriod
    {
        public int BillingPeriodId { get; set; }

        [Column(TypeName = "NVARCHAR(48)")]
        public DateTime PeriodStart { get; set; }

        [Column(TypeName = "NVARCHAR(48)")]
        public DateTime PeriodEnd { get; set; }
    }
}
