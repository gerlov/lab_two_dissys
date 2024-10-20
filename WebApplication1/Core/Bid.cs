namespace WebApplication1.Core;

public class Bid
{
    /*private static int _nextId = 1;*/
    public int Id { get; set; }
    public double Amount { get; set; }
    public int AuctionId { get; set; }
    public string UserName { get; set; }

    public Bid(double amount, int auctionId, string userName)
    {
        /*Id = _nextId++; */
        Amount = amount;
        AuctionId = auctionId;
        UserName = userName;
    }
}