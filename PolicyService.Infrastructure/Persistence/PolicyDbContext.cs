using Microsoft.EntityFrameworkCore;
using PolicyService.Domain.Models;

namespace PolicyService.Infrastructure.Persistence
{
    public class PolicyDbContext : DbContext
    {
        public DbSet<Policy> Policies => Set<Policy>();
        public DbSet<PolicyPeriod> Periods => Set<PolicyPeriod>();

        public PolicyDbContext(DbContextOptions<PolicyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>(cfg =>
            {
                cfg.HasKey(p => p.Id);
                cfg.Property(p => p.Number).IsRequired();
                cfg.OwnsMany(p => p.Periods, b =>
                {
                    b.WithOwner().HasForeignKey("PolicyId");
                    b.Property(p => p.Start);
                    b.Property(p => p.End);
                    b.Property(p => p.Premium);
                    b.HasKey("PolicyId", "Start");
                });
            });
        }
    }
}
