using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Bid;

public class BidVm
{
    public int Id { get; set; }
    public int AuctionId { get; set; }

    [Display(Name = "User name")]
    public string UserName { get; set; }
    public double Amount { get; set; }



    public static BidVm FromBid(Core.Bid bid)
    {
        return new BidVm()
        {
            Id = bid.Id,
            Amount = bid.Amount,
            AuctionId = bid.AuctionId,
            UserName = bid.UserName
        };
    }
    
}