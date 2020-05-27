using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity
{
    public class TenantResourceUsage
    {
        public int TenantResourceUsageId { get; set; }
        public DateTimeOffset SampleTime { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal UsageAmount { get; set; }

        public ResourceType ResourceType { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
