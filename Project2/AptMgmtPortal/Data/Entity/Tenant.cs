using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity
{
    public class Tenant
    {
        public Tenant()
        {
            TenantResourceUsages = new HashSet<TenantResourceUsage>();
        }
        [Key]
        public int TenantId { get; set; }
        public string UnitNumber { get; set; }
        public bool IsPresent { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<TenantResourceUsage> TenantResourceUsages { get; set; }
    }
}
