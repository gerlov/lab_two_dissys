using WebApplication1.Core.Interfaces;

namespace WebApplication1.Core.Services;

public class AuctionService : IAuctionService
{

    private readonly IAuctionPersistence _auctionPersistence;

    public AuctionService(IAuctionPersistence auctionPersistence)
    {
        _auctionPersistence = auctionPersistence; 
    }
    public void AddBid(double offer, int auctionId, string userName)
    {
        throw new NotImplementedException();
    }

    public void AddAuction(string itemName, double startPrice, string description, string userName, DateTime endDate)
    {
        Auction auction = new Auction(itemName, startPrice, description, userName, endDate);
        _auctionPersistence.SaveAuction(auction);
        throw new NotImplementedException();
    }

    public List<Auction> GetAllAuctions()
    {
        List<Auction> auctions = _auctionPersistence.GetAllAuctions();
        return auctions;
    }

    public List<Bid> GetAllBids(int auctionId)
    {
        throw new NotImplementedException();
    }

    public Auction GetById(int auctionId, string userName)
    {
        Auction auction = _auctionPersistence.GetById(auctionId, userName);
        return auction;
    }
}