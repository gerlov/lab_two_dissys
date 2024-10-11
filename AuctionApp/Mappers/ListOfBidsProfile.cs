using AuctionApp.Core;
using AuctionApp.Persistence;
using AutoMapper;

namespace AuctionApp.Mappers;

public class ListOfBidsProfile : Profile
{
    public ListOfBidsProfile()
    {
        CreateMap<ListOfBidsDB, ListOfBids>().ReverseMap();
    }
    
}