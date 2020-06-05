namespace AptMgmtPortalAPI.DTO
{
    public class TenantInfoDTO
    {
        public int TenantId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitNumber { get; set; }
        public TenantInfoDTO() { }

        public TenantInfoDTO(Entity.Tenant tenant, string unitNumber)
        {
            this.TenantId = tenant.TenantId;
            this.PhoneNumber = tenant.PhoneNumber;
            this.Email = tenant.Email;
            this.FirstName = tenant.FirstName;
            this.LastName = tenant.LastName;
            this.UnitNumber = unitNumber;
        }
    }
}
