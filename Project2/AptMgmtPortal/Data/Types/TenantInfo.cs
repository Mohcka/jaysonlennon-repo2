using AptMgmtPortal.Entity;

namespace AptMgmtPortal.Entity
{
    public class TenantInfo
    {
        public int TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public TenantInfo(Tenant tenant)
        {
            this.TenantId = tenant.TenantId;
            this.FirstName = tenant.FirstName;
            this.LastName = tenant.LastName;
            this.PhoneNumber = tenant.PhoneNumber;
            this.Email = tenant.Email;
            this.UserId = tenant.UserId;
        }

        public TenantInfo(){}
    }
}