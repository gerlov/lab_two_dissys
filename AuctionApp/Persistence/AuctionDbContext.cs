using AuctionApp.Core;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }
    
    public DbSet<AuctionDb> AuctionDbs { get; set; }
}