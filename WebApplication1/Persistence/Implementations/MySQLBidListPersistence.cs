using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Persistence.Entities;
using WebApplication1.Persistence.Repositories;

namespace WebApplication1.Persistence.Implementations
{
    public class MySQLBidListPersistence : IBidPersistence
    {
        private readonly IGenericRepo<BidListDb> _bidListRepository;
        private readonly IMapper _mapper;

        public MySQLBidListPersistence(
            IGenericRepo<BidListDb> bidListRepository,
            IGenericRepo<BidDb> bidRepository,
            IMapper mapper)
        {
            _bidListRepository = bidListRepository;
            _mapper = mapper;
        }

        public List<BidList> GetAllByUserName(string userName)
        {
            var bidListDbs = _bidListRepository.GetAll()
                .Where(bl => bl.UserName == userName)
                .Include(bl => bl.BidDbs)
                .ToList();

            List<BidList> result = new List<BidList>();

            foreach (BidListDb bidListDb in bidListDbs)
            {
                BidList bidList = _mapper.Map<BidList>(bidListDb);

                foreach (BidDb bidDb in bidListDb.BidDbs)
                {
                    Bid bid = _mapper.Map<Bid>(bidDb);
                    bidList.AddBid(bid);
                }

                result.Add(bidList);
            }

            return result;
        }

        public BidList GetById(int bidListId, string userName)
        {
            BidListDb bidListDb = _bidListRepository.GetAll()
                .Where(p => p.Id == bidListId && p.UserName == userName)
                .Include(p => p.BidDbs)
                .FirstOrDefault();

            if (bidListDb == null) throw new DataException("BidList not found");

            BidList bidList = _mapper.Map<BidList>(bidListDb);

            foreach (BidDb bidDb in bidListDb.BidDbs)
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                bidList.AddBid(bid);
            }

            return bidList;
        }

        public void AddList(string userName)
        {
            var pendingList = _bidListRepository.GetAll()
                .FirstOrDefault(bl => bl.UserName == userName && bl.Title == "Pending Bids");
            var winningList = _bidListRepository.GetAll()
                .FirstOrDefault(bl => bl.UserName == userName && bl.Title == "Winning Bids");

            if (pendingList == null)
            {
                BidListDb newPendingList = new BidListDb
                {
                    Title = "Pending Bids",
                    UserName = userName
                };
                _bidListRepository.Insert(newPendingList);
            }

            if (winningList == null)
            {
                BidListDb newWinningList = new BidListDb
                {
                    Title = "Winning Bids",
                    UserName = userName
                };
                _bidListRepository.Insert(newWinningList);
            }

            _bidListRepository.Save();
        }

        public void RemoveBidList(int bidListId)
        {
            var bidList = _bidListRepository.GetById(bidListId);

            if (bidList != null)
            {
                _bidListRepository.Delete(bidList);
                _bidListRepository.Save();
            }
        }
    }
}
