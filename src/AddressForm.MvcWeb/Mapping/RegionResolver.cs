using AddressForm.MvcWeb.Models;
using AutoMapper;

namespace AddressForm.MvcWeb.Mapping
{
    public class RegionResolver : ValueResolver<PersonEditorModel, string>
    {
        protected override string ResolveCore(PersonEditorModel source)
        {
            if (source.Country == "US" || source.Country == "CA")
            {
                // U.S. and Canada are the only two that currently use a drop down list for state/province selection.
                return source.RegionDropDownList;
            }

            // All other countries use a free-form text box.
            return source.RegionTextBox;
        }
    }
}