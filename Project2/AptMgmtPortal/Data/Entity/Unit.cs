using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity
{
    public class Unit
    {
        public Unit() { }

        [Key]
        public int UnitId { get; set; }
        public string UnitNumber { get; set; }
        public int? TenantId { get; set; }
    }
}
