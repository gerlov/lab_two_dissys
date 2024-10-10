using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models.Auctions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    [Authorize]
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

        [HttpGet("Open")]
        public ActionResult GetAllOpenAuctions()
        {

            List<Auction> auctions = _auctionService.GetAllOpenAuctions();
            List<AuctionVm> auctionVms = new List<AuctionVm>();

            foreach (Auction auction in auctions) auctionVms.Add(AuctionVm.FromAuction(auction));
            
            return View("OpenAuctions", auctionVms);
        }
        
        [HttpGet("Create")]
        public ActionResult CreateAuction()
        {
            return View("CreateAuction");
        }

        [HttpPost("Create")]
        public ActionResult CreateAuction(CreateAuctionVm createAuctionVm)
        {
            try
            {
                if (ModelState.IsValid) {
                    _auctionService.Add(createAuctionVm.itemName, 
                                        createAuctionVm.price, 
                                        createAuctionVm.description, 
                                        User.Identity.Name,
                                        createAuctionVm.endDate);
                    
                }
                return RedirectToAction("GetAllOpenAuctions");
            }
            catch(Exception ex) //TODO: Make exceptions more specific and informative
            {
                return View(createAuctionVm);
            }
        }

        [HttpGet("MyAuctions")]
        public ActionResult GetAllUserAuctions()
        {
            List<Auction> userAuctions = _auctionService.GetByUserName(User.Identity.Name);
            
            List<AuctionVm> auctionVms = new List<AuctionVm>();
            foreach (Auction auction in userAuctions) auctionVms.Add(AuctionVm.FromAuction(auction));
            
            return View("UserAuctions", auctionVms);
            
        }
        
        [HttpGet("MyAuctions/Edit/{id}")]
        public ActionResult EditAuction(int id)
        {
            Auction userAuction = _auctionService.GetById(id);
            
            if(userAuction == null) return NotFound();
            if(userAuction.sellerName != User.Identity.Name) return BadRequest();
            
            return View("EditAuction", CreateAuctionVm.FromAuction(userAuction));
        }
        
        [HttpPost("MyAuctions/Edit/{id}")]
        public ActionResult EditAuction(int id, CreateAuctionVm createAuctionVm)
        {
            try
            {
                    //Console.WriteLine(id);
                    _auctionService.Update(id, createAuctionVm.description);

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
