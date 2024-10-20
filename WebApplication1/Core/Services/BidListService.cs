using WebApplication1.Core.Interfaces;

namespace WebApplication1.Core.Services;

public class BidListService : IBidService
{

    private readonly IBidPersistence _bidPersistence;

    public BidListService(IBidPersistence bidPersistence)
    {
        _bidPersistence = bidPersistence;
    }
    public List<BidList> GetAllByUserName(string userName)
    {
        List<BidList> bidLists = _bidPersistence.GetAllByUserName(userName);
        return bidLists;
    }

    public BidList GetById(int bidListId, string userName)
    {
        BidList bidList = _bidPersistence.GetById(bidListId, userName);
        return bidList;
    }

    public void AddList(string userName)
    {
        _bidPersistence.AddList(userName);
    }
}