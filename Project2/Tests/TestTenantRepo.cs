using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Types;
using System;
using System.Linq;
using Xunit;

namespace TestAptMgmtPortal
{
    public class TestTenantRepository
    {
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

        [Fact]
        public async void EditsPersonalInfo()
        {
            var options = TestUtil.GetMemDbOptions("EditsTenantInfo");

            AptMgmtPortalAPI.DTO.TenantInfoDTO tenant;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var tenantInfo = new AptMgmtPortalAPI.DTO.TenantInfoDTO();
                tenantInfo.Email = "testDtoemail@test.com";
                tenantInfo.FirstName = "original first name";
                tenant = await repo.AddTenant(tenantInfo);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);

                var newName = "new first name";

                var tenantInfo = new AptMgmtPortalAPI.DTO.TenantInfoDTO();
                tenantInfo.Email = "testDtoemail@test.com";
                tenantInfo.FirstName = newName;

                var newInfo = await repo.UpdateTenantInfo(tenant.TenantId, tenantInfo);

                Assert.Equal(newName, newInfo.FirstName);
            }
        }


        [Fact]
        public async void GetsAllTenants()
        {
            var options = TestUtil.GetMemDbOptions("GetsAllTenants");
            var count = 0;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var tenant = TestUtil.NewTenant(db);
                var tenants = await repo.GetTenants();
                count = tenants.Count();
            }
            using (var db = new AptMgmtDbContext(options))
            {
                ITenant repo = (ITenant)new TenantRepository(db);
                var getTenants = await repo.GetTenants();
                var tenantCount = getTenants.Count();
                Assert.Equal(tenantCount, count);
            }
        }

        [Fact]
        public async void DeleteUnit()
        {
            var options = TestUtil.GetMemDbOptions("DeleteUnit");
            Unit unit = new Unit();
            using (var db = new AptMgmtDbContext(options))
            {
                unit = TestUtil.NewUnit(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var unitDel = await repo.DeleteUnit(unit.TenantId ?? default);
                Assert.True(unitDel);
            }
        }

        [Fact]
        public async void UpdateUnit()
        {
            var options = TestUtil.GetMemDbOptions("UpdateUnit");
            Unit unit = new Unit();
            using (var db = new AptMgmtDbContext(options))
            {
                unit = TestUtil.NewUnit(db);
                var tenant = TestUtil.NewTenant(db);
                unit.TenantId = tenant.TenantId;
                var repo = (ITenant)new TenantRepository(db);
                var updateUnit = await repo.UpdateUnit(unit);

            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var unitUpdate = await repo.UnitFromTenantId(unit.TenantId ?? default);
                Assert.Equal(unitUpdate.TenantId, unit.TenantId);
            }
        }

        [Fact]
        public async void FindTenentWithFirstName()
        {
            var options = TestUtil.GetMemDbOptions("FindTenantWithFirstName");
            Tenant tenant;
            var firstName = "";
            using (var db = new AptMgmtDbContext(options))
            {
                tenant = TestUtil.NewTenant(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var getTenant = await repo.FindTenantWithFirstName(tenant.FirstName);
                firstName = getTenant
                    .Where(t => t.FirstName == tenant.FirstName)
                    .Select(t => t.FirstName)
                    .FirstOrDefault();
                Assert.Equal(firstName, tenant.FirstName);
            }
        }

        [Fact]
        public async void TenantFromId()
        {
            var options = TestUtil.GetMemDbOptions("TenantFromId");
            Tenant tenant;
            Tenant tenantFromId;
            using (var db = new AptMgmtDbContext(options))
            {
                tenant = TestUtil.NewTenant(db);
                var repo = (ITenant)new TenantRepository(db);
                tenantFromId = await repo.TenantFromId(tenant.TenantId);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var getTenant = await repo.GetTenants();
                var getTenantFromId = getTenant.Where(t => t.TenantId == tenantFromId.TenantId).FirstOrDefault();
                Assert.Equal(getTenantFromId.TenantId, tenantFromId.TenantId);
            }
        }

        [Fact]
        public async void TenantFromUserId()
        {
            var options = TestUtil.GetMemDbOptions("TenantFromUserId");
            Tenant tenant;
            using (var db = new AptMgmtDbContext(options))
            {
                tenant = TestUtil.NewTenant(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var getTenant = await repo.TenantFromUserId(tenant.UserId ?? default);
                Assert.Equal(tenant.UserId, getTenant.UserId);
            }
        }

        [Fact]
        public async void TenantIdFromUserId()
        {
            var options = TestUtil.GetMemDbOptions("TenantIdFromUserId");
            Tenant tenant;
            int? tenantId = 0;
            using (var db = new AptMgmtDbContext(options))
            {
                tenant = TestUtil.NewTenant(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenantId = await repo.TenantIdFromUserId(tenant.UserId ?? default);
                Assert.Equal(tenantId, tenant.TenantId);
            }
        }

        [Fact]
        public async void GetUnitById()
        {
            var options = TestUtil.GetMemDbOptions("UnitFromId");
            Unit unit;
            using (var db = new AptMgmtDbContext(options))
            {
                unit = TestUtil.NewUnit(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var unitById = await repo.GetUnit(unit.UnitId);
                Assert.Equal(unitById.UnitId, unit.UnitId);
            }
        }

        [Fact]
        public async void QueryUnitByNumber()
        {
            var options = TestUtil.GetMemDbOptions("UnitByNumber");
            Unit unit;
            using (var db = new AptMgmtDbContext(options))
            {
                unit = TestUtil.NewUnit(db);
            }
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var unitByNumber = await repo.QueryUnitByNumber(unit.UnitNumber);
                Assert.Equal(unitByNumber.UnitNumber, unit.UnitNumber);
            }
        }
    }
}
