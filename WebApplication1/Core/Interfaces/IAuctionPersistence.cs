namespace WebApplication1.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllAuctions();
    Auction GetById(int auctionId);
    void UpdateAuction(int auctionId, string userName, string newDescription);
    void SaveAuction(Auction auction);
    public void ProcessEndedAuctions();
    void AddBid(Bid bid);
}