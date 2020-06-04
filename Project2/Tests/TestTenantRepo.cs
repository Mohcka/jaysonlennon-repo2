using System;
using System.Reflection;
using Xunit;
using System.Linq;

using AptMgmtPortalAPI;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Data.Repository;
using AptMgmtPortalAPI.Types;

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
                var repo = (IBill)new BillRepository(db);
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
                var repo = (IBill)new BillRepository(db);
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
                var repo = (IBill)new BillRepository(db);
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
                var repo = (IBill)new BillRepository(db);

                var paymentsFromDb = await repo.GetPayments(tenant.TenantId, ResourceType.Power, period);
                Assert.Single(paymentsFromDb);

                var powerPayment = paymentsFromDb.Single();
                Assert.Equal(12, powerPayment.Amount);
            }
        }

        [Fact]
        public async void GetsSingleBill()
        {
            var options = TestUtil.GetMemDbOptions("GetsSingleBill");

            const double rate = 3;

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                period = TestUtil.NewBillingPeriod(db);

                TestUtil.NewResourceRate(db, rate, ResourceType.Power, period);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var bill = await repo.GetBill(tenant.TenantId, ResourceType.Power, period);
                Assert.Equal(rate * 10, bill.Owed());
            }
        }

        [Fact]
        public async void AccurateBillNumbers()
        {
            var options = TestUtil.GetMemDbOptions("AccurateBillNumbers");

            const double rate = 1;

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                period = TestUtil.NewBillingPeriod(db);

                TestUtil.NewResourceRate(db, rate, ResourceType.Power, period);

                var payment = TestUtil.NewPayment(db, tenant.TenantId);
                payment.Amount = 3;     // Should still owe 7
                payment.BillingPeriodId = period.BillingPeriodId;
                payment.ResourceType = ResourceType.Power;
                payment.TenantId = tenant.TenantId;

                db.SaveChanges();
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var bill = await repo.GetBill(tenant.TenantId, ResourceType.Power, period);
                Assert.Equal(3, bill.Paid);
                Assert.Equal(rate * 7, bill.Owed());
                Assert.Equal(rate, bill.Rate);
            }
        }

        [Fact]
        public async void GetsBillsInPeriod()
        {
            var options = TestUtil.GetMemDbOptions("GetsBillsInPeriod");

            const double powerRate = 3;
            const double waterRate = 5;

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 6, ResourceType.Power);

                TestUtil.UseResource(db, tenant.TenantId, 2, ResourceType.Water);
                TestUtil.UseResource(db, tenant.TenantId, 3, ResourceType.Water);

                period = TestUtil.NewBillingPeriod(db);

                TestUtil.NewResourceRate(db, powerRate, ResourceType.Power, period);
                TestUtil.NewResourceRate(db, waterRate, ResourceType.Water, period);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);

                var bills = await repo.GetBills(tenant.TenantId, period);
                Assert.Equal(2, bills.Count());

                var powerBill = bills.Where(b => b.Resource == ResourceType.Power).FirstOrDefault();
                Assert.Equal(powerRate * 11, powerBill.Cost());

                var waterBill = bills.Where(b => b.Resource == ResourceType.Water).FirstOrDefault();
                Assert.Equal(waterRate * 5, waterBill.Cost());
            }
        }

        [Fact]
        public async void GetsResourceRates()
        {
            var options = TestUtil.GetMemDbOptions("GetsResourceRate");

            const double powerRate = 3;
            const double waterRate = 5;

            BillingPeriod period;
            ResourceUsageRate powerRateObj;
            ResourceUsageRate waterRateObj;
            using (var db = new AptMgmtDbContext(options))
            {
                period = TestUtil.NewBillingPeriod(db);

                powerRateObj = TestUtil.NewResourceRate(db, powerRate, ResourceType.Power, period);
                waterRateObj = TestUtil.NewResourceRate(db, waterRate, ResourceType.Water, period);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var rates = await repo.GetResourceUsageRates(period);

                var powerRateFromDb = rates.Where(r => r.ResourceType == ResourceType.Power)
                    .Select(r => r)
                    .First();
                Assert.Equal(powerRateObj.Rate, powerRateFromDb.Rate);

                var waterRateFromDb = rates.Where(r => r.ResourceType == ResourceType.Water)
                    .Select(r => r)
                    .First();
                Assert.Equal(waterRateObj.Rate, waterRateFromDb.Rate);
            }
        }

        [Fact]
        public async void GetsSignedAgreements()
        {
            var options = TestUtil.GetMemDbOptions("GetsSignedAgreements");

            Tenant tenant;
            AgreementTemplate agreement1;
            AgreementTemplate agreement2;
            Agreement signedAgreement1;
            Agreement signedAgreement2;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                agreement1 = TestUtil.NewAgreement(db, "test-agreement1");
                agreement2 = TestUtil.NewAgreement(db, "test-agreement2");

                signedAgreement1 = TestUtil.SignAgreement(db, agreement1.AgreementTemplateId, tenant.TenantId);
                signedAgreement2 = TestUtil.SignAgreement(db, agreement2.AgreementTemplateId, tenant.TenantId);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IAgreement)new AgreementRepository(db);
                var signedAgreements = await repo.GetAgreements(tenant.TenantId);
                Assert.Equal(2, signedAgreements.Count());

                var signed1 = signedAgreements.Where(a => a.AgreementTemplateId == agreement1.AgreementTemplateId).FirstOrDefault();
                Assert.Equal("test-agreement1", signed1.Title);

                var signed2 = signedAgreements.Where(a => a.AgreementTemplateId == agreement2.AgreementTemplateId).FirstOrDefault();
                Assert.Equal("test-agreement2", signed2.Title);
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
                Assert.Equal(tenantCount,count);
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
                Assert.Equal(tenantId,tenant.TenantId);
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
