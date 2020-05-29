using System;
using System.ComponentModel.DataAnnotations.Schema;
using AptMgmtPortalAPI.Types;
namespace AptMgmtPortalAPI.Entity
{
    public class TenantResourceUsage
    {
        public int TenantResourceUsageId { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
        public DateTime SampleTime { get; set; }
        public double UsageAmount { get; set; }
        public ResourceType ResourceType { get; set; }
        public int TenantId { get; set; }
    }
}
