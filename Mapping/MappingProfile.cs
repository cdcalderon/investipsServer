using AutoMapper;
using investips.Controllers.Resources;
using investips.Models;

namespace investips.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Porfolio, PorfolioResource>();
            CreateMap<Security, SecurityResource>();
        }
    }
}