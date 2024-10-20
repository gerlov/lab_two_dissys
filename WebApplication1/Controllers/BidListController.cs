using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Core.Services;
using WebApplication1.Models.BidList;

namespace WebApplication1.Controllers
{
    
    [Authorize]
    public class BidListController : Controller
    {

        private IBidService _bidService;
        private IAuctionService _auctionService;

        public BidListController(IBidService bidService, IAuctionService auctionService)
        {
            _bidService = bidService;
            _auctionService = auctionService;
        }
        public ActionResult Index()
        {
            
            
            // Check which pending bids for user are on closed auctions, and process them accordingly 
            IEnumerable<Bid> pendingBids = _bidService.GetAllByUserName(User.Identity.Name).First(bl => bl.Title == "Pending Bids").Bids;
            HashSet<int> auctionIds = new HashSet<int>();
            foreach (var bid in pendingBids) auctionIds.Add(bid.AuctionId);
            
            _auctionService.ProcessEndedAuctions(auctionIds);
            List<BidList> bidLists = _bidService.GetAllByUserName(User.Identity.Name);

            List<BidListVm> bidListVms = new List<BidListVm>();
            foreach (var bidList in bidLists)   bidListVms.Add(BidListVm.FromBidList(bidList));
            
            return View(bidListVms);
        }
        public ActionResult Details(int id)
        {
            try
            {
                BidList bidList = _bidService.GetById(id, User.Identity.Name);
                if (bidList == null)
                {
                    return BadRequest();
                }

                BidListDetailsVm detailsVm = BidListDetailsVm.FromBidList(bidList);
                return View(detailsVm);
            }
            catch (DataException e)
            {
                return BadRequest();
            }
            
        }
        
    }
}
