using NuGet.Configuration;

namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetAllOpenAuctions();
    void Add(string itemName, double price, string description, DateTime endDate);
}