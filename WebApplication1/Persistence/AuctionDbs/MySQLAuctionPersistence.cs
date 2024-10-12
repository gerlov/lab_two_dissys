using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Persistence.BidsDbs;

namespace WebApplication1.Persistence;

public class MySQLAuctionPersistence : IAuctionPersistence
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public MySQLAuctionPersistence(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<Auction> GetAllAuctions()
    {
        var auctionDbs = _dbContext.AuctionDbs
            .Where(a => a.EndDate > DateTime.Now)
            .Include(a => a.BidDbs)
            .ToList();
        

        List<Auction> result = new List<Auction>();

        foreach (AuctionDb auctionDb in auctionDbs)
        {
            Auction auction = _mapper.Map<Auction>(auctionDb);

           /* foreach (BidDb bidDb in auctionDb.BidDbs)
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                auction.AddBid(bid);
            }
            */
            result.Add(auction);
        }

        return result;
    }

    public Auction GetById(int auctionId, string userName)
    {
        AuctionDb auctionDb = _dbContext.AuctionDbs.Where(p => p.Id == auctionId).Include(p => p.BidDbs)
            .FirstOrDefault();
        if (auctionDb == null) throw new DataException("auction not found");
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
        var auctionDb = _dbContext.AuctionDbs.FirstOrDefault(a => a.Id == auctionId && a.UserName == userName);
    
        if (auctionDb == null) throw new DataException("Auction not found or not owned by the current user.");

        auctionDb.Description = newDescription;

        _dbContext.SaveChanges();
    }

    public void SaveAuction(Auction auction)
    {
        AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);
        _dbContext.AuctionDbs.Add(auctionDb);
        _dbContext.SaveChanges();
    }

    public void AddBid(Bid bid)
    {
        BidDb bidDb = _mapper.Map<BidDb>(bid);
        bidDb.BidListId = 1; // 1 for pending, 2 for won
        _dbContext.BidDbs.Add(bidDb);
        _dbContext.SaveChanges();
    }
    
    public void ProcessEndedAuctions()
    {
        var endedAuctions = _dbContext.AuctionDbs
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
                    var winningList = _dbContext.BidListDbs
                        .FirstOrDefault(bl => bl.UserName == highestBid.UserName && bl.Title == "Winning Bids");

                    if (winningList == null)
                    {
                        winningList = new BidListDb
                        {
                            Title = "Winning Bids",
                            UserName = highestBid.UserName
                        };
                        _dbContext.BidListDbs.Add(winningList);
                        _dbContext.SaveChanges(); 
                    }

                    highestBid.BidListId = winningList.Id;
                    _dbContext.BidDbs.Update(highestBid);

                    var losingBids = auction.BidDbs.Where(b => b.Id != highestBid.Id).ToList();
                    _dbContext.BidDbs.RemoveRange(losingBids);
                }
            }
        }

        _dbContext.SaveChanges();
    }


}