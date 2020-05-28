using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortal.Entity;

namespace AptMgmtPortal.Repository
{
    public interface IUser
    {
        Task<User> Login(string loginName, string password);
        Task<User> UserFromApiKey(string apiKey);
    }
}