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
            ILogger<UserRepository> logger = mock.Object;

            using (var db = new AptMgmtDbContext(options))
            {
                user = TestUtil.NewUserWithAnAPIKey(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IUser)new UserRepository(logger, db);
                var newUserWithApiKey = await repo.UserFromApiKey(user.ApiKey);
                Assert.Equal(newUserWithApiKey.ApiKey, user.ApiKey);
            }
        }

        [Fact]
        public async void EditsUserInfo()
        {
            var options = TestUtil.GetMemDbOptions("EditsUserInfo");

            var mock = new Mock<ILogger<UserRepository>>();
            AptMgmtPortalAPI.Entity.User user;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IUser)new UserRepository(mock.Object, db);
                var userInfo = new AptMgmtPortalAPI.DTO.UserDTO
                {
                    FirstName = "original first name",
                    LoginName = "testUser",
                    Password = "password"
                };

                user = await repo.NewUser(userInfo);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IUser)new UserRepository(mock.Object, db);
                var newName = "new first name";
                var userInfo = new AptMgmtPortalAPI.DTO.UserDTO { 
                    FirstName = newName,
                    LoginName = user.LoginName,
                    Password = user.Password
                };
                var newInfo = await repo.UpdateUserInfo(user.UserId, userInfo);
                Assert.Equal(newName, newInfo.FirstName);
            }
        }
    }
}
