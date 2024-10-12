namespace WebApplication1.Core;

public class Auction
{
    /*private static int _nextId = 1;*/

    public int Id { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string UserName { get; set; }
    public double StartPrice { get; set; }
    public DateTime EndDate { get; set; }
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;

    public Auction(string itemName, double startPrice, string description, string userName, DateTime endDate)
    {
        /*Id = _nextId++;*/
        ItemName = itemName;
        UserName = userName;
        Description = description;
        StartPrice = startPrice;
        EndDate = endDate;
    }

    public Auction()
    {
    }
    
    public void AddBid(Bid newBid)
    {
        _bids.Add(newBid);
    }
}