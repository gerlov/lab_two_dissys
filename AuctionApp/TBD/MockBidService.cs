using AuctionApp.Core.Interfaces;
using System.Linq;

namespace AuctionApp.Core
{
    public class MockBidService : IBidService
    {
        private static readonly List<Bid> _bids = new(); 
        private static readonly List<ListOfBids> _bidList = new();

        static MockBidService()
        {
            ListOfBids WinningBids = new ListOfBids("Won bids", "Jo4r") { Id = 1};
            ListOfBids PendingBids = new ListOfBids("Pending bids", "Jo4r") {Id = 2};
            Bid bid1 = new Bid(100, "Jo4r", "Vase", 1);
            Bid bid2 = new Bid(9.2, "Jo4r", "Cat", 2);
            Bid bid3 = new Bid(111, "Jo4r", "Vase", 1);
            bid1.SetWinner();
            _bids.Add(bid1);
            _bids.Add(bid2);
            _bids.Add(bid3);
            WinningBids.AddBid(bid1);
            PendingBids.AddBid(bid2);
            PendingBids.AddBid(bid3);
            _bidList.Add(WinningBids);
            _bidList.Add(PendingBids);
        }

        public List<ListOfBids> GetAllBidsListByUserName(string userName)
        {
            return _bidList;
        }

        public ListOfBids GetListById(int id, string userName)
        {
            return _bidList.Find(list => list.Id == id && list.UserName == userName);
            
        }

        public List<Bid> GetAllBidsByUserName(string userName)
        {
            return _bids.Where(b => b.UserName == userName).ToList();
        }

        public List<Bid> GetWinningBidsByUserName(string userName)
        {
            return _bids.Where(b => b.UserName == userName && b.Status == Status.WINNER).ToList();
        }

        public List<Bid> GetCurrentBidsByUserName(string userName)
        {
            return _bids.Where(b => b.UserName == userName && b.Status == Status.PENDING).ToList();
        }

        public Bid GetBidById(int id, string userName)
        {
            return _bids.FirstOrDefault(b => b.Id == id && b.UserName == userName);
        }

        public bool SetBidToWinner(int id)
        {
            var bid = _bids.FirstOrDefault(b => b.Id == id);
            if (bid != null)
            {
                bid.SetWinner();
                return true;
            }
            return false;
        }

        public bool SetBidToLoser(int id)
        {
            var bid = _bids.FirstOrDefault(b => b.Id == id);
            if (bid != null)
            {
                bid.SetLoser();
                return true;
            }
            return false;
        }

        public bool DeleteBid(int id)
        {
            var bid = _bids.FirstOrDefault(b => b.Id == id);
            if (bid != null)
            {
                _bids.Remove(bid);
                return true;
            }
            return false;
        }
    }
}