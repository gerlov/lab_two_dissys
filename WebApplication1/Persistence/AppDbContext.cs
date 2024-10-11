using Microsoft.EntityFrameworkCore;
using WebApplication1.Persistence.BidsDbs;

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
        AuctionDb adb = new AuctionDb
        {
            Id = -1,
            ItemName = "Seed",
            Description = "Seed Data",
            StartPrice = 9999,
            EndDate = DateTime.Now,
            BidDbs = new List<BidDb>()
        };
        modelBuilder.Entity<AuctionDb>().HasData(adb);

        BidListDb bdb = new BidListDb
        {
            Id = -1,
            Title = "SeedTitle",
            UserName = "SeedUserName",
            BidDbs = new List<BidDb>()
        };
        modelBuilder.Entity<AuctionDb>().HasData(bdb);

        BidDb bidDb = new BidDb
        {
            Id = -1,
            Amount = 100,
            UserName = bdb.UserName,
            AuctionId = adb.Id,
            BidListId = bdb.Id
        };
        modelBuilder.Entity<AuctionDb>().HasData(bidDb);


    }
}