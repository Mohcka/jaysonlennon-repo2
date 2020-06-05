using System.ComponentModel.DataAnnotations;

namespace AptMgmtPortalAPI.Entity
{
    public class Tenant
    {
        public Tenant() { }

        [Key]
        public int TenantId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserId { get; set; }
    }
}
