using WebApplication1.Areas.Identity.Data;

namespace WebApplication1.Core.Interfaces;

public interface IAdminService
{
    List<Auction> GetAllAuctionsByUserName(string userName);
    List<WebApplication1User> GetAllUsers();
    void RemoveAuctionById(int id);
    Task RemoveUserByUserNameAsync(string userName);
}