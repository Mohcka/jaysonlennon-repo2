using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Types;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace TestAptMgmtPortal
{
    public class TestMaintenanceRepo
    {
        [Fact]
        public async void BuildsDTO()
        {
            var options = TestUtil.GetMemDbOptions("OpensMaintenanceRequest");

            AptMgmtPortalAPI.DTO.MaintenanceRequestDTO dto;
            AptMgmtPortalAPI.Entity.MaintenanceRequest req;
            using (var db = new AptMgmtDbContext(options))
            {
                var mock = new Mock<ILogger<UserRepository>>();
                ILogger<UserRepository> logger = mock.Object;
                User user = TestUtil.NewUser(db);

                var repo = (IUser)new UserRepository(logger, db);

                req = new AptMgmtPortalAPI.Entity.MaintenanceRequest();
                req.MaintenanceRequestId = 999;
                req.OpeningUserId = user.UserId;

                db.Add(req);
                db.SaveChanges();

                dto = await AptMgmtPortalAPI.DTO.MaintenanceRequestDTO.Build(req, repo);

            }

            Assert.Equal(req.MaintenanceRequestId, dto.MaintenanceRequestId);
        }

        [Fact]
        public async void OpensMaintenanceRequest()
        {
            var options = TestUtil.GetMemDbOptions("OpensMaintenanceRequest");

            User user;
            MaintenanceRequest maintRequest;
            using (var db = new AptMgmtDbContext(options))
            {
                user = TestUtil.NewUser(db);
                var repo = (IMaintenance)new MaintenanceRepository(db);

                var requestData = new AptMgmtPortalAPI.DataModel.MaintenanceRequestModel();
                requestData.OpenNotes = "notes";
                requestData.UnitNumber = "unit";
                requestData.MaintenanceRequestType = MaintenanceRequestType.Plumbing;

                maintRequest = await repo.OpenMaintenanceRequest(user.UserId, requestData);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IMaintenance)new MaintenanceRepository(db);
                var requests = await repo.GetOpenMaintenanceRequests("unit");
                Assert.Single(requests);
                Assert.Equal(maintRequest.MaintenanceRequestId, requests.FirstOrDefault().MaintenanceRequestId);
            }
        }

        [Fact]
        public async void CancelsMaintenanceRequest()
        {
            var options = TestUtil.GetMemDbOptions("CancelsMaintenanceRequest");

            var unitNumber = "test unit";
            User user;
            Tenant tenant;
            MaintenanceRequest maintRequest;
            Unit unit;

            using (var db = new AptMgmtDbContext(options))
            {
                user = TestUtil.NewUser(db);
                var maintenanceRepo = (IMaintenance)new MaintenanceRepository(db);

                var requestData = new AptMgmtPortalAPI.DataModel.MaintenanceRequestModel();
                requestData.OpenNotes = "notes";
                requestData.UnitNumber = unitNumber;
                requestData.MaintenanceRequestType = MaintenanceRequestType.Plumbing;

                maintRequest = await maintenanceRepo.OpenMaintenanceRequest(user.UserId, requestData);

                tenant = TestUtil.NewTenant(db);
                tenant.UserId = user.UserId;
                db.SaveChanges();

                // Maintenance requests are assigned to units, but may be opened by any user of
                // the application. This means the occupying tenant may open a maintenance request,
                // but only if they have a UserId, and a Manager may also open a maintenance request
                // on behalf of a Tenant of User.
                //
                // In order to cancel a maintenance request, we must have a way to determine if
                // the User is indeed the Tenant of the request. This is accomplished by checking
                // if the user is occupying the unit, and if so, they will be permitted to cancel
                // the request.
                var tenantRepo = (ITenant)new TenantRepository(db);
                unit = TestUtil.NewUnit(db, unitNumber);
                await tenantRepo.AssignToUnit(tenant.TenantId, unitNumber);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IMaintenance)new MaintenanceRepository(db);
                var canceled = await repo.CancelMaintenanceRequest(user.UserId,
                                                                   maintRequest.MaintenanceRequestId,
                                                                   "test cancel");
                Assert.NotNull(canceled.TimeClosed);

                var requests = await repo.GetOpenMaintenanceRequests(unit.UnitNumber);
                Assert.Empty(requests);
            }
        }
    }
}
