using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;


public class MockBidService : IBidService
{
    public List<Bid> GetAllBidsByUserName(string UserName)
    {
        return _bids;
    }

    public Bid GetBidById(int id)
    {
        return _bids[0];
    }

    public bool SetBidToWinner(int id)
    {
        throw new NotImplementedException();
    }


    private static readonly List<Bid> _bids = new();

    static MockBidService()
    {
        Bid bid1 = new Bid(100, "Jo4r", "Vase", 1);
        Bid bid2 = new Bid(9.2, "Jo4r", "Cat", 2);
        Bid bid3 = new Bid(111, "Jo4r", "Vase", 1);
        _bids.Add(bid1);
        _bids.Add(bid2);
        _bids.Add(bid3);
    }
}


