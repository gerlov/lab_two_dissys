using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuctionApp.Core;

namespace AuctionApp.Persistence;

public class BidDB
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(256)]
    public string Name { get; set; }
    
    [Required]
    public double Offer { get; set; }
    
    [Required]
    public Status Status { get; set; }
    
    [ForeignKey("ListOfBidsId")]
    public ListOfBidsDB ListOfBidsDb { get; set; }
    
    public int ListOfBidsId { get; set; }
}