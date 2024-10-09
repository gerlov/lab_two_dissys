using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AutoMapper;

namespace AuctionApp.Persistence;

public class MySqlAuctionPersistence : IAuctionPersistence
{
    private readonly AuctionDbContext _dbContext;
    private readonly IMapper _mapper;

    public MySqlAuctionPersistence(AuctionDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<Auction> GetAllAuctions()
    {
        List<AuctionDb> auctionDbs = _dbContext.AuctionDbs.ToList();
        
        List<Auction> result = new List<Auction>();
        foreach (AuctionDb auctionDb in auctionDbs) result.Add(_mapper.Map<Auction>(auctionDb));

        return result;
    }

    public void Save(Auction auction)
    {
        _dbContext.AuctionDbs.Add(_mapper.Map<AuctionDb>(auction));
        _dbContext.SaveChanges();
    }
}