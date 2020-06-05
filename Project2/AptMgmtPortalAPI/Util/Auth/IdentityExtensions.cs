using Microsoft.AspNetCore.Mvc;
using System;

namespace AptMgmtPortalAPI.Util.Auth.Extensions
{
    public static class IdentityExtensions
    {
        public static int UserIdFromApiKey(this ControllerBase controller)
        {
            var claim = controller.User.FindFirst(claim => claim.Type == Auth.ClaimType.UserId).Value;
            return Int32.Parse(claim);
        }
        public static bool UserInRole(this ControllerBase controller, string role)
        {
            return controller.HttpContext.User.IsInRole(role);
        }
    }
}