using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Auction;

public class EditDescriptionVm
{
    
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    
    [Required]
    [StringLength(1024, ErrorMessage = "Max length 1024 characters")]
    [Display(Name = "Item description")]
    public string description { get; set; }
}