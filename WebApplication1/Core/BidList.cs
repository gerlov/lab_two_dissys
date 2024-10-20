namespace WebApplication1.Core;

public class BidList
{
    
    /*private static int _nextId = 1;*/

    public int Id { get; set; }
    public string Title { get; set; }
    public string UserName { get; set; }
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;

    public BidList(string title, string userName)
    {
        /*Id = _nextId++;*/
        Title = title;
        UserName = userName;
    }

    public BidList()
    {
    }

    public void AddBid(Bid newBid)
    {
        _bids.Add(newBid);
    }

    public void RemoveBid(Bid bid)
    {
        _bids.Remove(bid);
    }
    
}