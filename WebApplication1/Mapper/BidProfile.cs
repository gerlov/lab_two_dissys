using AutoMapper;
using WebApplication1.Core;
using WebApplication1.Persistence.Entities;

namespace WebApplication1.Mapper;

public class BidProfile : Profile
{
    public BidProfile()
    {
        CreateMap<BidDb, Bid>().ReverseMap();
    }
}