using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

using AptMgmtPortal.Data;
using Microsoft.Extensions.Logging;
using System;

namespace AptMgmtPortal.Util.Auth
{
    public static class AuthorizationSetupExtensions
    {
        public static void SetupAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyTenants, policy => policy.Requirements.Add(new OnlyTenantsRequirement()));
                options.AddPolicy(Policies.OnlyManagers, policy => policy.Requirements.Add(new OnlyManagersRequirement()));
                options.AddPolicy(Policies.OnlyAdmins, policy => policy.Requirements.Add(new OnlyAdminsRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, OnlyTenantsAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyManagersAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyAdminsAuthorizationHandler>();

            services.AddSingleton<IGetApiKey>(InMemoryAuthorizationSetupFactory.Create);
        }
    }
}