using System;

namespace AptMgmtPortalAPI.DTO {
    public class AgreementDTO {
        public int AgreementId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public AgreementDTO() {}
        public AgreementDTO(DataModel.Agreement agreement) {
            this.AgreementId = agreement.AgreementId;
            this.Title = agreement.Title;
            this.Text = agreement.Text;
            this.SignedDate = agreement.SignedDate;
            this.StartDate = agreement.StartDate;
            this.EndDate = agreement.EndDate;
        }
    }
}