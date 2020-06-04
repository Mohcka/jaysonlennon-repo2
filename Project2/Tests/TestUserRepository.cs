using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestAptMgmtPortal
{
    public class TestUserRepository
    {
        [Fact]
        public async void GetsUserFromApiKey()
        {
            var options = TestUtil.GetMemDbOptions("GetsUserFromApiKey");
            User user;
            var mock = new Mock<ILogger<UserRepository>>();
            ILogger<IUser> logger = mock.Object;

            using (var db = new AptMgmtDbContext(options))
            {
                user = TestUtil.NewUserWithAnAPIKey(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IUser)new UserRepository(mock.Object, db);
                var newUserWithApiKey = await repo.UserFromApiKey(user.ApiKey);
                Assert.Equal(newUserWithApiKey.ApiKey, user.ApiKey);
            }
        }

    }
}
