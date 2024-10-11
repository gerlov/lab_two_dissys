using Microsoft.AspNetCore.Mvc;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Models.Auction;

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
            Auction auction = _auctionService.GetById(id, "Shihab");
            if (auction == null) return BadRequest();

            AuctionDetailsVm detailsVm = AuctionDetailsVm.FromAuction(auction);
            return View(detailsVm);
        }

        
        
        
        
        
        
        
        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionController/Create
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
