    using System.ComponentModel.DataAnnotations;

    namespace AuctionApp.Persistence;

    public class ListOfBidsDB
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        
        [Required]
        public string UserName { get; set; }

        public List<BidDB> BidDBs { get; set; } = new List<BidDB>();
    }