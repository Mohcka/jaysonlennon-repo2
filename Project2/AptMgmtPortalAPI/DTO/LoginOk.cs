using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DTO
{
    public class LoginOk
    {
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public string ApiKey { get; set; }

        public LoginOk(Entity.User user)
        {
            this.UserAccountType = user.UserAccountType;
            this.LoginName = user.LoginName;
            this.ApiKey = user.ApiKey;
        }
    }
}