using System.Data;
using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;

public class BidService : IBidService
{

    private readonly IBidPersistence _bidPersistence;

    public BidService(IBidPersistence bidPersistence)
    {
        _bidPersistence = bidPersistence;
    }
    
    
    public List<ListOfBids> GetAllBidsListByUserName(string userName)
    {
        List<ListOfBids> lob = _bidPersistence.GetAllListsByUserName(userName);
        return lob;
    }

    public ListOfBids GetListById(int id, string userName)
    {
        ListOfBids lob = _bidPersistence.GetListOfBidsById(id, userName);
        return lob;
    }

    public void Add(string userName, string title)
    {

        if (userName == null) throw new DataException("Username is missing");
        if (title == null || title.Length > 128) throw new DataException("Title issues");
        ListOfBids lob = new ListOfBids(title, userName);
        _bidPersistence.Save(lob);
    }
}