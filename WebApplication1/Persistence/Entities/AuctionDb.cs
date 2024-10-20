using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Persistence.Entities;

public class AuctionDb : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ItemName { get; set; }
    public string Description { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public double StartPrice { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    public List<BidDb> BidDbs { get; set; } = new List<BidDb>();
}