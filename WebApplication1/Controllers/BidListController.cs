using System.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Models.BidList;

namespace WebApplication1.Controllers
{
    public class BidListController : Controller
    {

        private IBidService _bidService;

        public BidListController(IBidService bidService)
        {
            _bidService = bidService;
        }
        public ActionResult Index()
        {
            List<BidList> bidLists = _bidService.GetAllByUserName("SeedUserName");
            List<BidListVm> bidListVms = new List<BidListVm>();
            foreach (var bidList in bidLists)
            {
                bidListVms.Add(BidListVm.FromBidList(bidList));
            }
            
            return View(bidListVms);
        }
        public ActionResult Details(int id)
        {
            try
            {
                BidList bidList = _bidService.GetById(id, "SeedUserName");
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
        
        
        
        
        
        

        // GET: BidListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BidListController/Create
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

        // GET: BidListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BidListController/Edit/5
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

        // GET: BidListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BidListController/Delete/5
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
