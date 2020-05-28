using AptMgmtPortal.Entity;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.DataModel {
    public class PayBill {
        public ResourceType Resource { get; set; }
        public int BillingPeriodId { get; set; }
        public double Amount { get; set; }
    }
}