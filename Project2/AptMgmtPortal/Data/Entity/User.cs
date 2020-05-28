using AptMgmtPortal.Types;

namespace AptMgmtPortal.Entity {
    public class User
    {
        public User() { }
        public int UserId { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}