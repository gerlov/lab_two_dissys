using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Bid;

public class CreateBidVm
{
    [Required]
    [Display(Name = "Bid price")]
    public double price { get; set; }
}