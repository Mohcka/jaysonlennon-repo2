using System.Threading;
using System;
using System.Reflection;
using Xunit;
using System.Linq;

using AptMgmtPortalAPI;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Data.Repository;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.Controllers.Tenant;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TestAptMgmtPortal
{
    public class TestTenantController
    {
        [Fact]
        public async void GetById()
        {
            var sampleTenant = new Tenant();
            sampleTenant.FirstName = "tenant";
            sampleTenant.UserId = 1;
            sampleTenant.TenantId = 1;

            var mockRepo = new Mock<AptMgmtPortalAPI.Repository.ITenant>();
            mockRepo.Setup(repo => repo.TenantFromId(1)).ReturnsAsync(sampleTenant);

            var controller = new TenantController(null, mockRepo.Object);

            var result = await controller.GetTenant(1);

            var objResult = Assert.IsType<ObjectResult>(result);

            var resultData = Assert.IsAssignableFrom<Tenant>(objResult.Value);

            Assert.Equal(1, resultData.TenantId);
        }
    }
}