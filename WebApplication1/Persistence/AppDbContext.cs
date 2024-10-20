using Microsoft.EntityFrameworkCore;
using WebApplication1.Persistence.Entities;

namespace WebApplication1.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<BidDb> BidDbs { get; set; }
    public DbSet<BidListDb> BidListDbs { get; set; }
    public DbSet<AuctionDb> AuctionDbs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuctionDb>()
            .HasMany(a => a.BidDbs)
            .WithOne(b => b.AuctionDb)
            .HasForeignKey(b => b.AuctionId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<BidListDb>()
            .HasMany(bl => bl.BidDbs)
            .WithOne(b => b.BidListDb)
            .HasForeignKey(b => b.BidListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}