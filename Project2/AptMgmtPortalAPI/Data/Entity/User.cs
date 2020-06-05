using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Entity
{
    public class User
    {
        public User() { }
        public int UserId { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}