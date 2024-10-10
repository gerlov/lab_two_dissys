namespace AuctionApp.Core.Interfaces
{
    public interface IBidService
    {
        List<ListOfBids> GetAllBidsListByUserName(string userName);
        ListOfBids GetListById(int id, string userName);
        
    }
}