namespace AuctionApp.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetAllAuctions();
    
    Auction GetById(int id);
    
    List<Auction> GetByUserName(string userName);
    
    void Save(Auction auction);

    void Update(int id, string description);
}