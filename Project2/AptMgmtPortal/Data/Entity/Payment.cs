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
        public double Amount { get; set; }
        public ResourceType ResourceType { get; set; }
        public DateTime TimePaid { get; set; }
        public int BillingPeriodId { get; set; }
        public int TenantId { get; set; }
    }
}