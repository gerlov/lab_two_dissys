namespace WebApplication1.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllAuctions();
    Auction GetById(int auctionId, string userName);
    void UpdateAuction(int auctionId, string userName, string newDescription);
    void SaveAuction(Auction auction);

    void AddBid(Bid bid);
}