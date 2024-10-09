namespace AuctionApp.Core;

public class Auction
{
    public int id { get; set; }
    
    public string itemName { get; set; }
    
    public double price { get; set; }
    
    public string description { get; set; }
    
    public string sellerName { get; set; }
    
    public DateTime endDate { get; set; }
    
    //add list of bids

    public Auction(int id, string itemName, double price, string description, string sellerName, DateTime endDate)
    {
        this.id = id;
        this.itemName = itemName;
        this.price = price;
        this.description = description;
        this.sellerName = sellerName;
        this.endDate = endDate;
    }

    public Auction(string itemName, double price, string description, DateTime endDate)
    {
        this.itemName = itemName;
        this.price = price;
        this.description = description;
        this.sellerName = "Hardcodius Namus"; //TODO: replace with Identity
        this.endDate = endDate;

    }
}