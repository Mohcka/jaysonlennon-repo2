using AptMgmtPortal.Entity;

namespace AptMgmtPortal.DataModel {
    public class Bill {
        public ResourceType Resource { get; set; }
        public BillingPeriod Period { get; set; }
        public decimal Usage { get; set; }
        public decimal Rate { get; set; }
        public decimal Cost() => Usage * Rate;
    }
}