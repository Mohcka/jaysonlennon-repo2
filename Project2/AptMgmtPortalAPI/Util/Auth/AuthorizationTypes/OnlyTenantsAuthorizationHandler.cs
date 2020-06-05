using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class OnlyTenantsAuthorizationHandler : AuthorizationHandler<OnlyTenantsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyTenantsRequirement requirement)
        {
            if (context.User.IsInRole(Role.Tenant))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}