using AutoMapper;
using WebApplication1.Core;
using WebApplication1.Persistence;

namespace WebApplication1.Mapper;

public class BidListProfile : Profile
{
    public BidListProfile()
    {
        CreateMap<BidListDb, BidList>().ReverseMap();
    }
}