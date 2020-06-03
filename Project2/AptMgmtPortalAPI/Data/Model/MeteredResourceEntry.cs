using System;
using System.ComponentModel.DataAnnotations.Schema;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DataModel
{
    public class MeteredResourceEntry
    {
        public int TenantId { get; set; }
        public DateTime SampleTime { get; set; }
        public double UsageAmount { get; set; }
        public ResourceType ResourceType { get; set; }
    }
}
