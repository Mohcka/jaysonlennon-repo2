using System;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DTO {
    public class FlatBill {
        public ResourceType Resource { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public int BillingPeriodId { get; set; }
        public double Usage { get; set; }
        public double Rate { get; set; }
        public double Paid { get; set; }
        public double Cost { get; set; }
        public double Owed { get; set; }

        public FlatBill(DataModel.Bill bill) {
            this.Resource = bill.Resource;
            this.PeriodStart = bill.Period.PeriodStart;
            this.PeriodEnd = bill.Period.PeriodEnd;
            this.BillingPeriodId = bill.Period.BillingPeriodId;
            this.Rate = bill.Rate;
            this.Usage = bill.Usage;
            this.Paid = bill.Paid;
            this.Cost = bill.Cost();
            this.Owed = bill.Owed();
        }
    }
}