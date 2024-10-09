namespace AuctionApp.Core;


public class Bid
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AuctionId { get; set; }
    private Status _status { get; set; }
    public DateTime BidDate { get; set; }
    public double Offer { get; set; }
    public string UserName;

    public Bid(double offer, string userName, string Name, int auctionId)
    {
        this.UserName = userName;
        this.Offer = offer;
        this.Name = Name;
        this.AuctionId = auctionId;
        this.BidDate = DateTime.Now;

    }

    public Boolean IsWinner()
    {
        return _status == Status.WINNER;
    }

    public Status Status
    {
        get => _status;
        set
        {
            if (_status == Status.WINNER && value != Status.WINNER)
                throw new InvalidOperationException("Already a set to Winner");
            _status = value;
        }
    }
}