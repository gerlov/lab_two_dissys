namespace WebApplication1.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllAuctions();
    Auction GetById(int auctionId, string userName);
    void SaveAuction(Auction auction);
}