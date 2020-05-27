using Microsoft.AspNetCore.Authorization;

namespace AptMgmtPortal.Util.Auth
{
    public class OnlyAdminsRequirement : IAuthorizationRequirement
    {
    }
}