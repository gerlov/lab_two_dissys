using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.BidList;

public class BidListVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    public string Title { get; set; }

    [Display(Name = "User name")]
    public string UserName { get; set; }

    public static BidListVm FromBidList(Core.BidList bidList)
    {
        return new BidListVm()
        {
            Id = bidList.Id,
            Title = bidList.Title,
            UserName = bidList.UserName
        };
    }
}