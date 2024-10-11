using System.ComponentModel.DataAnnotations;
using WebApplication1.Persistence.BidsDbs;

namespace WebApplication1.Persistence;

public class AuctionDb
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