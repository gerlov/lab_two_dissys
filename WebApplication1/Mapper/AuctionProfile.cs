using AutoMapper;
using WebApplication1.Core;
using WebApplication1.Persistence;

namespace WebApplication1.Mapper;

public class AuctionProfile : Profile
{
    public AuctionProfile()
    {
        CreateMap<AuctionDb, Auction>().ReverseMap();
    }
}