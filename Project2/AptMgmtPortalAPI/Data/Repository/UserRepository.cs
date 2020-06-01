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
using AptMgmtPortalAPI.DTO;

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

        public async Task<Entity.User> Login(string loginName, string password)
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

        public async Task<Entity.User> NewUser(DTO.UserDTO userInfo)
        {
            if (userInfo == null) return null;
            if (String.IsNullOrEmpty(userInfo.Password)) return null;
            if (String.IsNullOrEmpty(userInfo.LoginName)) return null;

            var user = new Entity.User();
            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.LoginName = userInfo.LoginName;
            user.Password = Util.Hash.Sha256(userInfo.Password);
            user.UserAccountType = userInfo.UserAccountType;
            user.ApiKey = Guid.NewGuid().ToString();

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Entity.User> UpdateUserInfo(int userId, DTO.UserDTO userInfo)
        {
            var user = await UserFromId(userId);
            if (user == null) return null;

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.LoginName = userInfo.LoginName;
            user.Password = Util.Hash.Sha256(userInfo.Password);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Entity.User> UpdateUserInfo(UserDTO userInfo)
        {
            if (userInfo.UserId == 0)
            {
                return await NewUser(userInfo);
            }
            else
            {
                return await UpdateUserInfo(userInfo.UserId, userInfo);
            }
        }

        public async Task<Entity.User> UserFromApiKey(string apiKey)
        {
            return await _context.Users
                            .Where(u => u.ApiKey == apiKey)
                            .Select(u => u)
                            .FirstOrDefaultAsync();
        }

        public async Task<Entity.User> UserFromId(int userId)
        {
            return await _context.Users
                .Where(u => u.UserId == userId)
                .Select(u => u)
                .FirstOrDefaultAsync();
        }
    }
}