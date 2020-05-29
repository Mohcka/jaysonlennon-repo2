using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DTO {
    public class User
    {
        public int UserId { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public int? TenantId { get; set; }
        public string ApiKey { get; set; }

        public User(Entity.User user)
        {
            this.UserId = user.UserId;
            this.UserAccountType = user.UserAccountType;
            this.LoginName = user.LoginName;
            this.ApiKey = user.ApiKey;
        }
    }
}