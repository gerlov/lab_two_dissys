using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Persistence.BidsDbs;

namespace WebApplication1.Persistence.GenericRepos
{
    public class MySQLAuctionPersistence : IAuctionPersistence
    {
        private readonly IGenericRepo<AuctionDb> _auctionRepository;
        private readonly IGenericRepo<BidDb> _bidRepository;
        private readonly IGenericRepo<BidListDb> _bidListRepository;
        private readonly IMapper _mapper;

        public MySQLAuctionPersistence(
            IGenericRepo<AuctionDb> auctionRepository,
            IGenericRepo<BidDb> bidRepository,
            IGenericRepo<BidListDb> bidListRepository,
            IMapper mapper)
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
            _bidListRepository = bidListRepository;
            _mapper = mapper;
        }

        public List<Auction> GetAllAuctions()
        {
            var auctionDbs = _auctionRepository.GetAll()
                .Where(a => a.EndDate > DateTime.Now)
                .Include(a => a.BidDbs)
                .ToList();

            List<Auction> result = new List<Auction>();

            foreach (AuctionDb auctionDb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(auctionDb);
                result.Add(auction);
            }

            return result;
        }

        public Auction GetById(int auctionId)
        {
            /*
              AuctionDb auctionDb = _auctionRepository.GetById(auctionId);
             */

            AuctionDb auctionDb = _auctionRepository.GetAll()
                .Where(p => p.Id == auctionId)
                .Include(p => p.BidDbs)
                .FirstOrDefault();
            
            if (auctionDb == null) throw new DataException("Auction not found");

            Auction auction = _mapper.Map<Auction>(auctionDb);

            foreach (BidDb bidDb in auctionDb.BidDbs)
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                auction.AddBid(bid);
            }

            return auction;
        }

        public void UpdateAuction(int auctionId, string userName, string newDescription)
        {
            var auctionDb = _auctionRepository.GetAll()
                .FirstOrDefault(a => a.Id == auctionId && a.UserName == userName);

            if (auctionDb == null) throw new DataException("Auction not found or not owned by the current user.");

            auctionDb.Description = newDescription;

            _auctionRepository.Update(auctionDb);
            _auctionRepository.Save();
        }

        public void SaveAuction(Auction auction)
        {
            AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);
            _auctionRepository.Insert(auctionDb);
            _auctionRepository.Save();
        }

        public void AddBid(Bid bid)
        {
            var pendingBidList = _bidListRepository.GetAll()
                .FirstOrDefault(bl => bl.UserName == bid.UserName && bl.Title == "Pending Bids");

            if (pendingBidList != null)
            {
                BidDb bidDb = _mapper.Map<BidDb>(bid);
                bidDb.BidListId = pendingBidList.Id;
                _bidRepository.Insert(bidDb);
                _bidRepository.Save();
            }
            else
            {
                throw new InvalidOperationException("Pending Bids list not found for the user.");
            }
        }

        public void ProcessEndedAuctions()
        {
            var endedAuctions = _auctionRepository.GetAll()
                .Where(a => a.EndDate < DateTime.Now)
                .Include(a => a.BidDbs)
                .ToList();

            foreach (var auction in endedAuctions)
            {
                if (auction.BidDbs.Any())
                {
                    var highestBid = auction.BidDbs.OrderByDescending(b => b.Amount).FirstOrDefault();

                    if (highestBid != null)
                    {
                        var winningList = _bidListRepository.GetAll()
                            .FirstOrDefault(bl => bl.UserName == highestBid.UserName && bl.Title == "Winning Bids");

                        if (winningList == null)
                        {
                            winningList = new BidListDb
                            {
                                Title = "Winning Bids",
                                UserName = highestBid.UserName
                            };
                            _bidListRepository.Insert(winningList);
                            _bidListRepository.Save();
                        }

                        highestBid.BidListId = winningList.Id;
                        _bidRepository.Update(highestBid);

                        var losingBids = auction.BidDbs.Where(b => b.Id != highestBid.Id).ToList();
                        foreach (var bid in losingBids)
                        {
                            _bidRepository.Delete(bid);
                        }
                    }
                }
            }

            _bidRepository.Save();
            _auctionRepository.Save();
        }
    }
}
