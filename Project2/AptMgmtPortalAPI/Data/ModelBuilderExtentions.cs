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
                new User { UserId = 3, FirstName = "jayson", LastName = "", LoginName = "jayson", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key3" },
                new User { UserId = 4, FirstName = "david", LastName = "", LoginName = "david", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key4" },
                new User { UserId = 5, FirstName = "michael", LastName = "", LoginName = "michael", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key5" },
                new User { UserId = 6, FirstName = "sulav", LastName = "", LoginName = "sulav", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key6" },
                new User { UserId = 7, FirstName = "melvin", LastName = "", LoginName = "melvin", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key7" },
                new User { UserId = 8, FirstName = "deon", LastName = "", LoginName = "deon", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key8" },
                new User { UserId = 9, FirstName = "ruth", LastName = "", LoginName = "ruth", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key9" },
                new User { UserId = 10, FirstName = "frances", LastName = "", LoginName = "frances", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key10" },
                new User { UserId = 11, FirstName = "linda", LastName = "", LoginName = "linda", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key11" },
                new User { UserId = 12, FirstName = "regina", LastName = "", LoginName = "regina", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key12" },
                new User { UserId = 13, FirstName = "sulav2", LastName = "", LoginName = "sulav2", Password = "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=", UserAccountType = Types.UserAccountType.Tenant, ApiKey = "test-key13" }

            );
            #endregion

            #region Tenant Seed
            // Seeds Tenant data
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant { TenantId = 1, FirstName = "Jayson", LastName = "Lennon", Email = "jayson@gmail.com", PhoneNumber = "555-164-317", UserId = 3 },
                new Tenant { TenantId = 2, FirstName = "David", LastName = "Sawyer", Email = "david@gmail.com", PhoneNumber = "555-195-162", UserId = 4 },
                new Tenant { TenantId = 3, FirstName = "Michael", LastName = "Walker", Email = "michael@gmail.com", PhoneNumber = "555-115-412", UserId = 5 },
                new Tenant { TenantId = 4, FirstName = "Sulav", LastName = "Aryal", Email = "sulav@gmail.com", PhoneNumber = "555-787-595", UserId = 6 },
                new Tenant { TenantId = 5, FirstName = "Melvin", LastName = "Johnson", Email = "melvin@gmail.com", PhoneNumber = "555-858-445", UserId = 7 },
                new Tenant { TenantId = 6, FirstName = "Deon ", LastName = "Smith", Email = "deon@gmail.com", PhoneNumber = "555-514-298", UserId = 8 },
                new Tenant { TenantId = 7, FirstName = "Ruth ", LastName = "Williams", Email = "ruth@gmail.com", PhoneNumber = "555-337-777", UserId = 9 },
                new Tenant { TenantId = 8, FirstName = "Frances ", LastName = "Hook", Email = "frances@gmail.com", PhoneNumber = "555-871-503", UserId = 10 },
                new Tenant { TenantId = 9, FirstName = "Linda", LastName = "Lopez", Email = "linda@gmail.com", PhoneNumber = "555-607-558", UserId = 11 },
                new Tenant { TenantId = 10, FirstName = "Regina", LastName = "McCoy", Email = "regina@gmail.com", PhoneNumber = "555-504-625", UserId = 12 }

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

                new TenantResourceUsage { TenantResourceUsageId = 1, ResourceType = Types.ResourceType.Internet, TenantId = 1, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 2, ResourceType = Types.ResourceType.Power, TenantId = 1, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 3, ResourceType = Types.ResourceType.Rent, TenantId = 1, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 4, ResourceType = Types.ResourceType.Trash, TenantId = 1, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 5, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 40.4, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 6, ResourceType = Types.ResourceType.Internet, TenantId = 2, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 7, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 8, ResourceType = Types.ResourceType.Rent, TenantId = 2, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 9, ResourceType = Types.ResourceType.Trash, TenantId = 2, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 10, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 30.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 11, ResourceType = Types.ResourceType.Internet, TenantId = 3, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 12, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 13, ResourceType = Types.ResourceType.Rent, TenantId = 3, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 14, ResourceType = Types.ResourceType.Trash, TenantId = 3, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 15, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 30.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 16, ResourceType = Types.ResourceType.Internet, TenantId = 4, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 17, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 18, ResourceType = Types.ResourceType.Rent, TenantId = 4, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 19, ResourceType = Types.ResourceType.Trash, TenantId = 4, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 20, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 30.33, SampleTime = DateTime.Now - day},


                new TenantResourceUsage { TenantResourceUsageId = 21, ResourceType = Types.ResourceType.Internet, TenantId = 5, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 22, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 60.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 23, ResourceType = Types.ResourceType.Rent, TenantId = 5, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 24, ResourceType = Types.ResourceType.Trash, TenantId = 5, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 25, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 40.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 26, ResourceType = Types.ResourceType.Internet, TenantId = 6, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 27, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 60.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 28, ResourceType = Types.ResourceType.Rent, TenantId = 6, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 29, ResourceType = Types.ResourceType.Trash, TenantId = 6, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 30, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 31.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 31, ResourceType = Types.ResourceType.Internet, TenantId = 7, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 32, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 33, ResourceType = Types.ResourceType.Rent, TenantId = 7, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 34, ResourceType = Types.ResourceType.Trash, TenantId = 7, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 35, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 30.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 36, ResourceType = Types.ResourceType.Internet, TenantId = 8, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 37, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 38, ResourceType = Types.ResourceType.Rent, TenantId = 8, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 39, ResourceType = Types.ResourceType.Trash, TenantId = 8, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 40, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 30.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 41, ResourceType = Types.ResourceType.Internet, TenantId = 9, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 42, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 43, ResourceType = Types.ResourceType.Rent, TenantId = 9, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 44, ResourceType = Types.ResourceType.Trash, TenantId = 9, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 45, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 30.33, SampleTime = DateTime.Now - day},

                new TenantResourceUsage { TenantResourceUsageId = 46, ResourceType = Types.ResourceType.Internet, TenantId = 10, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 47, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 50.55, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 48, ResourceType = Types.ResourceType.Rent, TenantId = 10, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 49, ResourceType = Types.ResourceType.Trash, TenantId = 10, UsageAmount = 1, SampleTime = DateTime.Now - day},
                new TenantResourceUsage { TenantResourceUsageId = 50, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 30.33, SampleTime = DateTime.Now- day },


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
                new TenantResourceUsage { TenantResourceUsageId = 64, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 31.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 65, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 66, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 67, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 68, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 69, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 70, ResourceType = Types.ResourceType.Water, TenantId = 1, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 2 power usages
                new TenantResourceUsage { TenantResourceUsageId = 71, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 31.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 72, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 25.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 73, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 05.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 74, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 50.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 75, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 76, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 29.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 77, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 30.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 78, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 20.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 79, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 05.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 80, ResourceType = Types.ResourceType.Power, TenantId = 2, UsageAmount = 40.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 2 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 81, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 11.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 82, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 14.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 83, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 09.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 84, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 25.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 85, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 86, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 87, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 05.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 88, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 26.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 89, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 90, ResourceType = Types.ResourceType.Water, TenantId = 2, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 3 power usages
                new TenantResourceUsage { TenantResourceUsageId = 91, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 09.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 92, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 23.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 93, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 05.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 94, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 30.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 95, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 45.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 96, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 30.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 97, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 32.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 98, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 25.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 99, ResourceType = Types.ResourceType.Power, TenantId = 3, UsageAmount = 11.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 100, ResourceType = Types.ResourceType.Power,TenantId = 3, UsageAmount = 31.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 3 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 101, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 15.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 102, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 25.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 103, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 16.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 104, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 105, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 50.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 106, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 26.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 107, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 108, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 06.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 109, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 24.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 110, ResourceType = Types.ResourceType.Water, TenantId = 3, UsageAmount = 13.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },
            
                // Tenenat 4 power usages
                new TenantResourceUsage { TenantResourceUsageId = 111, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 03.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 112, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 113, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 05.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 114, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 10.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 115, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 116, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 20.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 117, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 11.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 118, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 10.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 119, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 15.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 120, ResourceType = Types.ResourceType.Power, TenantId = 4, UsageAmount = 03.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 4 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 121, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 13.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 122, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 30.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 123, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 16.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 124, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 125, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 126, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 127, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 128, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 26.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 129, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 04.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 130, ResourceType = Types.ResourceType.Water, TenantId = 4, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 5 power usages
                new TenantResourceUsage { TenantResourceUsageId = 131, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 132, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 19.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 133, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 15.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 134, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 135, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 136, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 137, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 11.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 138, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 139, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 140, ResourceType = Types.ResourceType.Power, TenantId = 5, UsageAmount = 10.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 5 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 141, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 142, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 143, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 16.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 144, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 145, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 146, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 147, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 148, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 149, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 150, ResourceType = Types.ResourceType.Water, TenantId = 5, UsageAmount = 11.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 6 power usages
                new TenantResourceUsage { TenantResourceUsageId = 151, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 152, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 153, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 25.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 154, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 155, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 156, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 157, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 21.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 158, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 159, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 160, ResourceType = Types.ResourceType.Power, TenantId = 6, UsageAmount = 20.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 6 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 161, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 10.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 162, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 15.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 163, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 164, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 11.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 165, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 166, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 167, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 168, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 169, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 170, ResourceType = Types.ResourceType.Water, TenantId = 6, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 7 power usages
                new TenantResourceUsage { TenantResourceUsageId = 171, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 172, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 39.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 173, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 35.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 174, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 175, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 176, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 35.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 177, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 31.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 178, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 179, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 180, ResourceType = Types.ResourceType.Power, TenantId = 7, UsageAmount = 30.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 7 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 181, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 30.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 182, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 35.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 183, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 36.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 184, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 31.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 185, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 30.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 186, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 36.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 187, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 35.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 188, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 36.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 189, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 34.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 190, ResourceType = Types.ResourceType.Water, TenantId = 7, UsageAmount = 36.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 8 power usages
                new TenantResourceUsage { TenantResourceUsageId = 191, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 192, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 193, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 194, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 195, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 196, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 197, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 31.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 198, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 199, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 09.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 200, ResourceType = Types.ResourceType.Power, TenantId = 8, UsageAmount = 40.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 8 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 201, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 202, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 203, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 204, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 205, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 206, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 10.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 207, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 35.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 208, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 209, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 210, ResourceType = Types.ResourceType.Water, TenantId = 8, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 9 power usages
                new TenantResourceUsage { TenantResourceUsageId = 211, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 31.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 212, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 213, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 25.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 214, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 10.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 215, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 40.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 216, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 10.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 217, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 01.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 218, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 20.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 219, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 10.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 220, ResourceType = Types.ResourceType.Power, TenantId = 9, UsageAmount = 30.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 9 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 221, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 20.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 222, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 25.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 223, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 26.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 224, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 21.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 225, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 20.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 226, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 06.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 227, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 05.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 228, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 06.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 229, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 04.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 230, ResourceType = Types.ResourceType.Water, TenantId = 9, UsageAmount = 06.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },

                // Tenenat 10 power usages
                new TenantResourceUsage { TenantResourceUsageId = 231, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 30.46, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 232, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 29.85, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 233, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 35.33, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 234, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 30.67, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 235, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 30.78, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 236, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.07, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 237, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.36, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 238, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.53, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 239, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.73, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 240, ResourceType = Types.ResourceType.Power, TenantId = 10, UsageAmount = 10.21, SampleTime = DateTime.Now - TimeSpan.FromDays(11) },


                // Tenant 10 Water usages 
                new TenantResourceUsage { TenantResourceUsageId = 241, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 20.41, SampleTime = DateTime.Now - TimeSpan.FromDays(2) },
                new TenantResourceUsage { TenantResourceUsageId = 242, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 25.42, SampleTime = DateTime.Now - TimeSpan.FromDays(3) },
                new TenantResourceUsage { TenantResourceUsageId = 243, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 26.43, SampleTime = DateTime.Now - TimeSpan.FromDays(4) },
                new TenantResourceUsage { TenantResourceUsageId = 244, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 21.46, SampleTime = DateTime.Now - TimeSpan.FromDays(5) },
                new TenantResourceUsage { TenantResourceUsageId = 245, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 20.17, SampleTime = DateTime.Now - TimeSpan.FromDays(6) },
                new TenantResourceUsage { TenantResourceUsageId = 246, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 16.93, SampleTime = DateTime.Now - TimeSpan.FromDays(7) },
                new TenantResourceUsage { TenantResourceUsageId = 247, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 15.74, SampleTime = DateTime.Now - TimeSpan.FromDays(8) },
                new TenantResourceUsage { TenantResourceUsageId = 248, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 16.60, SampleTime = DateTime.Now - TimeSpan.FromDays(9) },
                new TenantResourceUsage { TenantResourceUsageId = 249, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 14.41, SampleTime = DateTime.Now - TimeSpan.FromDays(10) },
                new TenantResourceUsage { TenantResourceUsageId = 250, ResourceType = Types.ResourceType.Water, TenantId = 10, UsageAmount = 16.32, SampleTime = DateTime.Now - TimeSpan.FromDays(11) }
            );
            #endregion

            #region Signed Agreement Seed
            modelBuilder.Entity<Agreement>().HasData(
                new Agreement { AgreementId = 1, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now, TenantId = 1 },
                new Agreement { AgreementId = 2, AgreementTemplateId = 2, SignedDate = dt6MonthsAgo, StartDate = dt6MonthsAgo, EndDate = DateTime.Now, TenantId = 2 },
                new Agreement { AgreementId = 3, AgreementTemplateId = 3, SignedDate = dt12MonthsAgo, StartDate = dt12MonthsAgo, EndDate = DateTime.Now, TenantId = 3 },
                new Agreement { AgreementId = 4, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now, TenantId = 4 },
                new Agreement { AgreementId = 5, AgreementTemplateId = 2, SignedDate = dt6MonthsAgo, StartDate = dt6MonthsAgo, EndDate = DateTime.Now, TenantId = 5 },
                new Agreement { AgreementId = 6, AgreementTemplateId = 3, SignedDate = dt12MonthsAgo, StartDate = dt12MonthsAgo, EndDate = DateTime.Now, TenantId = 6 },
                new Agreement { AgreementId = 7, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now, TenantId = 7 },
                new Agreement { AgreementId = 8, AgreementTemplateId = 2, SignedDate = dt6MonthsAgo, StartDate = dt6MonthsAgo, EndDate = DateTime.Now, TenantId = 8 },
                new Agreement { AgreementId = 9, AgreementTemplateId = 3, SignedDate = dt12MonthsAgo, StartDate = dt12MonthsAgo, EndDate = DateTime.Now, TenantId = 9 },
                new Agreement { AgreementId = 10, AgreementTemplateId = 1, SignedDate = dt3MonthsAgo, StartDate = dt3MonthsAgo, EndDate = DateTime.Now, TenantId = 10 }
                );
            #endregion

            #region Resource Usage Rates
            modelBuilder.Entity<ResourceUsageRate>().HasData(
                new ResourceUsageRate { ResourceUsageRateId = 1, ResourceType = Types.ResourceType.Internet, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 40.45 },
                new ResourceUsageRate { ResourceUsageRateId = 2, ResourceType = Types.ResourceType.Power, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 3.45 },
                new ResourceUsageRate { ResourceUsageRateId = 3, ResourceType = Types.ResourceType.Rent, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 1100 },
                new ResourceUsageRate { ResourceUsageRateId = 4, ResourceType = Types.ResourceType.Trash, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 20.55 },
                new ResourceUsageRate { ResourceUsageRateId = 5, ResourceType = Types.ResourceType.Water, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + sixMonth, Rate = 1.75 }

             );
            #endregion

            #region Payment Seed
            modelBuilder.Entity<Payment>().HasData(

                new Payment { PaymentId = 1, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 1, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 2, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 1, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 3, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 1, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 4, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 1, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 5, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 1, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 6, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 2, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 7, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 2, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 8, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 2, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 9, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 2, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 10, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 2, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 11, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 3, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 12, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 3, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 13, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 3, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 14, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 3, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 15, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 3, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 16, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 4, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 17, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 4, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 18, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 4, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 19, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 4, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 20, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 4, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 21, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 5, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 22, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 5, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 23, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 5, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 24, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 5, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 25, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 5, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 26, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 6, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 27, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 6, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 28, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 6, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 29, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 6, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 30, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 6, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 31, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 7, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 32, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 7, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 33, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 7, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 34, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 7, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 35, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 7, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 36, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 8, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 37, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 8, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 38, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 8, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 39, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 8, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 40, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 8, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 41, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 9, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 42, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 9, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 43, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 9, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 44, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 9, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 45, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 9, TimePaid = DateTime.Now - day},

                new Payment { PaymentId = 46, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Internet, TenantId = 10, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 47, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Power, TenantId = 10, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 48, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Rent, TenantId = 10, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 49, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Trash, TenantId = 10, TimePaid = DateTime.Now - day},
                new Payment { PaymentId = 50, BillingPeriodId = 1, Amount = 100.11, ResourceType = Types.ResourceType.Water, TenantId = 10, TimePaid = DateTime.Now- day }

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
                new MaintenanceRequest { MaintenanceRequestId = 2, OpeningUserId = 1, UnitNumber = "101", TimeOpened = dt3MonthsAgo, OpenNotes = "No Interet", InternalNotes = "Call Comcast", CloseReason = Types.MaintenanceCloseReason.Completed, ClosingUserId = 1, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 3, OpeningUserId = 1, UnitNumber = "101", TimeOpened = dt6MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByManagement, ClosingUserId = 1, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 4, OpeningUserId = 2, UnitNumber = "102", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByTenant, ClosingUserId = 1, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 5, OpeningUserId = 3, UnitNumber = "103", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber", CloseReason = Types.MaintenanceCloseReason.CanceledByManagement, ClosingUserId = 2, TimeClosed = dt1MonthAgo, ResolutionNotes = "Fixed" },
                new MaintenanceRequest { MaintenanceRequestId = 6, OpeningUserId = 4, UnitNumber = "104", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 7, OpeningUserId = 5, UnitNumber = "105", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 8, OpeningUserId = 6, UnitNumber = "106", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 9, OpeningUserId = 7, UnitNumber = "107", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber" },
                new MaintenanceRequest { MaintenanceRequestId = 10, OpeningUserId = 8, UnitNumber = "108", TimeOpened = dt3MonthsAgo, OpenNotes = "No water", InternalNotes = "Call Plumber" }
            );
            #endregion

            #region Billing Period Seed

            modelBuilder.Entity<BillingPeriod>().HasData(
                new BillingPeriod { BillingPeriodId = 1, PeriodStart = dt1MonthAgo, PeriodEnd = DateTime.Now + day},
                new BillingPeriod { BillingPeriodId = 2, PeriodStart = dt3MonthsAgo, PeriodEnd = DateTime.Now + day},
                new BillingPeriod { BillingPeriodId = 3, PeriodStart = dt6MonthsAgo, PeriodEnd = DateTime.Now + day},
                new BillingPeriod { BillingPeriodId = 4, PeriodStart = dt12MonthsAgo, PeriodEnd = DateTime.Now + day}
                );
            #endregion

            #region Agreement Seed
            modelBuilder.Entity<AgreementTemplate>().HasData(
                new AgreementTemplate { AgreementTemplateId = 1, Title = "Lease Agreement", Text = "This is a really long lease agreement text" },
                new AgreementTemplate { AgreementTemplateId = 2, Title = "Utility Agreement", Text = "This is a really long utility agreement text" },
                new AgreementTemplate { AgreementTemplateId = 3, Title = "Internet Connection Agreement", Text = "This is a really long internet connection agreement text" }
            );
            #endregion

        }
    }
}
