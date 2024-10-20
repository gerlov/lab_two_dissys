using Microsoft.AspNetCore.Identity;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Core.Interfaces;

namespace WebApplication1.Core.Services;

public class AdminService : IAdminService
{
    
    private readonly UserManager<WebApplication1User> _userManager;
    private readonly IAuctionPersistence _auctionPersistence;
    private readonly IBidPersistence _bidPersistence;
    
    public AdminService(UserManager<WebApplication1User> userManager, IAuctionPersistence auctionPersistence, IBidPersistence bidPersistence)
    {
        _userManager = userManager;
        _auctionPersistence = auctionPersistence;
        _bidPersistence = bidPersistence;
    }
    
    public List<Auction> GetAllAuctionsByUserName(string userName)
    { 
        return _auctionPersistence.GetAuctionsByUser(userName);
    }

    public List<WebApplication1User> GetAllUsers()
    {
        return _userManager.Users.ToList();
    }

    public void RemoveAuctionById(int id)
    {
        _auctionPersistence.RemoveAuction(id);
    }

    public async Task RemoveUserByUserNameAsync(string userName)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var auctions = _auctionPersistence.GetAuctionsByUser(userName);
                foreach (var auction in auctions)
                {
                    _auctionPersistence.RemoveAuction(auction.Id);
                }

                var bidLists = _bidPersistence.GetAllByUserName(userName);
                foreach (var bidList in bidLists)
                {
                    _bidPersistence.RemoveBidList(bidList.Id);
                }

                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    Console.WriteLine($"Error deleting usr {userName}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error -- {ex.Message}");
        }
    }
}