using AddressForm.MvcWeb.Extensions;
using AddressForm.MvcWeb.Models;
using AutoMapper;

namespace AddressForm.MvcWeb.Mapping
{
    /// <summary>
    /// If the selected country has regions, return the value from the regions DDL. Otherwise, return the
    /// value from the regions TextBox.
    /// </summary>
    public class PersonEditorModelToPersonRegionResolver : ValueResolver<PersonEditorModel, string>
    {
        protected override string ResolveCore(PersonEditorModel source)
        {
            if (source.Country.DoesCountryHaveRegions())
            {
                // U.S. and Canada are the only two that currently use a drop down list for state/province selection.
                return source.SelectedRegionDdl;
            }

            // All other countries use a free-form text box.
            return source.SelectedRegionTextBox;
        }
    }

    /// <summary>
    /// If the selected country has regions, return the Person.Region value for the DDL selection. Otherwise, return string.Empty.
    /// </summary>
    public class PersonToPersonEditorModelRegionDropDownListResolver : ValueResolver<Person, string>
    {
        protected override string ResolveCore(Person source)
        {
            // U.S. and Canada are the only two that currently use a drop down list for state/province selection. 
            //  All other countries use a free-form text box, so we don't want to prefill them with a regionId
            //  from the database.
            return source.Country.DoesCountryHaveRegions() 
                ? source.Region 
                : string.Empty;
        }
    }

    /// <summary>
    /// If the selected country doesn't have regions, return the Person.Region value for the TextBox. Otherwise, return string.Empty.
    /// </summary>
    public class PersonToPersonEditorModelRegionTextBoxResolver : ValueResolver<Person, string>
    {
        protected override string ResolveCore(Person source)
        {
            // U.S. and Canada are the only two that currently use a drop down list for state/province selection. 
            //  All other countries use a free-form text box, so we don't want to try to select value in the
            //  Regions ddl.
            return !source.Country.DoesCountryHaveRegions()
                ? source.Region
                : string.Empty;
        }
    }
}