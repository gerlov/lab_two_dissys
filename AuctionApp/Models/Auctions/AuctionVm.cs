using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Auctions;

public class AuctionVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    [Display(Name = "Item name")]
    public string itemName { get; set; }
    
    [Display(Name = "price")]
    public double price { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    public DateTime endDate { get; set; }

    public static AuctionVm FromAuction(Auction auction)
    {
        return new AuctionVm()
        {
            Id = auction.id,
            itemName = auction.itemName,
            price = auction.price,
            endDate = auction.endDate
        };
    }
    
    
}