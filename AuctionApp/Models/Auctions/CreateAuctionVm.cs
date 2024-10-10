using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Auctions;

public class CreateAuctionVm
{
    [Required]
    [StringLength(128, ErrorMessage = "Max length 128 characters")]
    [Display(Name = "Item name")]
    public string itemName { get; set; }
    
    [Required]
    [StringLength(1024, ErrorMessage = "Max length 1024 characters")]
    [Display(Name = "Item description")]
    public string description { get; set; }
    
    [Required]
    [Display(Name = "Initial price")]
    public double price { get; set; }
    
    [Required]
    [Display(Name = "End date")]
    [DataType(DataType.DateTime)]
    public DateTime endDate { get; set; }
    
    public static CreateAuctionVm FromAuction(Auction auction)
    {
        return new CreateAuctionVm()
        {
            itemName = auction.itemName,
            description = auction.description,
            price = auction.price,
            endDate = auction.endDate
        };
    }
    
}