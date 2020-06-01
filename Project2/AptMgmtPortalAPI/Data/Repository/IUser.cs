using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;

namespace AptMgmtPortalAPI.Repository
{
    public interface IUser
    {
        Task<User> Login(string loginName, string password);
        Task<User> UserFromApiKey(string apiKey);
        Task<User> UserFromId(int userId);
    }
}