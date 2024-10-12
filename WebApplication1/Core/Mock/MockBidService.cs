using WebApplication1.Core.Interfaces;

namespace WebApplication1.Core.Mock;

public class MockBidService
{
    public List<BidList> GetAllByUserName(string userName)
    {
        return _bidLists;
    }

    public BidList GetById(int bidListId, string userName)
    {
        return _bidLists.Find(list => list.Id == bidListId && list.UserName == userName);
    }

    public void AddList(string userName)
    {
        throw new NotImplementedException();
    }
    
    private static readonly List<BidList> _bidLists = new();

    static MockBidService()
    {
        BidList b1 = new BidList("Won bids", "Joar");
        BidList b2 = new BidList("Pending bids", "Joar");
        b1.AddBid(new Bid(100, 1, "Joar"));
        b1.AddBid(new Bid(150, 1, "Joar"));
        b2.AddBid(new Bid(100, 2, "Joar"));
        _bidLists.Add(b1);
        _bidLists.Add(b2);
    }

}