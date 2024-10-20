namespace WebApplication1.Core.Interfaces;

public interface IBidPersistence
{
    List<BidList> GetAllByUserName(string userName);
    BidList GetById(int bidListId, string userName);
    void AddList(string userName);
    void RemoveBidList(int bidListId);
}