using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AptMgmtPortal.Entity
{
    public class TenantAgreement
    {
        public int TenantAgreementId { get; set; }

        public int TenantId { get; set; }

        public int AgreementId { get; set;  }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime SignedDate { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime StartDate { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime EndDate { get; set; }
    }
}
