using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class DbApiKeyStore : IGetApiKey
    {
        private readonly ILogger<DbApiKeyStore> _logger;
        private readonly Repository.IUser _userRepository;

        public DbApiKeyStore(ILogger<DbApiKeyStore> logger, Repository.IUser userRepository)
        {
            this._logger = logger;
            this._userRepository = userRepository;
        }

        public async Task<ApiKey> GetApiKey(string apiKey)
        {
            var user = await _userRepository.UserFromApiKey(apiKey);
            if (user == null) return null;

            string role;
            switch (user.UserAccountType)
            {
                case Types.UserAccountType.Tenant:
                    role = Role.Tenant;
                    break;
                case Types.UserAccountType.Manager:
                    role = Role.Manager;
                    break;
                case Types.UserAccountType.Admin:
                    role = Role.Admin;
                    break;
                default:
                    role = Role.Tenant;
                    break;
            }

            return new ApiKey(user.LoginName, apiKey, new List<string> { role }, user.UserId);
        }
    }
}