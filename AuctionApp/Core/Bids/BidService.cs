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
}