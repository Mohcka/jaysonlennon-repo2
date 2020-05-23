using System.Collections.Generic;
using System.Threading.Tasks;

namespace AptMgmtPortal.Repository
{
    public interface IUser
    {
        Task<IEnumerable<Entity.User>> GetAllUsers();
    }

    public class User : IUser
    {
        public async Task<IEnumerable<Entity.User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}