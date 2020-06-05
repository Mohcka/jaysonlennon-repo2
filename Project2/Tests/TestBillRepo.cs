using System;
using System.Linq;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Types;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace TestAptMgmtPortal
{
    public class TestBillRepo
    {

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
        public async void GetsAllBillsInCurrentPeriod()
        {
            var options = TestUtil.GetMemDbOptions("GetsAllBillsInCurrentPeriod");

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

                var bills = await repo.GetBills(period);
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
        public async void GetsDailyResourceUsage()
        {
            var options = TestUtil.GetMemDbOptions("GetsDailyResourceUsage");

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
                var entries = await repo.GetDailyResourceUsage(tenant.TenantId, ResourceType.Power, period);
                Assert.Equal(2, entries.Count());
            }
        }

        [Fact]
        public async void GetsAllDailyResourceUsage()
        {
            var options = TestUtil.GetMemDbOptions("GetsAllDailyResourceUsage");

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Water);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var entries = await repo.GetDailyResourceUsage(tenant.TenantId, period);
                Assert.Equal(3, entries.Count());
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
                oldPeriod.PeriodStart = DateTime.Now - new TimeSpan(22, 0, 0, 0);
                oldPeriod.PeriodEnd = DateTime.Now - new TimeSpan(20, 0, 0, 0);

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
        public async void PaysBill()
        {
            var options = TestUtil.GetMemDbOptions("PaysBill");

            const double rate = 1;

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                period = TestUtil.NewBillingPeriod(db);

                TestUtil.NewResourceRate(db, rate, ResourceType.Power, period);

                var payment = repo.PayBill(tenant.TenantId, 3, ResourceType.Power, period);

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
        public async void PaysBillWithRawId()
        {
            var options = TestUtil.GetMemDbOptions("PaysBillWithRawId");

            const double rate = 1;

            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                period = TestUtil.NewBillingPeriod(db);

                TestUtil.NewResourceRate(db, rate, ResourceType.Power, period);

                var payment = repo.PayBill(tenant.TenantId, 3, ResourceType.Power, period.BillingPeriodId);

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
        public async void GetsBillingPeriodById()
        {
            var options = TestUtil.GetMemDbOptions("GetsBillingPeriodById");

            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var periodFromRepo = await repo.BillingPeriodFromId(period.BillingPeriodId);
                Assert.Equal(period.BillingPeriodId, periodFromRepo.BillingPeriodId);
            }
        }

        [Fact]
        public async void GetsCurrentBillingPeriod()
        {
            var options = TestUtil.GetMemDbOptions("GetsCurrentBillingPeriod");

            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                period = TestUtil.NewBillingPeriod(db);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var periodFromRepo = await repo.GetCurrentBillingPeriod();
                Assert.Equal(period.BillingPeriodId, periodFromRepo.BillingPeriodId);
            }
        }

        [Fact]
        public async void GetsProjectedResourceUsages()
        {
            var options = TestUtil.GetMemDbOptions("GetsProjectedResourceUsages");

            var testPeriod = new TimeSpan(730, 0, 0, 0);
            Tenant tenant;
            BillingPeriod period;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);
                TestUtil.UseResource(db, tenant.TenantId, 5, ResourceType.Power);

                period = new BillingPeriod();
                var timeSpan = new TimeSpan(5,0,0,0);

                // All test data is 2 years into the future.
                period.PeriodStart = DateTime.Now + testPeriod - timeSpan;
                period.PeriodEnd = DateTime.Now + testPeriod + timeSpan;

                db.Add(period);

                db.SaveChanges();

                TestUtil.NewResourceRate(db, 1, ResourceType.Power, period);
                TestUtil.NewResourceRate(db, 2, ResourceType.Water, period);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IBill)new BillRepository(db);
                var projected = await repo.GetProjectedResourceUsages(tenant.TenantId, period, DateTime.Now + testPeriod);
                projected = projected.ToList();
                // Number will drift slightly due to DateTime.Now calls, round the total to get answer.
                Assert.Equal(18, Math.Round(projected.ElementAt(0).ProjectedCost()));
            }
        }

    }
}