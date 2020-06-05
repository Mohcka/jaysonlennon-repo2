using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class DbAuthorizationSetupFactory
    {
        public static DbApiKeyStore Create(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<DbApiKeyStore>>();
            var userRepository = serviceProvider.GetRequiredService<Repository.IUser>();
            return new DbApiKeyStore(logger, userRepository);
        }
    }
}