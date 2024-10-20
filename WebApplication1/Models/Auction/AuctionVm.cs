using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Auction;

public class AuctionVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }

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


    public static AuctionVm FromAuction(Core.Auction auction)
    {
        return new AuctionVm()
        {
            Id = auction.Id,
            ItemName = auction.ItemName,
            Description = auction.Description,
            UserName = auction.UserName,
            StartPrice = auction.StartPrice,
            EndDate = auction.EndDate
        };
    }
}