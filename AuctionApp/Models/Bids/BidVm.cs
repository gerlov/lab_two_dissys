using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Bids;

public class BidVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    public string Name { get; set; }
    [Display(Name = "Placed bid date")]
    public DateTime placedBidDate { get; set; }
    public Boolean isWinner { get; set; }
    public double Offer { get; set; }


    public static BidVm FromBid(Bid bid)
    {
        return new BidVm()
        {
            Id = bid.Id,
            Name = bid.Name,
            placedBidDate = bid.BidDate,
            isWinner = bid.IsWinner(),
            Offer = bid.Offer
        };
        
    }
}