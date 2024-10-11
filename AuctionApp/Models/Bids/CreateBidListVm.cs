using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Views.Bid;

public class CreateBidListVm
{
    [Required]
    public string? Title { get; set; }
}