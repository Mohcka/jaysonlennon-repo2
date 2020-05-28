using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using AptMgmtPortal.Data;
using AptMgmtPortal.Entity;
using AptMgmtPortal.Types;

namespace TestAptMgmtPortal
{
    public class TestUtil
    {
        public static DbContextOptions<AptMgmtDbContext> GetMemDbOptions(string dbName)
        {
            var sqlite = new SqliteConnection("Filename=:memory:");
            sqlite.Open();
            var options = new DbContextOptionsBuilder<AptMgmtDbContext>()
                       .UseSqlite(sqlite)
                       .Options;

            using (var db = new AptMgmtDbContext(options))
            {
                db.Database.Migrate();
            }

            return options;
        }

        public static Tenant NewTenant(AptMgmtDbContext context)
        {
            var tenant = new Tenant();
            context.Add(tenant);
            context.SaveChanges();
            return tenant;
        }

        public static User NewUser(AptMgmtDbContext context)
        {
            var user = new User();
            context.Add(user);
            context.SaveChanges();
            return user;
        }

        public static Unit NewUnit(AptMgmtDbContext context, string unitNumber)
        {
            var unit = new Unit();
            unit.UnitNumber = unitNumber;

            context.Add(unit);
            context.SaveChanges();

            return unit;
        }

        public static TenantResourceUsage UseResource(AptMgmtDbContext context,
                                                      int tenantId,
                                                      double amount,
                                                      ResourceType resourceType)
        {
            var consumedResource = new TenantResourceUsage
            {
                SampleTime = DateTime.Now,
                UsageAmount = amount,
                ResourceType = resourceType,
                TenantId = tenantId,
            };

            context.Add(consumedResource);
            context.SaveChanges();

            return consumedResource;
        }

        public static BillingPeriod NewBillingPeriod(AptMgmtDbContext context)
        {
            var period = new BillingPeriod();
            var timeSpan = new TimeSpan(5, 0, 0, 0);
            period.PeriodStart = DateTime.Now - timeSpan;
            period.PeriodEnd = DateTime.Now + timeSpan;

            context.Add(period);
            context.SaveChanges();

            return period;
        }

        public static Payment NewPayment(AptMgmtDbContext context, int tenantId)
        {
            var payment = new Payment();
            payment.TenantId = tenantId;

            context.Add(payment);
            context.SaveChanges();

            return payment;
        }

        public static ResourceUsageRate NewResourceRate(AptMgmtDbContext context,
                                                double rate,
                                                ResourceType resource,
                                                BillingPeriod period)
        {
            var newRate = new ResourceUsageRate();
            newRate.PeriodStart = period.PeriodStart;
            newRate.PeriodEnd = period.PeriodEnd;
            newRate.Rate = rate;
            newRate.ResourceType = resource;

            context.Add(newRate);
            context.SaveChanges();

            return newRate;
        }

        public static Agreement NewAgreement(AptMgmtDbContext context, string title)
        {
            var agreement = new Agreement();
            agreement.Title = title;

            context.Add(agreement);
            context.SaveChanges();

            return agreement;
        }

        public static SignedAgreement SignAgreement(AptMgmtDbContext context, int agreementId, int tenantId)
        {
            var signedAgreement = new SignedAgreement();
            signedAgreement.TenantId = tenantId;
            signedAgreement.AgreementId = agreementId;
            signedAgreement.SignedDate = DateTime.Now;
            signedAgreement.StartDate = DateTime.Now - new TimeSpan(5, 0, 0, 0);
            signedAgreement.EndDate = DateTime.Now + new TimeSpan(5, 0, 0, 0);

            context.Add(signedAgreement);
            context.SaveChanges();

            return signedAgreement;
        }
    }
}
