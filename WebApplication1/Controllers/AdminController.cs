using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Models.Admin;
using WebApplication1.Models.Auction;
using AuctionVm = WebApplication1.Models.Auction.AuctionVm;


namespace WebApplication1.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            var users = _adminService.GetAllUsers();
            if (users == null) return BadRequest();
            List<UserVm> userVms = new List<UserVm>();
            foreach (var user in users)
            {
                userVms.Add(UserVm.FromUser(user));
            }
            
            return View(userVms);
        }

        public ActionResult Details(string userName)
        {
            List<Auction> auctions = _adminService.GetAllAuctionsByUserName(userName);
            List<AuctionVm> auctionVms = new List<AuctionVm>();
            foreach (var auction in auctions)
            {
                auctionVms.Add(AuctionVm.FromAuction(auction));
            }
            return View(auctionVms);
        }

        public async Task<ActionResult> DeleteUser(string userName)
        {
            await _adminService.RemoveUserByUserNameAsync(userName);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteAuction(int id)
        {
            _adminService.RemoveAuctionById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
