using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Bids;

public class ListDetailsVm
{
    [ScaffoldColumn(false)] 
    public int Id { get; set; }
    public string Title { get; set; }
    public List<BidVm> BidsVMs { get; set; } = new();

    public static ListDetailsVm FromList(ListOfBids listOfBids)
    {
        var detailsVM = new ListDetailsVm()
        {
            Id = listOfBids.Id,
            Title = listOfBids.Title
        };
        foreach (var bid in listOfBids.Bids)
        {
            detailsVM.BidsVMs.Add(BidVm.FromBid(bid));
        }

        return detailsVM;
    }
}