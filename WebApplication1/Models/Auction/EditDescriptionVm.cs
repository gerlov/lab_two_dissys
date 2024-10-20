using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Auction;

public class EditDescriptionVm
{
    
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    

    [Display(Name = "Item name")]
    [ReadOnly(true)]
    public string ItemName { get; set; }

    [Display(Name = "Username")]
    [ReadOnly(true)]
    public string UserName { get; set; }

    [Display(Name = "Start price")]
    [ReadOnly(true)]
    public double StartPrice { get; set; }
    
    [Display(Name = "End date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd:mm}")]
    [ReadOnly(true)]
    public DateTime EndDate { get; set; }
    
    [Required]
    [StringLength(1024, ErrorMessage = "Max length 1024 characters")]
    [Display(Name = "Item description")]
    public string Description { get; set; }

        public static EditDescriptionVm FromAuction(Core.Auction auction)
    {
        return new EditDescriptionVm()
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