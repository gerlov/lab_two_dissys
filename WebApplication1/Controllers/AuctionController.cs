using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Models.Auction;
using WebApplication1.Models.Bid;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {

        private IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService/*, IBidService bidService*/)
        {
            _auctionService = auctionService;
        }
        
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
                Auction auction = _auctionService.GetById(id);
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
                        createAuctionVm.description, User.Identity.Name, createAuctionVm.endDate);
                    return RedirectToAction("Index");

                }

                return View(createAuctionVm);
            }
            catch
            {
                return View(createAuctionVm);
            }
        }

        
        public ActionResult Bid(int id, double highestBid)
        {
            var createBidVm = new CreateBidVm
            {
                Id = id,
                highestBid = highestBid
            };

            return View(createBidVm);
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bid(int id, CreateBidVm createBidVm)
        {
            if(_auctionService.GetById(id).UserName == User.Identity.Name) return BadRequest();

            try
            {
                if (ModelState.IsValid)
                {
                    if (createBidVm.offer > createBidVm.highestBid)     
                    {
                        _auctionService.AddBid(createBidVm.offer, id, User.Identity.Name);
                        return RedirectToAction("Details", new { id = id });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your bid must be higher than the current highest bid.");
                    }
                }
                return View("Bid", createBidVm);
            }
            catch
            {
                return View(createBidVm);
            }
        }
        
        public ActionResult Edit(int id)
        {
            Auction auction = _auctionService.GetById(id);
            if (auction == null) return BadRequest();

            // EditDescriptionVm editVm = new EditDescriptionVm
            // {
            //     Id = auction.Id,
            //     description = auction.Description
            // };

            EditDescriptionVm editVm = EditDescriptionVm.FromAuction(auction);

            return View(editVm); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditDescriptionVm editDescriptionVm)
        {
            // Console.WriteLine("Edit:");
            // Console.WriteLine(editDescriptionVm.Id);
            if(_auctionService.GetById(editDescriptionVm.Id).UserName != User.Identity.Name) return BadRequest();

            ModelState.Remove("ItemName");  // Remove fields from being validated (since they're not sent in the form)
            ModelState.Remove("UserName");
            ModelState.Remove("StartPrice");
            ModelState.Remove("EndDate");
            try
            {
                if (ModelState.IsValid)
                {
                    _auctionService.UpdateAuction(editDescriptionVm.Id, User.Identity.Name, editDescriptionVm.Description);
                    return RedirectToAction("Details", new { id = editDescriptionVm.Id });
                }

                return View(editDescriptionVm); 
            }
            catch
            {
                return View(editDescriptionVm); 
            }
        }
        
        
        public ActionResult WonAuction(int id)
        {
            return RedirectToAction("Details", new { id = id });
        }
    }
}
