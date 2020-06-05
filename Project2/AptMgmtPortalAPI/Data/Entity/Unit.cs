using System.ComponentModel.DataAnnotations;

namespace AptMgmtPortalAPI.Entity
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
