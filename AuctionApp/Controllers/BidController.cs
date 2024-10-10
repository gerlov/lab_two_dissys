using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models.Bids;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class BidController : Controller
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            this._bidService = bidService;
        }
        
        public ActionResult Index()
        {
            var userName = "Jo4r";
            List<ListOfBids> listOfBids = _bidService.GetAllBidsList(userName);
            List<ListOfBidsVm> listOfBidsVm = new List<ListOfBidsVm>();
            
            foreach (var list in listOfBids)
            {
                listOfBidsVm.Add(ListOfBidsVm.FromProject(list));
            }
            return View(listOfBidsVm);
        }

        public ActionResult Details(int id)
        {
            var userName = "Jo4r";
            ListOfBids listOfBids = _bidService.GetListById(id, userName);
            if (listOfBids == null) return BadRequest();

            ListDetailsVm detailsVm = ListDetailsVm.FromList(listOfBids);
            return View(detailsVm);
        }
        
        public ActionResult SetBidToWinner(int id)
        {
            bool success = _bidService.SetBidToWinner(id);
            if (!success)
                return NotFound();

            return RedirectToAction("Index");
        }
        
        public ActionResult SetBidToLoser(int id)
        {
            bool success = _bidService.SetBidToLoser(id);
            if (!success)
                return NotFound();

            return RedirectToAction("Index");
        }

    }
}