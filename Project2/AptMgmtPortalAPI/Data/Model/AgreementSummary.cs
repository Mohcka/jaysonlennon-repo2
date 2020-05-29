using System;

namespace AptMgmtPortalAPI.DataModel {
    public class AgreementSummary {
        public int AgreementId { get; set; }
        public string Title { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}