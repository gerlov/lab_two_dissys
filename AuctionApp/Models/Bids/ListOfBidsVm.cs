using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Bids;

public class ListOfBidsVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    public string Title { get; set; }

    public static ListOfBidsVm FromProject(ListOfBids listOfBids)
    {
        return new ListOfBidsVm()
        {
            Id = listOfBids.Id,
            Title = listOfBids.Title
        };
    }
}