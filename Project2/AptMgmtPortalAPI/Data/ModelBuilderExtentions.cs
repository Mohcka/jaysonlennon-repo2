using AptMgmtPortalAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace AptMgmtPortalAPI.Data
{

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            DateTime dateTime = DateTime.Now;
            TimeSpan month = new TimeSpan(30, 0, 0, 0, 0);
            TimeSpan threeMonth = new TimeSpan(90, 0, 0, 0, 0);
            TimeSpan sixMonth = new TimeSpan(180, 0, 0, 0, 0);
            TimeSpan twelveMonth = new TimeSpan(360, 0, 0, 0, 0);
            DateTime newDateTimeM = dateTime.Subtract(month);
            DateTime newDateTime3M = dateTime.Subtract(threeMonth);
            DateTime newDateTime6M = dateTime.Subtract(sixMonth);
            DateTime newDateTime12M = dateTime.Subtract(twelveMonth);

            #region Users Seed
            // Seeds User data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, LoginName = "admin", Password = "password", UserAccountType = Types.UserAccountType.Admin, ApiKey = "test-key" },
                new User { UserId = 2, LoginName = "manager", Password = "password", UserAccountType = Types.UserAccountType.Manager, ApiKey = "test-key" },
                new User { UserId = 3, LoginName = "jayson", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 4, LoginName = "david", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 5, LoginName = "michael", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 6, LoginName = "sulav", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 7, LoginName = "melvin", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 8, LoginName = "deon", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 9, LoginName = "ruth", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 10, LoginName = "frances", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 11, LoginName = "linda", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 12, LoginName = "regina", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" },
                new User { UserId = 13, LoginName = "sulav", Password = "password", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key" }

            );
            #endregion

            #region Tenant Seed
            // Seeds Tenant data
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant { TenantId = 1, FirstName = "Jayson", LastName = "Lennon", Email = "jayson@gmail.com", PhoneNumber = "555-1604-317", UserId = 4 },
                new Tenant { TenantId = 2, FirstName = "David", LastName = "Sawyer", Email = "david@gmail.com", PhoneNumber = "555-1958-162", UserId = 5 },
                new Tenant { TenantId = 3, FirstName = "Michael", LastName = "Walker", Email = "michael@gmail.com", PhoneNumber = "555-3115-412", UserId = 6 },
                new Tenant { TenantId = 4, FirstName = "Sulav", LastName = "Aryal", Email = "sulav@gmail.com", PhoneNumber = "555-7873-595", UserId = 7 },
                new Tenant { TenantId = 5, FirstName = "Melvin", LastName = "Johnson", Email = "melvin@gmail.com", PhoneNumber = "555-2858-445", UserId = 8 },
                new Tenant { TenantId = 6, FirstName = "Deon ", LastName = "Smith", Email = "deon@gmail.com", PhoneNumber = "555-5140-298", UserId = 9 },
                new Tenant { TenantId = 7, FirstName = "Ruth ", LastName = "Williams", Email = "ruth@gmail.com", PhoneNumber = "555-3037-777", UserId = 10 },
                new Tenant { TenantId = 8, FirstName = "Frances ", LastName = "Hook", Email = "frances@gmail.com", PhoneNumber = "555-9871-503", UserId = 11 },
                new Tenant { TenantId = 9, FirstName = "Linda", LastName = "Lopez", Email = "linda@gmail.com", PhoneNumber = "555-6027-558", UserId = 12 },
                new Tenant { TenantId = 10, FirstName = "Regina", LastName = "McCoy", Email = "regina@gmail.com", PhoneNumber = "555-5304-625", UserId = 13 }

            );
            #endregion

            #region Unit Seed
            // Seeds Units
            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitId = 1, TenantId = 1, UnitNumber = "101" },
                new Unit { UnitId = 2, TenantId = 2, UnitNumber = "102" },
                new Unit { UnitId = 3, TenantId = 3, UnitNumber = "103" },
                new Unit { UnitId = 4, TenantId = 4, UnitNumber = "104" },
                new Unit { UnitId = 5, TenantId = 5, UnitNumber = "105" },
                new Unit { UnitId = 6, TenantId = 6, UnitNumber = "106" },
                new Unit { UnitId = 7, TenantId = 7, UnitNumber = "107" },
                new Unit { UnitId = 8, TenantId = 8, UnitNumber = "108" },
                new Unit { UnitId = 9, TenantId = 9, UnitNumber = "109" },
                new Unit { UnitId = 10, TenantId = 10, UnitNumber = "110" }
            );
            #endregion

            #region Tenanant Resource Usages Seed
            modelBuilder.Entity<TenantResourceUsage>().HasData(

                new TenantResourceUsage { TenantResourceUsageId = 1, ResourceType = Types.ResourceType.Internet, TenantId = 1, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 2, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 3, ResourceType = Types.ResourceType.Rent, TenantId = 1, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 4, ResourceType = Types.ResourceType.Trash, TenantId = 1, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 5, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 30.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 6, ResourceType = Types.ResourceType.Internet, TenantId = 2, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 7, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 8, ResourceType = Types.ResourceType.Rent, TenantId = 2, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 9, ResourceType = Types.ResourceType.Trash, TenantId = 2, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 10, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 30.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 11, ResourceType = Types.ResourceType.Internet, TenantId = 3, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 12, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 13, ResourceType = Types.ResourceType.Rent, TenantId = 3, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 14, ResourceType = Types.ResourceType.Trash, TenantId = 3, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 15, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 30.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 16, ResourceType = Types.ResourceType.Internet, TenantId = 4, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 17, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 18, ResourceType = Types.ResourceType.Rent, TenantId = 4, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 19, ResourceType = Types.ResourceType.Trash, TenantId = 4, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 20, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 30.33, SampleTime = DateTime.Now },


                new TenantResourceUsage { TenantResourceUsageId = 21, ResourceType = Types.ResourceType.Internet, TenantId = 5, UsageAmount = 150, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 22, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 60.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 23, ResourceType = Types.ResourceType.Rent, TenantId = 5, UsageAmount = 1200.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 24, ResourceType = Types.ResourceType.Trash, TenantId = 5, UsageAmount = 20.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 25, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 40.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 26, ResourceType = Types.ResourceType.Internet, TenantId = 6, UsageAmount = 150, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 27, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 60.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 28, ResourceType = Types.ResourceType.Rent, TenantId = 6, UsageAmount = 1200.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 29, ResourceType = Types.ResourceType.Trash, TenantId = 6, UsageAmount = 25.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 30, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 31.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 31, ResourceType = Types.ResourceType.Internet, TenantId = 7, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 32, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 33, ResourceType = Types.ResourceType.Rent, TenantId = 7, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 34, ResourceType = Types.ResourceType.Trash, TenantId = 7, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 35, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 30.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 36, ResourceType = Types.ResourceType.Internet, TenantId = 8, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 37, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 38, ResourceType = Types.ResourceType.Rent, TenantId = 8, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 39, ResourceType = Types.ResourceType.Trash, TenantId = 8, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 40, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 30.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 41, ResourceType = Types.ResourceType.Internet, TenantId = 9, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 42, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 43, ResourceType = Types.ResourceType.Rent, TenantId = 9, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 44, ResourceType = Types.ResourceType.Trash, TenantId = 9, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 45, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 30.33, SampleTime = DateTime.Now },

                new TenantResourceUsage { TenantResourceUsageId = 46, ResourceType = Types.ResourceType.Internet, TenantId = 10, UsageAmount = 100, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 47, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 50.55, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 48, ResourceType = Types.ResourceType.Rent, TenantId = 10, UsageAmount = 1100.50, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 49, ResourceType = Types.ResourceType.Trash, TenantId = 10, UsageAmount = 15.56, SampleTime = DateTime.Now },
                new TenantResourceUsage { TenantResourceUsageId = 50, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 30.33, SampleTime = DateTime.Now }
            );
            #endregion

            #region Signed Agreement Seed
            modelBuilder.Entity<SignedAgreement>().HasData(
                new SignedAgreement { SignedAgreementId = 1, AgreementId = 1, SignedDate = newDateTime3M, StartDate = newDateTime3M, EndDate = DateTime.Now, TenantId = 1 },
                new SignedAgreement { SignedAgreementId = 2, AgreementId = 2, SignedDate = newDateTime6M, StartDate = newDateTime6M, EndDate = DateTime.Now, TenantId = 2 },
                new SignedAgreement { SignedAgreementId = 3, AgreementId = 3, SignedDate = newDateTime12M, StartDate = newDateTime12M, EndDate = DateTime.Now, TenantId = 3 },
                new SignedAgreement { SignedAgreementId = 4, AgreementId = 4, SignedDate = newDateTime3M, StartDate = newDateTime3M, EndDate = DateTime.Now, TenantId = 4 },
                new SignedAgreement { SignedAgreementId = 5, AgreementId = 5, SignedDate = newDateTime6M, StartDate = newDateTime6M, EndDate = DateTime.Now, TenantId = 5 },
                new SignedAgreement { SignedAgreementId = 6, AgreementId = 6, SignedDate = newDateTime12M, StartDate = newDateTime12M, EndDate = DateTime.Now, TenantId = 6 },
                new SignedAgreement { SignedAgreementId = 7, AgreementId = 7, SignedDate = newDateTime3M, StartDate = newDateTime3M, EndDate = DateTime.Now, TenantId = 7 },
                new SignedAgreement { SignedAgreementId = 8, AgreementId = 8, SignedDate = newDateTime6M, StartDate = newDateTime6M, EndDate = DateTime.Now, TenantId = 8 },
                new SignedAgreement { SignedAgreementId = 9, AgreementId = 9, SignedDate = newDateTime12M, StartDate = newDateTime12M, EndDate = DateTime.Now, TenantId = 9 },
                new SignedAgreement { SignedAgreementId = 10, AgreementId = 10, SignedDate = newDateTime3M, StartDate = newDateTime3M, EndDate = DateTime.Now, TenantId = 10 }
                );
            #endregion

            #region Resource Usage Rates
            modelBuilder.Entity<ResourceUsageRate>().HasData(
                new ResourceUsageRate { ResourceUsageRateId = 1, ResourceType = Types.ResourceType.Internet, PeriodStart = newDateTime3M, PeriodEnd = DateTime.Now, Rate = 40.45 },
                new ResourceUsageRate { ResourceUsageRateId = 2, ResourceType = Types.ResourceType.Power, PeriodStart = newDateTime3M, PeriodEnd = DateTime.Now, Rate = 30.45 },
                new ResourceUsageRate { ResourceUsageRateId = 3, ResourceType = Types.ResourceType.Rent, PeriodStart = newDateTime3M, PeriodEnd = DateTime.Now, Rate = 1100 },
                new ResourceUsageRate { ResourceUsageRateId = 4, ResourceType = Types.ResourceType.Trash, PeriodStart = newDateTime3M, PeriodEnd = DateTime.Now, Rate = 20.55 },
                new ResourceUsageRate { ResourceUsageRateId = 5, ResourceType = Types.ResourceType.Water, PeriodStart = newDateTime3M, PeriodEnd = DateTime.Now, Rate = 15.75 }
             );
            #endregion

            #region Payment Seed
            modelBuilder.Entity<Payment>().HasData(

                new Payment { PaymentId = 1, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 2, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 3, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 4, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 5, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 6, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 7, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 8, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 9, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 10, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 11, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 12, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 13, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 14, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 15, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 16, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 17, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 18, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 19, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 20, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 21, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 22, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 23, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 24, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 25, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 26, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 27, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 28, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 29, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 30, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 31, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 32, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 33, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 34, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 35, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 36, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 37, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 38, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 39, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 40, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 41, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 42, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 43, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 44, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 45, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now },

                new Payment { PaymentId = 46, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 47, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 48, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 49, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now },
                new Payment { PaymentId = 50, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now }

            );
            #endregion

            #region Maintenance Requeset Seed
            modelBuilder.Entity<MaintenanceRequest>().HasData(
                new MaintenanceRequest
                {
                    MaintenanceRequestId = 1,
                    OpeningUserId = 1,
                    UnitNumber = "101",
                    TimeOpened = newDateTime3M,
                    OpenNotes = "No water",
                    InternalNotes = "Call Plumber",
                    CloseReason = Types.MaintenanceCloseReason.Completed,
                    ClosingUserId = 1,
                    MaintenanceRequestType = "Plumbing",
                    TimeClosed = DateTime.Now,
                    ResolutionNotes = "Fully restored.",

                },
                new MaintenanceRequest { MaintenanceRequestId = 2, OpeningUserId = 1, UnitNumber = "101", TimeOpened = newDateTime3M, OpenNotes = "No Interet", InternalNotes = "Call Comcast", CloseReason = Types.MaintenanceCloseReason.Completed, ClosingUserId = 1 },
                new MaintenanceRequest { MaintenanceRequestId = 3, OpeningUserId = 1, UnitNumber = "101", TimeOpened = newDateTime6M, OpenNotes = "No water", InternalNotes = "Call Plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByManagement, ClosingUserId = 1 },
                new MaintenanceRequest { MaintenanceRequestId = 4, OpeningUserId = 2, UnitNumber = "102", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByTenant, ClosingUserId = 1 },
                new MaintenanceRequest { MaintenanceRequestId = 5, OpeningUserId = 3, UnitNumber = "103", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByManagement },
                new MaintenanceRequest { MaintenanceRequestId = 6, OpeningUserId = 4, UnitNumber = "104", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 7, OpeningUserId = 5, UnitNumber = "105", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 8, OpeningUserId = 6, UnitNumber = "106", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 9, OpeningUserId = 7, UnitNumber = "107", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 10, OpeningUserId = 8, UnitNumber = "108", TimeOpened = newDateTime3M, OpenNotes = "No water", InternalNotes = "Call Plumber" }
            );
            #endregion

            #region Billing Period Seed

            modelBuilder.Entity<BillingPeriod>().HasData(
                new BillingPeriod { BillingPeriodId = 1, PeriodStart = newDateTimeM, PeriodEnd = DateTime.Now },
                new BillingPeriod { BillingPeriodId = 2, PeriodStart = newDateTime3M, PeriodEnd = DateTime.Now },
                new BillingPeriod { BillingPeriodId = 3, PeriodStart = newDateTime6M, PeriodEnd = DateTime.Now },
                new BillingPeriod { BillingPeriodId = 4, PeriodStart = newDateTime12M, PeriodEnd = DateTime.Now }
                );
            #endregion

            #region Agreement Seed
            modelBuilder.Entity<Agreement>().HasData(
                new Agreement { AgreementId = 1, Title = "Lease Agreement", Text = "This is a really long lease agreement text" },
                new Agreement { AgreementId = 2, Title = "Utility Agreement", Text = "This is a really long utility agreement text" },
                new Agreement { AgreementId = 3, Title = "Internet Connection Agreement", Text = "This is a really long internet connection agreement text" }
            );
            #endregion

        }
    }
}
