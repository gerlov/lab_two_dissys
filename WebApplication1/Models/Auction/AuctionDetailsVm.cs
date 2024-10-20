using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Bid;

namespace WebApplication1.Models.Auction;

public class AuctionDetailsVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    [ScaffoldColumn(false)]
    public double HighestBid { get; set; }
    
    [Display(Name = "Item name")]
    public string ItemName { get; set; }
    public string Description { get; set; }

    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Display(Name = "Start price")]
    public double StartPrice { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd:mm}")]
    public DateTime EndDate { get; set; }

    public List<BidVm> BidVms { get; set; } = new();

    public static AuctionDetailsVm FromAuction(Core.Auction auction)
    {
        var detailsVm = new AuctionDetailsVm()
        {
            Id = auction.Id,
            ItemName = auction.ItemName,
            UserName = auction.UserName,
            Description = auction.Description,
            StartPrice = auction.StartPrice,
            EndDate = auction.EndDate
        };
        foreach (var bid in auction.Bids)
        {
            detailsVm.BidVms.Add(BidVm.FromBid(bid));
        }
        
        if (detailsVm.BidVms.Any())
        {
            detailsVm.HighestBid = detailsVm.BidVms.Max(b => b.Amount);
        }
        else
        {
            detailsVm.HighestBid = detailsVm.StartPrice;
        }

        return detailsVm;
    }
}