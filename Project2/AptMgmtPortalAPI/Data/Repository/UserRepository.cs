using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.DataModel;
using Microsoft.Extensions.Logging;

namespace AptMgmtPortalAPI.Repository
{
    public class UserRepository : IUser
    {
        private readonly ILogger _logger;
        private readonly AptMgmtDbContext _context;

        public UserRepository(ILogger<UserRepository> logger, AptMgmtDbContext aptMgmtDbContext)
        {
            this._logger = logger;
            _context = aptMgmtDbContext;
        }

        public async Task<User> Login(string loginName, string password)
        {
            _logger.LogDebug($"trylogin: {loginName}//{password}");
            if (loginName == null || password == null) return null;

            var hashedPassword = Util.Hash.Sha256(password);

            _logger.LogDebug($"hashed: {hashedPassword}");

            return await _context.Users
                            .Where(u => u.LoginName.ToLower() == loginName.ToLower())
                            .Where(u => u.Password == hashedPassword)
                            .FirstOrDefaultAsync();
        }

        public async Task<User> UserFromApiKey(string apiKey)
        {
            return await _context.Users
                            .Where(u => u.ApiKey == apiKey)
                            .Select(u => u)
                            .FirstOrDefaultAsync();
        }
    }
}