using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models.Bids;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class BidController : Controller
    {

        private IBidService _bidService;

        public BidController(IBidService bidService)
        {
            this._bidService = bidService;
        }
        // GET: BidController
        public ActionResult Index()
        {

            List<Bid> bids = _bidService.GetAllBidsByUserName("MockName");
            List<BidVm> bidVms = new List<BidVm>();
            foreach (var bid in bids) 
            {
                bidVms.Add(BidVm.FromBid(bid));
            }
            return View(bidVms);
        }

        // GET: BidController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /*
        // GET: BidController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BidController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BidController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BidController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BidController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BidController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
