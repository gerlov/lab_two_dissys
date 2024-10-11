namespace AuctionApp.Core;

public class ListOfBids
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string UserName { get; set; }
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;

    public ListOfBids(string title, string userName)
    {
        this.Title = title;
        this.UserName = userName;
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
    
