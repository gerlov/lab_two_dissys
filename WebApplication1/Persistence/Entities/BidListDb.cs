using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Persistence.Entities;

public class BidListDb : BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string UserName { get; set; }

    public List<BidDb> BidDbs { get; set; } = new List<BidDb>();

}