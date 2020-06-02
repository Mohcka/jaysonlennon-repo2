using System;

namespace AptMgmtPortalAPI.DTO {
    public class SignAgreementDTO {
        public int AgreementId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}