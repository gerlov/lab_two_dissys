using System.ComponentModel.DataAnnotations;
using WebApplication1.Persistence.BidsDbs;

namespace WebApplication1.Persistence;

public class BidListDb
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string UserName { get; set; }

    public List<BidDb> BidDbs { get; set; } = new List<BidDb>();

}