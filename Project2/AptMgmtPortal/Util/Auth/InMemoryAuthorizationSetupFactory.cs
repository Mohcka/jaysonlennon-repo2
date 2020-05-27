using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AptMgmtPortal.Util.Auth
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