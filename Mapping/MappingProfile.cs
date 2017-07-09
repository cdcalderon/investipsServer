using AutoMapper;
using investips.Controllers.Resources;
using investips.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace investips.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Porfolio, SavePorfolioResource>()
            .ForMember(pr => pr.Securities, opt => opt.MapFrom(p => p.Securities
            .Select(s => s.SecurityId)));

            CreateMap<Porfolio, PorfolioResource>()
            .ForMember(pr => pr.Securities, opt => opt.MapFrom(p => p.Securities
            .Select(s => new SecurityResource {
                Id = s.SecurityId, Symbol = s.Security.Symbol})));

            CreateMap<SavePorfolioResource, Porfolio>()
            .ForMember(p => p.Id, opt => opt.Ignore())
            .ForMember(p => p.Securities, opt => opt.Ignore())
            .AfterMap((pr, p) => {

                // Remove unselected Securities
                var removedSecurities = p.Securities.Where(s => !pr.Securities.Contains(s.SecurityId));
                foreach (var s in removedSecurities) {
                    p.Securities.Remove(s);
                }

                // Add New Securities
                var newSecurities = pr.Securities.Where(id => !p.Securities
                .Any(s => s.SecurityId == id)).Select(id => new PorfolioSecurity{ SecurityId = id});
                foreach (var s in newSecurities) {
                    p.Securities.Add(s);
                }
            });



            // CreateMap<PorfolioResource, Porfolio>()
            // .ForMember(p => p.Id, opt => opt.Ignore())
            // .ForMember(p => p.Securities, opt => opt.MapFrom(pr => pr.Securities
            // .Select(id => new PorfolioSecurity{ SecurityId = id })));
        }
    }
}