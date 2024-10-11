namespace WebApplication1.Core.Interfaces;

public interface IAuctionService
{
    void AddBid(double offer, int auctionId, string userName);
    void AddAuction(string itemName, double startPrice, string description, string userName, DateTime endDate);
    List<Auction> GetAllAuctions();
    List<Bid> GetAllBids(int auctionId);

    Auction GetById(int auctionId, string userName);
    
    
}