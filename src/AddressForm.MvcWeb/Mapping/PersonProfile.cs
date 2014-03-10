using AddressForm.MvcWeb.Models;
using AutoMapper;

namespace AddressForm.MvcWeb.Mapping
{
    public class PersonProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Person, PersonEditorModel>()
                .ForMember(pem => pem.RegionDropDownList, o => o.ResolveUsing<PersonToPersonEditorModelRegionDropDownListResolver>())
                .ForMember(pem => pem.RegionTextBox, o => o.ResolveUsing<PersonToPersonEditorModelRegionTextBoxResolver>())
                .ForMember(pem => pem.Countries, o => o.Ignore())
                .ForMember(pem => pem.RegionsByCountry, o => o.Ignore())
                .ForMember(pem => pem.RegionsByCountryJson, o => o.Ignore());

            CreateMap<PersonEditorModel, Person>()
                .ForMember(p => p.Region, o => o.ResolveUsing<PersonEditorModelToPersonRegionResolver>());

            CreateMap<Person, PeopleDeleteModel>();
        }
    }
}