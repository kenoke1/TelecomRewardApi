using Microsoft.EntityFrameworkCore;
using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Data
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Purchase> Purchases { get; set;}
        public DbSet<Reward> Rewards { get; set;}
        public DbSet<Agent> Agents { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.SSN)
                .IsUnique();

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerId);
        }
    }
}
