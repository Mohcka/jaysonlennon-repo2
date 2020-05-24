using AptMgmtPortal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AptMgmtPortal.Data
{
    public class AptMgmtDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<BillingPeriod> BillingPeriods { get; set; }
        public DbSet<MaintenanceRequestType> MaintenanceRequestTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TenantResourceUsage> TenantResourceUsages { get; set; }

        public AptMgmtDbContext() { }
        public AptMgmtDbContext(DbContextOptions<AptMgmtDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options
                    .UseSqlite("Data Source=app.sqlite");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserAccountType)
                .HasConversion(new EnumToStringConverter<UserAccountType>());

            modelBuilder.Entity<MaintenanceRequest>()
                .Property(m => m.CloseReason)
                .HasConversion(new EnumToStringConverter<MaintenanceCloseReason>());

            /*
                 preventing efcore from deleting a user
                 with MaintenanceRequest assigned. 
                 Efcore will delete user if we delete maintenanceRequest
                 otherwise, as default is DeleteVehavior.Cascade
             */

            modelBuilder.Entity<User>()
                .HasMany<MaintenanceRequest>(p => p.OpeningMaintenanceRequests)
                .WithOne(m => m.OpeningUser)
                .HasForeignKey(d => d.OpeningUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
             .HasMany<MaintenanceRequest>(p => p.ClosingMaintenanceRequests)
             .WithOne(m => m.ClosingUser)
             .HasForeignKey(d => d.ClosingUserId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}