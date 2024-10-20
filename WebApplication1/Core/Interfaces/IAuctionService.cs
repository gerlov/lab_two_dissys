namespace WebApplication1.Core.Interfaces;

public interface IAuctionService
{
    void AddBid(double offer, int auctionId, string userName);
    void AddAuction(string itemName, double startPrice, string description, string userName, DateTime endDate);
    List<Auction> GetAllAuctions();

    public void UpdateAuction(int auctionId, string userName, string newDescription);
    public void ProcessEndedAuctions();

    public void ProcessEndedAuctions(HashSet<int> auctionIds);
    Auction GetById(int auctionId);
    
    
}