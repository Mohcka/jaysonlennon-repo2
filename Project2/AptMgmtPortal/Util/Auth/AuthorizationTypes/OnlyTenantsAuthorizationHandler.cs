using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AptMgmtPortal.Util.Auth
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