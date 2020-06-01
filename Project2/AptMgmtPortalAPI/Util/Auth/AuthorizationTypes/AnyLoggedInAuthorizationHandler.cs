using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class AnyLoggedInAuthorizationHandler : AuthorizationHandler<AnyLoggedInRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AnyLoggedInRequirement requirement)
        {
            if (context.User.IsInRole(Role.Admin) || context.User.IsInRole(Role.Manager) || context.User.IsInRole(Role.Tenant))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}