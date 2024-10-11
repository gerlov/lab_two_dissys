using System.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Models.Auction;
using WebApplication1.Models.Bid;

namespace WebApplication1.Controllers
{
    public class AuctionController : Controller
    {

        private IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        
        // GET: AuctionController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAllAuctions();
            List<AuctionVm> auctionVms = new List<AuctionVm>();
            foreach (var auction in auctions)
            {
                auctionVms.Add(AuctionVm.FromAuction(auction));
            }
            return View(auctionVms);
        }
        public ActionResult Details(int id)
        {
            try
            {
                Auction auction = _auctionService.GetById(id, "SeedUserNameForAuction");
                if (auction == null) return BadRequest();
                AuctionDetailsVm detailsVm = AuctionDetailsVm.FromAuction(auction);
                return View(detailsVm);
            }
            catch (DataException e)
            {
                return BadRequest();
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVm createAuctionVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _auctionService.AddAuction(createAuctionVm.itemName, createAuctionVm.price,
                        createAuctionVm.description, "SeedUserName", createAuctionVm.endDate);
                    return RedirectToAction("Index");

                }

                return View(createAuctionVm);
            }
            catch
            {
                return View(createAuctionVm);
            }
        }

        
        // GET: AuctionController/Edit/5
        public ActionResult Bid(int id, string userName)
        {
            return View();
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(int id, double highestBid, CreateBidVm createBidVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (highestBid < createBidVm.offer)
                    {
                        _auctionService.AddBid(createBidVm.offer, id, "SeedUserName");
                        return RedirectToAction("Index");
                    }
                }
                return View(createBidVm);
            }
            catch
            {
                return View(createBidVm);
            }
        }
    
        
        
        
        
        
        
        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionController/Edit/5
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

        // GET: AuctionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionController/Delete/5
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
    }
}
