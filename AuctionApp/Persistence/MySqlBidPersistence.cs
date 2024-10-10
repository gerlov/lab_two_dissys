using System.Data;
using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence;


public class MySqlBidPersistence : IBidPersistence
{

    private readonly ListOfBidsDBContext _listOfBidsDbContext;
    private readonly IMapper _mapper;

    public MySqlBidPersistence(ListOfBidsDBContext _listOfBidsDbContext, IMapper _mapper)
    {
        this._listOfBidsDbContext = _listOfBidsDbContext;
        this._mapper = _mapper;
    }
    
    
    public List<ListOfBids> GetAllListsByUserName(string userName)
    {
        var listDbs = _listOfBidsDbContext.ListOfBidsDbs.Where(l => l.UserName == userName).ToList();
        List<ListOfBids> result = new List<ListOfBids>();
        foreach (ListOfBidsDB listOfBidsDb in listDbs)
        {
            ListOfBids listOfBids = _mapper.Map<ListOfBids>(listOfBidsDb);
            result.Add(listOfBids);
        }

        return result;
    }

    public ListOfBids GetListOfBidsById(int id, string userName)
    {
        ListOfBidsDB lob = _listOfBidsDbContext.ListOfBidsDbs.Where(l => l.Id == id && l.UserName.Equals(userName))
            .Include(l => l.BidDBs).FirstOrDefault();

        if (lob == null) throw new DataException("ListOfBids not found");

        ListOfBids listOfBids = _mapper.Map<ListOfBids>(lob);
        foreach (BidDB bidDb in lob.BidDBs)
        {
            Bid bid = _mapper.Map<Bid>(bidDb);
            listOfBids.AddBid(bid);
        }

        return listOfBids;
    }

    public void Save(ListOfBids listOfBids)
    {
        ListOfBidsDB lobdb = _mapper.Map<ListOfBidsDB>(listOfBids);
        _listOfBidsDbContext.ListOfBidsDbs.Add(lobdb);
        _listOfBidsDbContext.SaveChanges();
    }
}