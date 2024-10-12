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
    
}