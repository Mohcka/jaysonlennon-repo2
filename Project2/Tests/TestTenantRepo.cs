using System;
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
                var repo = (ITenant)new TenantRepository(db);
                maintRequest = await repo.OpenMaintenanceRequest(
                                    user.UserId,
                                    MaintenanceRequestType.Plumbing,
                                    "notes",
                                    "unit");
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
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
                var tenantRepo = (ITenant)new TenantRepository(db);

                maintRequest = await tenantRepo.OpenMaintenanceRequest(
                                    user.UserId,
                                    MaintenanceRequestType.Plumbing,
                                    "notes",
                                    unitNumber);

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
                var managerRepo = (IManager)new ManagerRepository(db);
                unit = TestUtil.NewUnit(db, unitNumber);
                await managerRepo.AssignTenantToUnit(tenant.TenantId, unitNumber);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
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
                var repo = (ITenant)new TenantRepository(db);
                var tenantInfo = new TenantInfo();
                tenantInfo.FirstName = "original first name";
                tenant = await repo.AddTenant(tenantInfo);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);

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
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
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
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 10, ResourceType.Water);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var allUsage = await repo.GetResourceUsage(tenant.TenantId, period);
                Assert.Equal(2, allUsage.Count());

                var powerUsage = allUsage.Where(u => u.ResourceType == ResourceType.Power).FirstOrDefault();
                Assert.Equal(5, powerUsage.Usage);

                var waterUsage = allUsage.Where(u => u.ResourceType == ResourceType.Water).FirstOrDefault();
                Assert.Equal(10, waterUsage.Usage);
            }
        }

        [Fact]
        public async void GetsPayment()
        {
            var options = TestUtil.GetMemDbOptions("GetsPayment");

            Tenant tenant;
            Payment payment;
            using (var db = new AptMgmtDbContext(options))
            {
                tenant = TestUtil.NewTenant(db);
                var repo = (ITenant)new TenantRepository(db);
                payment = TestUtil.NewPayment(db, tenant.TenantId);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                var paymentFromDb = await repo.GetPayment(tenant.TenantId, payment.PaymentId);
                Assert.Equal(payment.PaymentId, paymentFromDb.PaymentId);
            }
        }

        [Fact]
        public async void GetsPaymentsOfResourceType()
        {
            var options = TestUtil.GetMemDbOptions("GetsPaymentsOfResourceType");

            Tenant tenant;
            Payment payment;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                period = TestUtil.NewBillingPeriod(db);
                tenant = TestUtil.NewTenant(db);

                var repo = (ITenant)new TenantRepository(db);
                payment = TestUtil.NewPayment(db, tenant.TenantId);
                payment.ResourceType = ResourceType.Power;
                payment.BillingPeriodId = period.BillingPeriodId;
                payment.Amount = 12;

                // We will query for power payment (above). This should not appear.
                var waterPayment = TestUtil.NewPayment(db, tenant.TenantId);
                waterPayment.ResourceType = ResourceType.Water;
                waterPayment.BillingPeriodId = period.BillingPeriodId;
                waterPayment.Amount = 6;

                // This is a power payment, but is for a different period.
                var outOfPeriodPayment = TestUtil.NewPayment(db, tenant.TenantId);
                outOfPeriodPayment.ResourceType = ResourceType.Power;
                outOfPeriodPayment.Amount = 10;

                var oldPeriod = TestUtil.NewBillingPeriod(db);
                oldPeriod.PeriodStart = DateTime.Now - new TimeSpan(22,0,0,0);
                oldPeriod.PeriodEnd = DateTime.Now - new TimeSpan(20,0,0,0);

                outOfPeriodPayment.BillingPeriodId = oldPeriod.BillingPeriodId;

                db.SaveChanges();
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);

                var paymentsFromDb = await repo.GetPayments(tenant.TenantId, ResourceType.Power, period);
                Assert.Single(paymentsFromDb);

                var powerPayment = paymentsFromDb.Single();
                Assert.Equal(12, powerPayment.Amount);
            }
        }
    }
}
