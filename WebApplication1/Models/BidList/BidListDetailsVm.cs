using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Auction;
using WebApplication1.Models.Bid;

namespace WebApplication1.Models.BidList;

public class BidListDetailsVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    public string Title { get; set; }

    [Display(Name = "User name")]
    public string UserName { get; set; }

    public List<BidVm> BidVms { get; set; } = new();

    public static BidListDetailsVm FromBidList(Core.BidList bidList)
    {
        var detailsVm = new BidListDetailsVm()
        {
            Id = bidList.Id,
            Title = bidList.Title,
            UserName = bidList.UserName
        };
        foreach (var bid in bidList.Bids)
        {
            detailsVm.BidVms.Add(BidVm.FromBid(bid));
        }

        return detailsVm;
    }


}