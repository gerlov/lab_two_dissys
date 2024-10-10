using AuctionApp.Core;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence;

public class ListOfBidsDBContext : DbContext
{
    public ListOfBidsDBContext(DbContextOptions<ListOfBidsDBContext> options) : base(options) { }
    
    public DbSet<BidDB> BidDbs { get; set; }
    public DbSet<ListOfBidsDB> ListOfBidsDbs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ListOfBidsDB ldb = new ListOfBidsDB
        {
            Id = -1,
            Title = "Winning Bids",
            UserName = "Jo4r",
            BidDBs = new List<BidDB>()
        };
        modelBuilder.Entity<ListOfBidsDB>().HasData(ldb);

        BidDB bdb1 = new BidDB
        {
            Id = -1,
            Name = "Vase",
            Status = Status.WINNER,
            Offer = 100,
            ListOfBidsId = -1
        };
        BidDB bdb2 = new BidDB
        {
            Id = -2,
            Name = "Cat",
            Status = Status.WINNER,
            Offer = 350,
            ListOfBidsId = -1
        };
        modelBuilder.Entity<BidDB>().HasData(bdb1);
        modelBuilder.Entity<BidDB>().HasData(bdb2);
        
        ListOfBidsDB pendingLdb = new ListOfBidsDB
        {
            Id = -2,
            Title = "Pending Bids",
            UserName = "Jo4r",
            BidDBs = new List<BidDB>()

        };
        modelBuilder.Entity<ListOfBidsDB>().HasData(pendingLdb);

        BidDB bdb3 = new BidDB
        {
            Id = -3,
            Name = "Rock",
            Status = Status.PENDING,
            Offer = 200,
            ListOfBidsId = -2,
        };
        modelBuilder.Entity<BidDB>().HasData(bdb3);
        
    }
}