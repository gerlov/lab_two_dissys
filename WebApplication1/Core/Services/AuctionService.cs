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
        Bid bid = new Bid(offer, auctionId, userName);
        _auctionPersistence.AddBid(bid);
    }

    public void AddAuction(string itemName, double startPrice, string description, string userName, DateTime endDate)
    {
        Auction auction = new Auction(itemName, startPrice, description, userName, endDate);
        _auctionPersistence.SaveAuction(auction);
    }

    public List<Auction> GetAllAuctions()
    {
        List<Auction> auctions = _auctionPersistence.GetAllAuctions();
        return auctions;
    }

    public void UpdateAuction(int auctionId, string userName, string newDescription)
    {
        _auctionPersistence.UpdateAuction(auctionId, userName, newDescription);
    }

    public void ProcessEndedAuctions()  //unused for now
    {
        _auctionPersistence.ProcessEndedAuctions();
    }

    public void ProcessEndedAuctions(HashSet<int> auctionIds)
    {
        _auctionPersistence.ProcessEndedAuctions(auctionIds);
    }


    public Auction GetById(int auctionId)
    {
        Auction auction = _auctionPersistence.GetById(auctionId);
        return auction;
    }
}