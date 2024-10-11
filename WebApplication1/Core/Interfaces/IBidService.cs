namespace WebApplication1.Core.Interfaces;

public interface IBidService
{
    List<BidList> GetAllByUserName(string userName);
    BidList GetById(int bidListId, string userName);
    void AddList(string userName);
}