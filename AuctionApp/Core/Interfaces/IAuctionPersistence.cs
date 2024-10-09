namespace AuctionApp.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllAuctions();
    
    void Save(Auction auction);
}