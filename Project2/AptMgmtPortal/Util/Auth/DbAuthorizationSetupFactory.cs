using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AptMgmtPortal.Util.Auth
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