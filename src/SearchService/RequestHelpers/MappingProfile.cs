using AutoMapper;
using Contracts;
using SearchService.Model;

namespace SearchService.RequestHelpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AuctionCreated, Item>();
        }
    }
}
