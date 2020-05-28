using System;
using System.Collections.Generic;

namespace AptMgmtPortal.Util.Auth
{
    public class ApiKey
    {
        public ApiKey(string owner, string key, IReadOnlyCollection<string> roles, int userId)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
            UserId = userId;
        }

        public string Owner { get; }
        public string Key { get; }
        public IReadOnlyCollection<string> Roles { get; }
        public int UserId { get; }
    }
}