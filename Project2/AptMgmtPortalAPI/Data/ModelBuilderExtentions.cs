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
            TimeSpan day = new TimeSpan(1, 0, 0, 0);
            TimeSpan month = new TimeSpan(30, 0, 0, 0, 0);
            TimeSpan threeMonth = new TimeSpan(90, 0, 0, 0, 0);
            TimeSpan sixMonth = new TimeSpan(180, 0, 0, 0, 0);
            TimeSpan twelveMonth = new TimeSpan(360, 0, 0, 0, 0);
            DateTime dt1MonthAgo = dateTime.Subtract(month);
            DateTime dt3MonthsAgo = dateTime.Subtract(threeMonth);
            DateTime dt6MonthsAgo = dateTime.Subtract(sixMonth);
            DateTime dt12MonthsAgo = dateTime.Subtract(twelveMonth);



            #region Users Seed
            // Seeds User data. The password for all of these is "password".
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "admin", LastName = "admin", LoginName = "admin", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Admin, ApiKey = "test-key1" },
                new User { UserId = 2, FirstName = "manager", LastName = "manager", LoginName = "manager", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Manager, ApiKey = "test-key2" },
                new User { UserId = 3, FirstName = "Jayson", LastName = "", LoginName = "jayson@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key3" },
                new User { UserId = 4, FirstName = "David", LastName = "", LoginName = "david@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key4" },
                new User { UserId = 5, FirstName = "Michael", LastName = "", LoginName = "michael@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key5" },
                new User { UserId = 6, FirstName = "Sulav", LastName = "", LoginName = "sulav@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key6" },
                new User { UserId = 7, FirstName = "Melvin", LastName = "", LoginName = "melvin@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key7" },
                new User { UserId = 8, FirstName = "Deon", LastName = "", LoginName = "deon@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key8" },
                new User { UserId = 9, FirstName = "Ruth", LastName = "", LoginName = "ruth@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key9" },
                new User { UserId = 10, FirstName = "Frances", LastName = "", LoginName = "frances@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key10" },
                new User { UserId = 11, FirstName = "Linda", LastName = "", LoginName = "linda@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key11" },
                new User { UserId = 12, FirstName = "Regina", LastName = "", LoginName = "regina@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key12" },
                new User { UserId = 13, FirstName = "Demo User", LastName = "Demo Last Name", LoginName = "demo@example.com", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "demo" }
            );
            #endregion

            #region Tenant Seed
            // Seeds Tenant data
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant { TenantId = 1, FirstName = "Jayson", LastName = "Lennon", Email = "jayson@example.com", PhoneNumber = "555-164-317", UserId = 3 },
                new Tenant { TenantId = 2, FirstName = "David", LastName = "Sawyer", Email = "david@example.com", PhoneNumber = "555-195-162", UserId = 4 },
                new Tenant { TenantId = 3, FirstName = "Michael", LastName = "Walker", Email = "michael@example.com", PhoneNumber = "555-115-412", UserId = 5 },
                new Tenant { TenantId = 4, FirstName = "Sulav", LastName = "Aryal", Email = "sulav@example.com", PhoneNumber = "555-787-595", UserId = 6 },
                new Tenant { TenantId = 5, FirstName = "Melvin", LastName = "Johnson", Email = "melvin@example.com", PhoneNumber = "555-858-445", UserId = 7 },
                new Tenant { TenantId = 6, FirstName = "Deon ", LastName = "Smith", Email = "deon@example.com", PhoneNumber = "555-514-298", UserId = 8 },
                new Tenant { TenantId = 7, FirstName = "Ruth ", LastName = "Williams", Email = "ruth@example.com", PhoneNumber = "555-337-777", UserId = 9 },
                new Tenant { TenantId = 8, FirstName = "Frances ", LastName = "Hook", Email = "frances@example.com", PhoneNumber = "555-871-503", UserId = 10 },
                new Tenant { TenantId = 9, FirstName = "Linda", LastName = "Lopez", Email = "linda@example.com", PhoneNumber = "555-607-558", UserId = 11 },
                new Tenant { TenantId = 10, FirstName = "Regina", LastName = "McCoy", Email = "regina@example.com", PhoneNumber = "555-504-625", UserId = 12 },
                new Tenant { TenantId = 11, FirstName = "Demo User", LastName = "Demo Last Name", Email = "demo@example.com", PhoneNumber = "012-555-2394", UserId = 13 }

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
                new Unit { UnitId = 10, TenantId = 10, UnitNumber = "110" },
                new Unit { UnitId = 11, TenantId = 11, UnitNumber = "111" },

                new Unit { UnitId = 12, UnitNumber = "201" },
                new Unit { UnitId = 13, UnitNumber = "202" },
                new Unit { UnitId = 14, UnitNumber = "203" },
                new Unit { UnitId = 15, UnitNumber = "204" },
                new Unit { UnitId = 16, UnitNumber = "205" },
                new Unit { UnitId = 17, UnitNumber = "206" },
                new Unit { UnitId = 18, UnitNumber = "207" },
                new Unit { UnitId = 19, UnitNumber = "208" },
                new Unit { UnitId = 20, UnitNumber = "209" },
                new Unit { UnitId = 21, UnitNumber = "210" }
            );
            #endregion

            #region Tenanant Resource Usages Seed
            modelBuilder.Entity<TenantResourceUsage>().HasData(

                new TenantResourceUsage { TenantResourceUsageId = 1, ResourceType = Types.ResourceType.Internet, TenantId = 1, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 2, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 3, ResourceType = Types.ResourceType.Rent, TenantId = 1, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 4, ResourceType = Types.ResourceType.Trash, TenantId = 1, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 5, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 40.4, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 6, ResourceType = Types.ResourceType.Internet, TenantId = 2, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 7, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 8, ResourceType = Types.ResourceType.Rent, TenantId = 2, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 9, ResourceType = Types.ResourceType.Trash, TenantId = 2, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 10, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 11, ResourceType = Types.ResourceType.Internet, TenantId = 3, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 12, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 13, ResourceType = Types.ResourceType.Rent, TenantId = 3, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 14, ResourceType = Types.ResourceType.Trash, TenantId = 3, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 15, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 16, ResourceType = Types.ResourceType.Internet, TenantId = 4, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 17, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 18, ResourceType = Types.ResourceType.Rent, TenantId = 4, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 19, ResourceType = Types.ResourceType.Trash, TenantId = 4, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 20, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },


                new TenantResourceUsage { TenantResourceUsageId = 21, ResourceType = Types.ResourceType.Internet, TenantId = 5, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 22, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 60.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 23, ResourceType = Types.ResourceType.Rent, TenantId = 5, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 24, ResourceType = Types.ResourceType.Trash, TenantId = 5, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 25, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 40.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 26, ResourceType = Types.ResourceType.Internet, TenantId = 6, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 27, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 60.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 28, ResourceType = Types.ResourceType.Rent, TenantId = 6, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 29, ResourceType = Types.ResourceType.Trash, TenantId = 6, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 30, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 31.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 31, ResourceType = Types.ResourceType.Internet, TenantId = 7, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 32, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 33, ResourceType = Types.ResourceType.Rent, TenantId = 7, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 34, ResourceType = Types.ResourceType.Trash, TenantId = 7, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 35, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 36, ResourceType = Types.ResourceType.Internet, TenantId = 8, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 37, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 38, ResourceType = Types.ResourceType.Rent, TenantId = 8, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 39, ResourceType = Types.ResourceType.Trash, TenantId = 8, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 40, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 41, ResourceType = Types.ResourceType.Internet, TenantId = 9, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 42, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 43, ResourceType = Types.ResourceType.Rent, TenantId = 9, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 44, ResourceType = Types.ResourceType.Trash, TenantId = 9, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 45, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 46, ResourceType = Types.ResourceType.Internet, TenantId = 10, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 47, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 50.55, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 48, ResourceType = Types.ResourceType.Rent, TenantId = 10, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 49, ResourceType = Types.ResourceType.Trash, TenantId = 10, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 50, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 30.33, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },


                // Tenenat 1 power usages
                new TenantResourceUsage { TenantResourceUsageId = 51, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 30.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 52, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 53, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 05.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 54, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 50.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 55, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 56, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 30.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 57, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 31.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 58, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 20.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 59, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 10.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 60, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 30.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 1 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 61, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 10.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 62, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 15.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 63, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 06.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 64, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 21.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 65, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 66, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 67, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 68, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 69, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 70, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 2 power usages
                new TenantResourceUsage { TenantResourceUsageId = 71, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 21.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 72, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 25.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 73, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 15.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 74, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 50.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 75, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 76, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 29.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 77, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 30.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 78, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 20.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 79, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 15.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 80, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 40.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 2 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 81, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 11.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 82, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 14.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 83, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 19.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 84, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 25.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 85, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 86, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 87, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 16.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 88, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 89, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 90, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 3 power usages
                new TenantResourceUsage { TenantResourceUsageId = 91, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 13.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 92, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 18.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 93, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 05.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 94, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 30.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 95, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 51.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 96, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 35.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 97, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 32.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 98, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 19.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 99, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 10.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 100, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 31.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 3 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 101, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 21.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 102, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 22.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 103, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 19.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 104, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 105, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 50.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 106, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 19.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 107, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 108, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 025.63, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 109, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 27.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 110, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 13.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 4 power usages
                new TenantResourceUsage { TenantResourceUsageId = 111, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 03.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 112, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 113, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 016.34, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 114, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 11.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 115, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 116, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 20.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 117, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 15.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 118, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 10.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 119, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 12.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 120, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 011.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 4 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 121, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 13.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 122, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 30.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 123, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 16.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 124, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 125, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 13.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 126, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 127, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 128, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 21.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 129, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 011.43, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 130, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 5 power usages
                new TenantResourceUsage { TenantResourceUsageId = 131, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 132, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 19.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 133, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 15.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 134, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 17.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 135, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 136, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 18.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 137, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 11.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 138, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 139, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 4.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 140, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 5 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 141, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 142, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 143, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 21.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 144, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 145, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 146, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 6.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 147, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 148, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 149, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 16.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 150, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 6 power usages
                new TenantResourceUsage { TenantResourceUsageId = 151, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 152, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 13.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 153, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 25.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 154, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 155, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 156, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 25.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 157, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 21.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 158, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 159, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 15.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 160, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 6 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 161, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 10.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 162, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 19.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 163, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 164, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 165, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 166, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 167, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 168, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 12.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 169, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 13.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 170, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 15.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 7 power usages
                new TenantResourceUsage { TenantResourceUsageId = 171, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 172, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 38.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 173, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 34.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 174, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 29.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 175, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 29.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 176, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 33.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 177, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 26.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 178, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 26.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 179, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 35.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 180, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 7 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 181, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 34.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 182, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 35.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 183, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 36.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 184, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 31.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 185, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 25.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 186, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 36.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 187, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 35.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 188, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 41.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 189, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 34.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 190, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 31.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 8 power usages
                new TenantResourceUsage { TenantResourceUsageId = 191, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 12.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 192, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 13.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 193, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 194, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 11.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 195, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 12.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 196, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 12.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 197, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 28.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 198, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 11.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 199, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 11.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 200, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 3.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 8 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 201, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 202, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 13.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 203, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 204, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 18.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 205, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 8.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 206, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 15.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 207, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 31.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 208, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 209, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 18.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 210, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 9 power usages
                new TenantResourceUsage { TenantResourceUsageId = 211, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 38.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 212, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 213, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 25.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 214, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 10.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 215, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 216, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 18.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 217, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 012.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 218, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 20.52, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 219, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 15.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 220, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 30.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 9 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 221, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 20.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 222, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 29.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 223, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 26.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 224, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 21.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 225, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 20.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 226, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 013.96, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 227, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 012.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 228, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 013.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 229, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 04.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 230, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 06.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 10 power usages
                new TenantResourceUsage { TenantResourceUsageId = 231, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 30.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 232, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 32.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 233, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 35.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 234, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 30.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 235, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 30.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 236, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 237, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 17.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 238, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 11.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 239, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 240, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 17.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 10 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 241, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 20.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 242, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 25.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 243, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 26.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 244, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 21.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 245, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 23.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 246, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 247, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 248, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 20.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 249, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 250, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 20.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Demo tenant utility usages
                new TenantResourceUsage { TenantResourceUsageId = 251, ResourceType = Types.ResourceType.Internet, TenantId = 11, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 252, ResourceType = Types.ResourceType.Rent, TenantId = 11, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },
                new TenantResourceUsage { TenantResourceUsageId = 253, ResourceType = Types.ResourceType.Trash, TenantId = 11, UsageAmount = 1, SampleTime = DateTime.Now - TimeSpan.FromDays(1) },

                new TenantResourceUsage { TenantResourceUsageId = 254, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 25.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 255, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 256, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 15.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 257, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 30.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 258, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 259, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 25.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 260, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 33.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 261, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 15.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 262, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 14.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 263, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 25.29, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },
                new TenantResourceUsage { TenantResourceUsageId = 264, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 19.21, SampleTime = DateTime.Now - TimeSpan.FromDays(12) },
                new TenantResourceUsage { TenantResourceUsageId = 265, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 16.24, SampleTime = DateTime.Now - TimeSpan.FromDays(13) },
                new TenantResourceUsage { TenantResourceUsageId = 266, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 19.21, SampleTime = DateTime.Now - TimeSpan.FromDays(14) },
                new TenantResourceUsage { TenantResourceUsageId = 267, ResourceType = Types.ResourceType.Power, TenantId = 11, UsageAmount = 30.15, SampleTime = DateTime.Now - TimeSpan.FromDays(15) },

                new TenantResourceUsage { TenantResourceUsageId = 268, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 12.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 269, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 8.40, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 270, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 06.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 271, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 13.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 272, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 273, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 274, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 10.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 275, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 19.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 276, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 12.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 277, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 15.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },
                new TenantResourceUsage { TenantResourceUsageId = 278, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 21.40, SampleTime = DateTime.Now - TimeSpan.FromDays(12) },
                new TenantResourceUsage { TenantResourceUsageId = 279, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 23.66, SampleTime = DateTime.Now - TimeSpan.FromDays(13) },
                new TenantResourceUsage { TenantResourceUsageId = 280, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 13.11, SampleTime = DateTime.Now - TimeSpan.FromDays(14) },
                new TenantResourceUsage { TenantResourceUsageId = 281, ResourceType = Types.ResourceType.Water, TenantId = 11, UsageAmount = 18.39, SampleTime = DateTime.Now - TimeSpan.FromDays(15) }
            );
            #endregion

            #region Signed Agreement Seed
            modelBuilder.Entity<Agreement>().HasData(
                new Agreement { AgreementId = 1, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 1 },
                new Agreement { AgreementId = 2, AgreementTemplateId = 2, SignedDate = dt6MonthsAgo, StartDate = dt6MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 2 },
                new Agreement { AgreementId = 3, AgreementTemplateId = 3, SignedDate = dt12MonthsAgo, StartDate = dt12MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 3 },
                new Agreement { AgreementId = 4, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 4 },
                new Agreement { AgreementId = 5, AgreementTemplateId = 2, SignedDate = dt6MonthsAgo, StartDate = dt6MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 5 },
                new Agreement { AgreementId = 6, AgreementTemplateId = 3, SignedDate = dt12MonthsAgo, StartDate = dt12MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 6 },
                new Agreement { AgreementId = 7, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 7 },
                new Agreement { AgreementId = 8, AgreementTemplateId = 2, SignedDate = dt6MonthsAgo, StartDate = dt6MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 8 },
                new Agreement { AgreementId = 9, AgreementTemplateId = 3, SignedDate = dt12MonthsAgo, StartDate = dt12MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 9 },
                new Agreement { AgreementId = 10, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 10 },

                // Demo tenant agreements
                new Agreement { AgreementId = 11, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 11 },
                new Agreement { AgreementId = 12, AgreementTemplateId = 2, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 11 },
                new Agreement { AgreementId = 13, AgreementTemplateId = 3, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now + TimeSpan.FromDays(30), TenantId = 11 }
                );
            #endregion

            #region Resource Usage Rates
            modelBuilder.Entity<ResourceUsageRate>().HasData(
                new ResourceUsageRate { ResourceUsageRateId = 1, ResourceType = Types.ResourceType.Internet, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 50 },
                new ResourceUsageRate { ResourceUsageRateId = 2, ResourceType = Types.ResourceType.Power, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 0.13 },
                new ResourceUsageRate { ResourceUsageRateId = 3, ResourceType = Types.ResourceType.Rent, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 1100 },
                new ResourceUsageRate { ResourceUsageRateId = 4, ResourceType = Types.ResourceType.Trash, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 30 },
                new ResourceUsageRate { ResourceUsageRateId = 5, ResourceType = Types.ResourceType.Water, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 0.1 }

             );
            #endregion

            #region Payment Seed
            modelBuilder.Entity<Payment>().HasData(

                new Payment { PaymentId = 1, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 2, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 3, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 4, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 5, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 6, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 2, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 7, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 2, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 8, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 2, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 9, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 2, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 10, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 2, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 11, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 3, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 12, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 3, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 13, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 3, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 14, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 3, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 15, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 3, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 16, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 4, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 17, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 4, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 18, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 4, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 19, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 4, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 20, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 4, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 21, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 5, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 22, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 5, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 23, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 5, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 24, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 5, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 25, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 5, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 26, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 6, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 27, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 6, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 28, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 6, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 29, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 6, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 30, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 6, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 31, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 7, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 32, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 7, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 33, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 7, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 34, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 7, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 35, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 7, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 36, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 8, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 37, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 8, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 38, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 8, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 39, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 8, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 40, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 8, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 41, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 9, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 42, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 9, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 43, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 9, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 44, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 9, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 45, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 9, TimePaid = DateTime.Now - day },

                new Payment { PaymentId = 46, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 10, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 47, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 10, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 48, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 10, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 49, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 10, TimePaid = DateTime.Now - day },
                new Payment { PaymentId = 50, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 10, TimePaid = DateTime.Now - day }

            );
            #endregion

            #region Maintenance Requeset Seed
            modelBuilder.Entity<MaintenanceRequest>().HasData(
                new MaintenanceRequest
                {
                    MaintenanceRequestId = 1,
                    OpeningUserId = 1,
                    UnitNumber = "101",
                    TimeOpened = dt3MonthsAgo,
                    OpenNotes = "No water",
                    InternalNotes = "Call Plumber",
                    CloseReason = Types.MaintenanceCloseReason.Completed,
                    ClosingUserId = 1,
                    MaintenanceRequestType = "Plumbing",
                    TimeClosed = DateTime.Now,
                    ResolutionNotes = "Fully restored.",

                },
                new MaintenanceRequest { MaintenanceRequestId = 2, OpeningUserId = 1, UnitNumber = "101", TimeOpened = dt3MonthsAgo, OpenNotes = "No Interet", InternalNotes = "Call ISP", CloseReason = Types.MaintenanceCloseReason.Completed, ClosingUserId = 1, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 3, OpeningUserId = 1, UnitNumber = "101", TimeOpened = dt6MonthsAgo, OpenNotes = "Dirty water", InternalNotes = "Call plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByManagement, ClosingUserId = 1, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 4, OpeningUserId = 2, UnitNumber = "102", TimeOpened = dt3MonthsAgo, OpenNotes = "Low water pressure", InternalNotes = "Call plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByTenant, ClosingUserId = 1, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 5, OpeningUserId = 3, UnitNumber = "103", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByManagement, ClosingUserId = 2, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 6, OpeningUserId = 4, UnitNumber = "104", TimeOpened = dt3MonthsAgo, OpenNotes = "Power out", InternalNotes = "Call electric company" },
                new MaintenanceRequest { MaintenanceRequestId = 7, OpeningUserId = 5, UnitNumber = "105", TimeOpened = dt3MonthsAgo, OpenNotes = "Low water pressure", InternalNotes = "Call plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 8, OpeningUserId = 6, UnitNumber = "106", TimeOpened = dt3MonthsAgo, OpenNotes = "No hot water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 9, OpeningUserId = 7, UnitNumber = "107", TimeOpened = dt3MonthsAgo, OpenNotes = "Oven not working", InternalNotes = "Send maintenance" },
                new MaintenanceRequest { MaintenanceRequestId = 10, OpeningUserId = 8, UnitNumber = "108", TimeOpened = dt3MonthsAgo, OpenNotes = "Dead lightbulb", InternalNotes = "Send maintenance" },

                // Demo maintenance requests
                new MaintenanceRequest { MaintenanceRequestId = 11, OpeningUserId = 13, UnitNumber = "111", TimeOpened = DateTime.Now - TimeSpan.FromDays(14), OpenNotes = "Low water pressure", InternalNotes = "Call plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByTenant, ClosingUserId = 1, TimeClosed = DateTime.Now - TimeSpan.FromDays(13), ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 12, OpeningUserId = 2, UnitNumber = "111", TimeOpened = DateTime.Now - TimeSpan.FromDays(10), OpenNotes = "Power out", InternalNotes = "Call electric company" },
                new MaintenanceRequest { MaintenanceRequestId = 13, OpeningUserId = 13, UnitNumber = "111", TimeOpened = DateTime.Now - TimeSpan.FromDays(7), OpenNotes = "Leaky faucet", InternalNotes = "Send maintenance" },
                new MaintenanceRequest { MaintenanceRequestId = 14, OpeningUserId = 13, UnitNumber = "111", TimeOpened = DateTime.Now - TimeSpan.FromDays(3), OpenNotes = "Clogged toilet", InternalNotes = "Call plumber" }
            );
            #endregion

            #region Billing Period Seed

            modelBuilder.Entity<BillingPeriod>().HasData(
                new BillingPeriod { BillingPeriodId = 1, PeriodStart = DateTime.Now - TimeSpan.FromDays(120), PeriodEnd = DateTime.Now - TimeSpan.FromDays(90) },
                new BillingPeriod { BillingPeriodId = 2, PeriodStart = DateTime.Now - TimeSpan.FromDays(90), PeriodEnd = DateTime.Now - TimeSpan.FromDays(60) },
                new BillingPeriod { BillingPeriodId = 3, PeriodStart = DateTime.Now - TimeSpan.FromDays(60), PeriodEnd = DateTime.Now - TimeSpan.FromDays(30) },
                new BillingPeriod { BillingPeriodId = 4, PeriodStart = DateTime.Now - TimeSpan.FromDays(30), PeriodEnd = DateTime.Now - TimeSpan.FromDays(15) },
                new BillingPeriod { BillingPeriodId = 5, PeriodStart = DateTime.Now - TimeSpan.FromDays(15), PeriodEnd = DateTime.Now + TimeSpan.FromDays(15) }
                );
            #endregion

            #region Agreement Seed
            modelBuilder.Entity<AgreementTemplate>().HasData(
                new AgreementTemplate { AgreementTemplateId = 1, Title = "Lease Agreement", Text = @"
1. PROPERTY: TENANT agrees to rent from LANDLORD and LANDLORD agrees to rent to TENANT, City of Loose Coupling, State of Texas (the PREMISES).

2. USE OF THE PREMISES: The TENANT may use the PREMISES only as a single-family residence.

3. UTILITIES: The TENANT will pay for the following utilities: Water and Sewer, Electricity, Garbage Removal, Gas, Oil.

4. EVICTION: If the TENANT does not pay the rent within 30 days of the date when it is due, the TENANT may be evicted. The LANDLORD may also evict the TENANT if the TENANT does not comply with all of the terms of this Lease, or for any other causes allowed by law. If evicted, the TENANT must continue to pay the rent for the rest of the term. The TENANT must also pay all costs, including reasonable attorney fees, related to the eviction and the collection of any monies owed to the LANDLORD, along with the cost of re-entering, re-renting, cleaning and repairing the PREMISES. Rent received from any new tenant during the remaining term of this lease will be applied by the LANDLORD to reduce rent only, which may be owed by the TENANT. 

5. PAYMENTS BY LANDLORD: If the TENANT fails to comply with the terms of this Lease, the LANDLORD may take any required action and charge the cost, including reasonable attorney fees, to the TENANT. Failure to pay such costs upon demand is a violation of this Lease.

6. CARE OF THE PREMISES: The TENANT has examined the PREMISES, including (where applicable) the living quarters, all facilities, furniture and appliances, and is satisfied with its present physical condition. The TENANT agrees to maintain the PREMISES in as good condition as it is at the start of this Lease except for ordinary wear and tear. The TENANT must pay for all repairs, replacements, and damages, whether or not caused by the act or neglect of the TENANT. The TENANT will remove all of the TENANT's property at the end of this Lease. Any property that is left becomes the property of the LANDLORD and may be thrown out. All of TENANT'S garbage will be disposed of properly by TENANT in the appropriate receptacles for garbage collection. Accumulations of garbage in and around the PREMISES or depositing by TENANT or those residing with TENANT of garbage in areas not designated and designed as garbage receptacles shall constitute a violation of this lease. TENANT shall generally maintain the PREMISES in a neat and orderly condition. Damage or destruction by TENANT, TENANT's employees or TENANT's visitors of the PREMISES shall constitute a violation of this Lease.

7. DESTRUCTION OF PREMISES: If the PREMISES are destroyed through no fault of the TENANT, the TENANT's employees or TENANT's visitors, then the Lease will end, and the TENANT will pay rent up to the date of destruction.

8. INTERRUPTION OF SERVICES: The LANDLORD is not responsible for any inconvenience or interruption of services due to repairs, improvements or for any reason beyond the LANDLORD’s control.

9. ALTERATIONS: The TENANT must get the LANDLORD's prior written consent to alter, improve, paint or wallpaper the PREMISES. Alterations, additions, and improvements become the LANDLORD's property.

10. COMPLIANCE WITH LAWS: The TENANT must comply with laws, orders, rules, and requirements of governmental authorities and insurance companies which have issued or are about to issue policies covering the PREMISES and/or its contents.

11. NO WAIVER BY LANDLORD: The LANDLORD does not give up or waive any rights by accepting rent or by failing to enforce any terms of this Lease.

12. NO ASSIGNMENT OR SUBLEASE: The TENANT may not sublease the PREMISES or assign this Lease without the LANDLORD's prior written consent.

13. ENTRY BY LANDLORD: Upon reasonable notice, the LANDLORD may enter the PREMISES to provide services, inspect, repair, improve or show it. The TENANT must notify the LANDLORD if the TENANT is away for 14 days or more. In case of an emergency or the TENANT's absence, the LANDLORD may enter the PREMISES without the TENANT's consent. 

14. QUIET ENJOYMENT: The TENANT may live in and use the PREMISES without interference subject to the terms of this Lease.

15. SUBORDINATION: This Lease and the TENANT's rights are subject and subordinate to present and future mortgages on the property which include the PREMISES. The LANDLORD may execute any papers on the TENANT's behalf as the TENANT's attorney in fact to accomplish this.

16. HAZARDOUS USE: The TENANT will not keep anything in the PREMISES which is dangerous, flammable, explosive or which might increase the danger of fire or any other hazard, or which would increase LANDLORD's fire or hazard insurance.

17. INJURY OR DAMAGE: The TENANT will be responsible for any injury or damage caused by the act or neglect of the TENANT, the TENANT's employees or TENANT's visitors. The LANDLORD is not responsible for any injury or damage unless due to the negligence or improper conduct of the LANDLORD.

18. RENEWALS AND CHANGES IN LEASE: Upon expiration of the rental term provided for above, this lease shall automatically renew itself, indefinitely, for successive one-month periods, unless modified by the parties. The LANDLORD may modify this lease or offer the TENANT a new lease by forwarding to the TENANT a copy of the proposed changes or a copy of the new lease. If changes in this lease or a new lease are offered, the TENANT must notify the LANDLORD of the TENANT's decision to stay within thirty (30) days of the date the proposed changes or the copy of the new lease is received by the TENANT. If the TENANT fails to accept the lease changes or the new lease within thirty (30) days of the date the proposed changes or new lease is offered, the TENANT may be evicted by the LANDLORD, as provided for in State law. Nevertheless, if the rent is increased by the lease changes or new lease, the TENANT will be obligated to pay the new rent, regardless of whether the TENANT has affirmatively accepted the lease changes or new lease, if the TENANT continues to occupy the property on the date the new rent becomes effective.

19. PETS: No dogs, cats, or other animals are allowed on the PREMISES without the LANDLORD's prior written consent.

20. NOTICES: All notices provided by this Lease must be written and delivered personally or by certified mail, return receipt requested, to the parties at their addresses listed above, or to such other address as the parties may from time to time designate. Notices to the LANDLORD must also be sent to the LANDLORD's agent listed above (if any).

21. SIGNS: The TENANT may not put any sign or projection (such as a T.V. or radio antenna) in or out of the windows or exteriors of the PREMISES without the LANDLORD's prior written consent.

22. HOLDOVER RENT: Should this Lease be terminated, either through a valid notice of dispossession by the LANDLORD, or through order of a court, and should TENANT remain on the PREMISES thereafter, then TENANT shall be liable to pay rent at a rate of double the base rent provided for under this lease, from the date of termination until such time as TENANT vacates the PREMISES, whether TENANT vacates the PREMISES voluntarily or through enforcement of an order for eviction.

23. VALIDITY OF LEASE: If a clause or provision of this Lease is legally invalid, the rest of this Lease remains in effect. If a clause or provision of this lease is ambiguous, and it may be interpreted in a manner either consistent or inconsistent with existing law, it shall be interpreted in a manner consistent with existing law.

24. PARTIES: The LANDLORD and each of the TENANTS are bound by this Lease. All parties who lawfully succeed to their rights and responsibilities are also bound.

25. GENDER: The use of any particular gender (masculine, feminine or neuter) and case (singular or plural) in this Lease is for convenience, only. No inference is to be drawn therefrom. The correct gender and case is to be freely substituted throughout, as appropriate.

26. TENANT'S ACKNOWLEDGMENT: The TENANT acknowledges having read all of the terms and conditions of this lease and the attached rules and regulations. TENANT acknowledges that no oral representations have been made to him by the LANDLORD or the LANDLORD's agent(s) other than the representations contained in this Lease. The TENANT acknowledges that he/she is relying only upon the promises and representations contained in this Lease.

27. ENTIRE LEASE: All promises the LANDLORD has made are contained in this written Lease. This Lease can only be changed by an agreement in writing by both the TENANT and the LANDLORD.

28. SIGNATURES: The LANDLORD and the TENANT agree to the terms of this Lease. If this Lease is made by a corporation, its proper corporate officers sign and its corporate seal is affixed.
                " },
                new AgreementTemplate { AgreementTemplateId = 2, Title = "Utility Agreement", Text = @"
Terms and Conditions

    All electrical installation work will be performed in compliance with Federal, State, and Local guidelines and regulations.
    If Sender.Company discovers a need for additional time or materials once the work has commenced, Sender.Company will seek written approval prior to continuing work.
    Customer is responsible for providing unmitigated access to the work area. This includes moving any furnishings, wall-hangings, or other items which could prevent Sender.Company from carrying out the listed services.
    All areas of installation will be left in the condition found unless otherwise stated in writing by Sender.Name.
    Client.FirstName Client.LastName will provide accessible electricity to all working areas including outdoor areas. This includes proving a live power outlet or generator within 150 feet of the working area.
    Sitework, including demolition or removal of debris, is not included in this electric services contract.

Deviations from Building Regulations

Where applicable, all work performed under this electrical services agreement will be executed fully in compliance with applicable Building Regulations and the National Electric Code. Where a Client requires deviation from such regulations, a written instruction and record will be required along with written approval from a governing authority.
Risk and Title of Goods & Property

    All applicable goods and products installed will become property of the client on date of installation.
    All goods not paid in full or remaining with customer will be property of the service provider until payment has been made or delivery has ensued.
    Client is responsible for all insurance of dwellings and service location for entire time of work.

Warranty

Sender.Company has, to the best of their knowledge has provided installation and quality parts for overall best quality of product. Furthermore all parts will be warrantied for a 12 month period after installation for any technical defects.

Acceptance

By signing below, Customer understands and accepts all terms and conditions outlined in this electrical services agreement.
                " },
                new AgreementTemplate { AgreementTemplateId = 3, Title = "Internet Connection Agreement", Text = @"
Internet Service Agreement

Terms of use.

Term

The Agreement will run from START DATE until the services in this Agreement have been provided in full unless premature termination is allowed by this Agreement.

The length of the Agreement may be changed provided that both Sender.Company and Signer.Company give prior notice via written consent.

Payment, Pricing, and Tax

Sender.Company will pay PAYMENT to Signer.Company for the services detailed in this Agreement.

Signer.Company will provide an invoice when the services have been provided.

Payment of invoices must be made within the payment period of Sender.Company receiving the invoice.

Signer.Company is liable for any tax or similar charges associated with the payment.

Late payments will be subject to a daily interest charge of LATE PENALTY PERCENTAGE % of the amount still owed.

In the case of a termination of this Agreement when the agreed services have been partially completed, Sender.Company will be liable to pay Signer.Company for services provided up to the point of Agreement termination unless there has been a breach of the Agreement by Signer.Company.

Any money referred to in this Agreement is in CURRENCY unless specified otherwise.
Content Responsibility/Usage Restrictions

Any intellectual property which is produced under this Agreement is exclusively the property of Sender.Company and its use will be unrestricted and at their sole discretion.

Signer.Company may only use the intellectual property with explicit permission from Sender.Company.

Signer.Company will be liable for any damages arising from the unpermitted use of the intellectual property.

Licensing

If Sender.Company buys any equipment as part of the Service, Signer.Company grants Sender.Company a limited license to use software provided with the equipment subject to the following terms:

    The software is licensed and copyrighted for sole use on the equipment provided to Sender.Company.
    Software provided hereunder is on license by Signer.Company from third parties. The copyright and title to Software stay with the licensor.
    Sender.Company cannot reverse compile or translate in any way the Software.
    Sender.Company can make any number of copies but only for backup purposes.
    All indemnification provisions and liability from this agreement will apply to the licensor.

Indemnification

Each party agrees to indemnify the other party and its respective permitted successors, assigns, officers, affiliates, agents and employees against attorney’s fees and any claims and costs resulting from any actions or omissions of the indemnifying party or its permitted successors, assigns, officers, affiliates, agents and employees in relation to this Agreement, unless paid as part of a relevant insurance policy or required by applicable law.

Termination

    If any of the following events occur in respect to one party, the other party may terminate the agreement at their sole discretion with prior written notice:
        One party voluntarily petitions or is involuntarily petitioned for bankruptcy; becomes insolvent, proposes liquidation, recapitalization, dissolution or reorganization; a receiver is assigned to take property, and this is not dismissed within DISMISSAL PERIOD days.
        A material breach of this agreement is not resolved within RESOLUTION PERIOD after the details of the breach have been given with written notice.
    Sender.Company may terminate the agreement after NOTICE PERIOD if Signer.Company makes any material alterations to the Service that Sender.Company chooses to decline.
    In case of termination, Sender.Company agrees to discontinue using the Service and return any property provided by Signer.Company.

Export Compliance

Transferring of technologies across national boundaries are regulated by United States law. Sender.Company agrees not to export any technologies transmitted via Signer.Company prior to obtaining any relevant export licenses or official government approval.

Force Majeure

Force Majeure refers to any act beyond the reasonable control of either party, including but not limited to acts of God, fires, and war.

In the case of events of Force Majeure interfering with the completion of this Agreement, neither party shall be held responsible by the other.

If either party’s agreed obligations are restricted by Force Majeure, the affected party must take reasonable action to fulfill their obligations. The other party must continue to fulfill their own agreed obligations.

Notice and Payment

Any notices or other forms of communication between Signer.Company and Sender.Company must be delivered via written notice to the following addresses:

Laws

This Agreement is governable in relation to the laws of LAW.

Successors

This agreement will be binding for and will inure to the benefit of the Parties hereto, their administrators, successors, assigns and heirs.

Assignability

The obligations of Signer.Company shall not be transferred in any way or for any reason to another party, unless Sender.Company has given prior notice via approval in writing.

Waiver

Any waiver of any default by either Party shall not be accepted as a waiver of any subsequent or prior default of other or the same provisions of this agreement.

Severability

If any elements of this Agreement become invalid or unenforceable, all other elements of the Agreement will remain valid and enforceable.

Integration

This Agreement represents the entire agreement between Sender.Company and Signer.Company, relevant to the content of the Agreement.
                " }
            );
            #endregion

        }
    }
}
