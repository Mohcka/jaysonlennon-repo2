using System.Reflection;
using Xunit;
using System.Linq;

using AptMgmtPortal;
using AptMgmtPortal.Entity;
using AptMgmtPortal.Data;
using AptMgmtPortal.Repository;
using AptMgmtPortal.Data.Repository;

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
                var repo = (ITenant) new TenantRepository(db);
                maintRequest = await repo.OpenMaintenanceRequest(
                                    user.UserId,
                                    MaintenanceRequestType.Plumbing,
                                    "notes",
                                    "unit");
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                var requests = await repo.GetOutstandingMaintenanceRequests(user.UserId);
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
                var tenantRepo = (ITenant) new TenantRepository(db);

                maintRequest = await tenantRepo.OpenMaintenanceRequest(
                                    user.UserId,
                                    MaintenanceRequestType.Plumbing,
                                    "notes",
                                    unitNumber);

                tenant = new Tenant();
                tenant.UserId = user.UserId;

                db.Tenants.Add(tenant);

                var managerRepo = (IManager) new ManagerRepository(db);
                unit = TestUtil.NewUnit(db, unitNumber);

                // Tenants must be assigned to a unit in order to cancel requests.
                await managerRepo.AssignTenantToUnit(tenant.TenantId, unitNumber);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                var canceled = await repo.CancelMaintenanceRequest(user.UserId,
                                                                   maintRequest.MaintenanceRequestId,
                                                                   "test cancel");
                Assert.True(canceled);
                var requests = await repo.GetOutstandingMaintenanceRequests(user.UserId);
                Assert.Empty(requests);
            }
        }

        [Fact]
        public async void EditsPersonalInfo()
        {
            var options = TestUtil.GetMemDbOptions("EditsTenantInfo");

            Tenant tenant;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                var tenantInfo = new TenantInfo();
                tenantInfo.FirstName = "original first name";
                tenant = await repo.AddTenant(tenantInfo);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);

                var newName = "new first name";

                var tenantInfo = new TenantInfo(tenant);
                tenantInfo.FirstName = newName;

                var status = await repo.EditPersonalInfo(tenant.TenantId, tenantInfo);
                Assert.True(status);

                var newInfo = await repo.TenantFromId(tenant.TenantId);
                Assert.Equal(newName, newInfo.FirstName);
            }
        }

        [Fact]
        public async void GetsResourceUsage()
        {
            var options = TestUtil.GetMemDbOptions("GetsResourceUsage");

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                var usage = await repo.GetResourceUsage(tenant.TenantId, ResourceType.Power, period);
                Assert.Equal(10, usage.Usage);
            }
        }

        [Fact]
        public async void GetMultipleResourceUsage()
        {
            var options = TestUtil.GetMemDbOptions("GetsMultipleResourceUsage");

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 10, ResourceType.Water);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant) new TenantRepository(db);
                var allUsage = await repo.GetResourceUsage(tenant.TenantId, period);
                Assert.Equal(2, allUsage.Count());

                var powerUsage = allUsage.Where(u => u.ResourceType == ResourceType.Power).FirstOrDefault();
                Assert.Equal(5, powerUsage.Usage);

                var waterUsage = allUsage.Where(u => u.ResourceType == ResourceType.Water).FirstOrDefault();
                Assert.Equal(10, waterUsage.Usage);
            }
        }
    }
}
