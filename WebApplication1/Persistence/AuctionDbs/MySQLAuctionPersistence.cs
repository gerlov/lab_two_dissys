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
            .Include(a => a.BidDbs)
            .ToList();

        List<Auction> result = new List<Auction>();

        foreach (AuctionDb auctionDb in auctionDbs)
        {
            Auction auction = _mapper.Map<Auction>(auctionDb);

            foreach (BidDb bidDb in auctionDb.BidDbs)
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                auction.AddBid(bid);
            }

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

    public void SaveAuction(Auction auction)
    {
        AuctionDb auctionDb = _mapper.Map<AuctionDb>(auction);
        _dbContext.AuctionDbs.Add(auctionDb);
        _dbContext.SaveChanges();
    }

    public void AddBid(Bid bid)
    {
        BidDb bidDb = _mapper.Map<BidDb>(bid);
        //User should only be able to have 2 lists, with id 1 for Pending and 2 for Won bids, so here it would be set to 1
        bidDb.BidListId = -1;
        _dbContext.BidDbs.Add(bidDb);
        _dbContext.SaveChanges();
    }
}