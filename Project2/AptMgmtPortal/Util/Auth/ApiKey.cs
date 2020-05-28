using System;
using System.Collections.Generic;

namespace AptMgmtPortal.Util.Auth
{
    public class ApiKey
    {
        public ApiKey(string owner, string key, IReadOnlyCollection<string> roles)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public string Owner { get; }
        public string Key { get; }
        public IReadOnlyCollection<string> Roles { get; }
    }
}