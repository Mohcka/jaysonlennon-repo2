using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity 
{ 
    public class Payment
    {
        public int PaymentId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Amount { get; set; }
        public ResourceType ResourceType { get; set; }
        public DateTimeOffset? Timepaid { get; set; }
        public int BillingPeriodId { get; set; }
        public BillingPeriod BillingPeriods { get; set; }

        public int TenentId { get; set; }
        public Tenant Tenent { get; set; }

    }
}