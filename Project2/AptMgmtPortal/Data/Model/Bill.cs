using AptMgmtPortal.Entity;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.DataModel {
    public class Bill {
        public ResourceType Resource { get; set; }
        public BillingPeriod Period { get; set; }
        public double Usage { get; set; }
        public double Rate { get; set; }
        public double Paid { get; set; }
        public double Cost() => Usage * Rate;
        public double Owed() => Cost() - Paid;
    }
}