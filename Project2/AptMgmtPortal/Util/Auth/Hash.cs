using System;
using System.Linq;
using System.Security.Cryptography;

namespace AptMgmtPortal.Util
{
    public static class Hash
    {
        public static String Sha256(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = input.ToCharArray().Select(c => (byte)c).ToArray();
                var hash = sha256.ComputeHash(bytes);
                var encoded = Convert.ToBase64String(hash);
                return encoded;
            }
        }
    }

}