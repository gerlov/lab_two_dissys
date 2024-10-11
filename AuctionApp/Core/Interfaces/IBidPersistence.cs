using AuctionApp.Persistence;

namespace AuctionApp.Core.Interfaces;

public interface IBidPersistence
{
    List<ListOfBids> GetAllListsByUserName(string userName);
    ListOfBids GetListOfBidsById(int id, string userName);
    void Save(ListOfBids listOfBids);
}