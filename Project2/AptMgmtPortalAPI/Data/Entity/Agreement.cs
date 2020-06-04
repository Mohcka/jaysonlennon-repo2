using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AptMgmtPortalAPI.Entity
{
    public class Agreement
    {
        public int AgreementId { get; set; }

        public int TenantId { get; set; }

        public int AgreementTemplateId { get; set;  }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime? SignedDate { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime? EndDate { get; set; }
    }
}
