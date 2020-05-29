using Microsoft.AspNetCore.Authorization;

namespace AptMgmtPortalAPI.Util.Auth
{
    public class OnlyManagersRequirement : IAuthorizationRequirement
    {
    }

}