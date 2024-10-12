using WebApplication1.Core.Interfaces;

namespace WebApplication1.Core.Mock;

public class MockAuctionService
{
    public void AddBid(double offer, int auctionId, string userName)
    {
        throw new NotImplementedException();
    }

    public void AddAuction(string itemName, double startPrice, string description, string userName, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public List<Auction> GetAllAuctions()
    {
        return _auctions;
        throw new NotImplementedException();
    }

    public List<Bid> GetAllBids(int auctionId)
    {
        throw new NotImplementedException();
    }

    public Auction GetById(int auctionId, string userName)
    {
        return _auctions.Find(a => a.Id == auctionId && a.UserName == userName);
    }

    private static readonly List<Auction> _auctions = new();

    static MockAuctionService()
    {
        Auction a1 = new Auction("Rock", 100, "It's hard", "Shihab", DateTime.Today);
        Auction a2 = new Auction("Paper", 250, "It's soft", "Shihab", DateTime.Today);
        a1.AddBid(new Bid(100, a1.Id, "Joar"));
        a2.AddBid(new Bid(100, a2.Id, "Alex"));
        a2.AddBid(new Bid(50, a2.Id, "Joar"));
        _auctions.Add(a1);
        _auctions.Add(a2);  
    }
}