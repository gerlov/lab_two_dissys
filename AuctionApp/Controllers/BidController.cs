using System.Data;
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
            var userName = "Jo4r";

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

    }
}