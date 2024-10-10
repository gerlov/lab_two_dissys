namespace AuctionApp.Core.Interfaces
{
    public interface IBidService
    {
        List<ListOfBids> GetAllBidsList(string userName);
        ListOfBids GetListById(int id, string userName);
        
        
        List<Bid> GetAllBidsByUserName(string userName);
        List<Bid> GetWinningBidsByUserName(string userName);
        List<Bid> GetCurrentBidsByUserName(string userName);
        Bid GetBidById(int id, string userName);
        bool SetBidToWinner(int id);
        bool SetBidToLoser(int id);
        bool DeleteBid(int id);
    }
}