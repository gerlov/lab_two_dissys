using System.Data;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models.Bids;
using AuctionApp.Views.Bid;
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
            var userName = "Shihab";
            List<ListOfBids> listOfBids = _bidService.GetAllBidsListByUserName(userName);
            List<ListOfBidsVm> listOfBidsVm = new List<ListOfBidsVm>();
            
            foreach (var list in listOfBids)
            {
                listOfBidsVm.Add(ListOfBidsVm.FromProject(list));
            }
            return View(listOfBidsVm);
        }

        public ActionResult Details(int id)
        {
            var userName = "Shihab";

            try
            {
                ListOfBids lob = _bidService.GetListById(id, userName);
                if (lob == null) return BadRequest();
                ListDetailsVm detailsVm = ListDetailsVm.FromList(lob);
                return View(detailsVm);
            }
            catch (DataException e)
            {
                return BadRequest();
            }
        }
        
        //Get?
        public ActionResult Create()
        {
            
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBidListVm createBidListVm)
        {
            try
            {
                string Title1 = "Pending Bids";
                string Title2 = "Winning Bids";
                string userName = "Shihab";

                _bidService.Add(userName, Title1);
                _bidService.Add(userName, Title2);

                return RedirectToAction("Index");

            }
            catch (DataException e)
            {
                Console.WriteLine(e);
                return View(createBidListVm);
            }
        }

    }
}