using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models.Auctions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    [Route("Auctions")]
    public class AuctionController : Controller
    {
        
        private IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }
        /*
        // GET: AuctionsController
        public ActionResult Index()
        {
            return View();
        }
        */
        // GET: AuctionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet("open")]
        public ActionResult GetAllOpenAuctions()
        {

            List<Auction> auctions = _auctionService.GetAllOpenAuctions();
            List<AuctionVm> auctionVms = new List<AuctionVm>();

            foreach (Auction auction in auctions) auctionVms.Add(AuctionVm.FromAuction(auction));
            
            return View("OpenAuctions", auctionVms);
        }
        
        [HttpGet("create")]
        public ActionResult CreateAuction()
        {
            return View("CreateAuction");
        }

        [HttpPost("create")]
        public ActionResult CreateAuction(CreateAuctionVm createAuctionVm)
        {
            try
            {
                if (ModelState.IsValid) _auctionService.Add(createAuctionVm.itemName, createAuctionVm.price, createAuctionVm.description, createAuctionVm.endDate);
                return RedirectToAction("GetAllOpenAuctions");
            }
            catch(Exception ex) //TODO: Make exceptions more specific and informative
            {
                return View(createAuctionVm);
            }
        }
/*
        // GET: AuctionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuctionsController/Create
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

        // GET: AuctionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionsController/Edit/5
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

        // GET: AuctionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionsController/Delete/5
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
