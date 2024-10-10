using NuGet.Configuration;

namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetAllOpenAuctions();
    void Add(string itemName, double price, string description, string sellerName, DateTime endDate);
    
    Auction GetById(int id);
    
    List<Auction> GetByUserName(string userName);

    void Update(int id, string description);
}