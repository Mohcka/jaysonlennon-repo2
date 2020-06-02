using System;
using System.Collections.Generic;

namespace AptMgmtPortalAPI.DTO {
    public class TenantHome {
        public DateTime BillingPeriodStart { get; set; }
        public DateTime BillingPeriodEnd { get; set; }
        public List<BillDTO> Bills { get; set; }
    }
}