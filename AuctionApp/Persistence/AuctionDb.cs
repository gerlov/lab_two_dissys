using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Persistence;

public class AuctionDb
{
    [Key]
    public int id { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string itemName { get; set; }
    
    [Required]
    public double price { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string sellerName { get; set; }
    
    [Required]
    public DateTime endDate { get; set; }
    
    [Required]
    [MaxLength(1024)]
    public string description { get; set; }
}