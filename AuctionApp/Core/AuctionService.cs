using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;

public class AuctionService : IAuctionService
{
    
    private readonly IAuctionPersistence _auctionPersistence;

    public AuctionService(IAuctionPersistence auctionPersistence)
    {
        _auctionPersistence = auctionPersistence;
    }

    public List<Auction> GetAllOpenAuctions()
    {
        return _auctionPersistence.GetAllAuctions().OrderBy(auction => auction.endDate).ToList();
    }

    public void Add(string itemName, double price, string description, string sellerName, DateTime endDate)
    {
        _auctionPersistence.Save(new Auction(itemName, price, description, sellerName, endDate));
    }

    public List<Auction> GetByUserName(string userName)
    {
        return _auctionPersistence.GetByUserName(userName).OrderBy(auction => auction.endDate).ToList();
    }
    
    public Auction GetById(int id)
    {
        return _auctionPersistence.GetById(id);
    }

    public void Update(int id, string description)
    {
        _auctionPersistence.Update(id, description);
    }

    /*
    private static readonly List<Auction> _auctions = new List<Auction>();

    static AuctionService()
    {
        Auction a1 = new Auction(-1, "item name", "seller name", DateTime.Now, "a description");
        Auction a2 = new Auction(-2, "item name 2", "seller name 2", DateTime.Now, "a description 2");
        
        _auctions.Add(a1);
        _auctions.Add(a2);
    }
    */
}