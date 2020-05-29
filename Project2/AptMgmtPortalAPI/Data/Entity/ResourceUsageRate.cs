using System;
using System.ComponentModel.DataAnnotations.Schema;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Entity
{
    public class ResourceUsageRate
    {
        public int ResourceUsageRateId { get; set; }
        public ResourceType ResourceType { get; set; }
        public double Rate { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime PeriodStart { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime PeriodEnd { get; set; }
    }
}

