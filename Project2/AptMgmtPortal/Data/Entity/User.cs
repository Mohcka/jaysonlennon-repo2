using System;

namespace AptMgmtPortal.Entity {
    public class User {
        public Guid UserId { get; set; }
        public Types.UserAccount AccountType { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}