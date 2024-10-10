namespace AuctionApp.Core
{
    public class Bid
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuctionId { get; set; }
        private Status _status { get; set; }
        public DateTime BidDate { get; set; }
        public double Offer { get; set; }
        public string UserName { get; set; }

        public Bid(double offer, string userName, string name, int auctionId)
        {
            this.Id = _nextId++;
            this.UserName = userName;
            this.Offer = offer;
            this.Name = name;
            this.AuctionId = auctionId;
            this.BidDate = DateTime.Now;
            this._status = Status.PENDING;
        }

        public bool IsWinner()
        {
            return _status == Status.WINNER;
        }
        public bool IsPending()
        {
            return _status == Status.PENDING;
        }
        public bool IsLoser()
        {
            return _status == Status.LOSER;
        }

        public void SetWinner()
        {
            this.Status = Status.WINNER;
        }

        public void SetPending()
        {
            this.Status = Status.PENDING;
        }

        public void SetLoser()
        {
            this.Status = Status.LOSER;
        }

        public Status Status
        {
            get => _status;
            set
            {
                if (_status == Status.WINNER && value != Status.WINNER)
                    throw new InvalidOperationException("Cannot change status from WINNER to another status.");
                _status = value;
            }
        }
    }
}