using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AptMgmtPortal.Data
{
    public class PortalContext : DbContext
    {
        public DbSet<Entity.User> Users { get; set; }

        public PortalContext() { }
        public PortalContext(DbContextOptions<PortalContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options
                    .UseSqlite("Data Source=app.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Entity.User>()
                .Property(u => u.AccountType)
                .HasConversion(new EnumToStringConverter<Types.UserAccount>());
        }
    }
}