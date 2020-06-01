using AptMgmtPortalAPI.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AptMgmtPortalAPI.Data
{
    public class AptMgmtDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ResourceUsageRate> ResourceUsageRates { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<BillingPeriod> BillingPeriods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TenantResourceUsage> TenantResourceUsages { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<SignedAgreement> SignedAgreements { get; set; }

        public AptMgmtDbContext() { }
        public AptMgmtDbContext(DbContextOptions<AptMgmtDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserAccountType)
                .HasConversion(new EnumToStringConverter<Types.UserAccountType>());

            modelBuilder.Entity<MaintenanceRequest>()
                .Property(m => m.CloseReason)
                .HasConversion(new EnumToStringConverter<Types.MaintenanceCloseReason>());

            modelBuilder.Entity<Unit>()
                .HasIndex(u => u.UnitNumber)
                .IsUnique();

            modelBuilder.Seed();
        }

       

    }

    public class TestAptMgmtDbContext : AptMgmtDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options
                    .UseSqlite("Data Source=app.sqlite");
        }
    }
}