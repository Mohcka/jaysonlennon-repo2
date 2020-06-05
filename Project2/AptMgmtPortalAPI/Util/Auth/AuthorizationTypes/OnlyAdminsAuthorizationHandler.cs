using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class OnlyAdminsAuthorizationHandler : AuthorizationHandler<OnlyAdminsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyAdminsRequirement requirement)
        {
            if (context.User.IsInRole(Role.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}