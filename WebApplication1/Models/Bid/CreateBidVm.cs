using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Bid;

public class CreateBidVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    [ScaffoldColumn(false)]
    public double highestBid { get; set; }

    [Required]
    [Display(Name = "Bid price")]
    public double offer { get; set; }
}