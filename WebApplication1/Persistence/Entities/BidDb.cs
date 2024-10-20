using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Persistence.Entities;

public class BidDb : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public double Amount { get; set; }
    [Required]
    public int AuctionId { get; set; }
    [Required]
    public string UserName { get; set; }
    
    [ForeignKey("BidListId")]
    public BidListDb BidListDb { get; set; }
    
    [ForeignKey("AuctionId")]
    public AuctionDb AuctionDb { get; set; }
    
    public int BidListId { get; set; }
}