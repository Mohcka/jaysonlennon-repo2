using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class InMemoryAuthorizationSetupFactory
    {
        public static InMemoryApiStore Create(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<InMemoryApiStore>>();
            return new InMemoryApiStore(logger);
        }
    }
}