using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AptMgmtPortal.Util.Auth
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