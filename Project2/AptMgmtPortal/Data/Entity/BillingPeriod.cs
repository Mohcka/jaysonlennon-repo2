using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity 
{ 
    public class BillingPeriod
    {
        public int BillingPeriodId { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime PeriodStart { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime PeriodEnd { get; set; }
    }
}
