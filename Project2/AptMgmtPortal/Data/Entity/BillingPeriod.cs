using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity 
{ 
    public class BillingPeriod
    {
        public int BillingPeriodId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
