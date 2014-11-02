using System.Web.Mvc;
using AddressForm.MvcWeb.Models;
using AutoMapper;

namespace AddressForm.MvcWeb.Mapping
{
    public class CountryRegionProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Country, SelectListItem>()
                .ForMember(sli => sli.Text, o => o.MapFrom(c => c.Name))
                .ForMember(sli => sli.Value, o => o.MapFrom(c => c.Id))
                .ForMember(sli => sli.Selected, o => o.Ignore())
                .ForMember(sli => sli.Disabled, o => o.Ignore())
                .ForMember(sli => sli.Group, o => o.Ignore());

            CreateMap<Region, SelectListItem>()
                .ForMember(sli => sli.Text, o => o.MapFrom(r => r.Name))
                .ForMember(sli => sli.Value, o => o.MapFrom(r => r.Abbreviation))
                .ForMember(sli => sli.Selected, o => o.Ignore())
                .ForMember(sli => sli.Disabled, o => o.Ignore())
                .ForMember(sli => sli.Group, o => o.Ignore());
        }
    }
}