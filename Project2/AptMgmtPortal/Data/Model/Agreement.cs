using System;

namespace AptMgmtPortal.DataModel {
    public class Agreement {
        public int AgreementId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}