using System;
using Microsoft.AspNetCore.Mvc;

namespace AptMgmtPortal.Util.Auth.Extensions
{
    public static class IdentityExtensions
    {
        public static int UserIdFromApiKey(this ControllerBase controller) {
            var claim = controller.User.FindFirst(claim => claim.Type == Auth.ClaimType.UserId).Value;
            return Int32.Parse(claim);
        }
    }
}