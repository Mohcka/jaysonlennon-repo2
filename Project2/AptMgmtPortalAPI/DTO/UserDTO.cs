using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DTO {
    public class UserDTO
    {
        public int UserId { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public UserDTO() { }
        public UserDTO(Entity.User user) {
            this.UserId = user.UserId;
            this.UserAccountType = user.UserAccountType;
            this.LoginName = user.LoginName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.ApiKey = user.ApiKey;
        }
    }
}