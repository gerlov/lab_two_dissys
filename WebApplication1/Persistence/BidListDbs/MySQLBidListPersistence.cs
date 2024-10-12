using System.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core;
using WebApplication1.Core.Interfaces;
using WebApplication1.Persistence.BidsDbs;

namespace WebApplication1.Persistence;

public class MySQLBidListPersistence : IBidPersistence
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public MySQLBidListPersistence(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    //Maybe wont fetch the bids here tbf, but we'll see
    public List<BidList> GetAllByUserName(string userName)
    {
        var bidListDbs = _dbContext.BidListDbs
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
        BidListDb bidListDb = _dbContext.BidListDbs.Where(p => p.Id == bidListId && p.UserName == userName)
            .Include(p => p.BidDbs).FirstOrDefault();
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
        var existingList = _dbContext.BidListDbs.FirstOrDefault(bl => bl.UserName == userName);

        if (existingList == null)
        {
            BidListDb newBidList = new BidListDb
            {
                Id = 1, 
                Title = "Pending Bids",
                UserName = userName
            };
            BidListDb newBidList2 = new BidListDb
            {
                Id = 2, // Set the ID to 1
                Title = "Winning Bids",
                UserName = userName
            };
            _dbContext.BidListDbs.Add(newBidList);
            _dbContext.BidListDbs.Add(newBidList2);
            _dbContext.SaveChanges();
        }
    }
}