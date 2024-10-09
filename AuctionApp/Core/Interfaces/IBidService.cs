namespace AuctionApp.Core.Interfaces;

public interface IBidService
{
    List<Bid> GetAllBidsByUserName(string UserName);
    Bid GetBidById(int id);
    Boolean SetBidToWinner(int id);
    
}