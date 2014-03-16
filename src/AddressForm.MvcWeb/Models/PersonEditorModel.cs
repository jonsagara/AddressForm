using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using AddressForm.MvcWeb.Resources;
using AddressForm.MvcWeb.Validation;
using Newtonsoft.Json;

namespace AddressForm.MvcWeb.Models
{
    public class PersonEditorModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(AddressFormResources), Name = "NameLabel")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(ResourceType = typeof(AddressFormResources), Name = "StreetAddressLabel")]
        public string StreetAddress { get; set; }

        [StringLength(100)]
        [Display(ResourceType = typeof(AddressFormResources), Name = "ExtendedAddressLabel")]
        public string ExtendedAddress { get; set; }

        /// <summary>
        /// Display name is set at runtime, and is determined by the selected Country.
        /// </summary>
        [LocalityRequired("Country")]
        [StringLength(50)]
        public string Locality { get; set; }

        /// <summary>
        /// The Region text box is only shown for countries that don't support picking a region from a DDL, so
        /// the label never changes.
        /// </summary>
        [StringLength(50)]
        [Display(ResourceType = typeof(AddressFormResources), Name = "RegionLabelOther")]
        public string RegionTextBox { get; set; }

        /// <summary>
        /// Display name is set at runtime, and is determined by the selected Country. Also, as Country changes,
        /// JavaScript updates the display name on the page accordingly. Note that the DDL is only visible for 
        /// countries that support picking a region from a DDL.
        /// </summary>
        [StringLength(50)]
        public string RegionDropDownList { get; set; }

        /// <summary>
        /// Display name is set at runtime, and is determined by the selected Country. Also, as Country changes,
        /// JavaScript updates the display name on the page accordingly.
        /// </summary>
        [PostalCodeRequired("Country")]
        [StringLength(30)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
        [Display(ResourceType = typeof(AddressFormResources), Name = "CountryLabel")]
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; private set; }

        /// <summary>
        /// Dictionary of Lists of Regions by Country.
        /// Key: Two-character country code.
        /// Value: List&lt;SelectListItem&gt; containing states/provinces populated from the Regions table.
        /// </summary>
        public Dictionary<string, List<SelectListItem>> RegionsByCountry { get; set; }

        public string RegionsByCountryJson
        {
            get
            {
                if (RegionsByCountry == null)
                {
                    throw new InvalidOperationException("You must populate RegionsByCountry before calling RegionsByCountryJson");
                }

                // Trying to be good JavaScript citizens by camel casing our JSON. Can't use the built-in
                //  camel case contract resolver because it also lower cases the dictionary keys.
                return JsonConvert.SerializeObject(
                    RegionsByCountry.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Select(sli => new { text = sli.Text, value = sli.Value, selected = sli.Selected }))
                );
            }
        }


        #region Form Configuration

        private bool IsNew { get { return Id == Guid.Empty; } }

        public string ActionName
        {
            get { return IsNew ? "New" : "Edit"; }
        }

        public string SubmitButtonLabel
        {
            get { return IsNew ? AddressFormResources.SubmitButtonLabelNew : AddressFormResources.SubmitButtonLabelEdit; }
        }


        private bool IsUS { get { return Country == "US"; } }
        private bool IsCA { get { return Country == "CA"; } }
        public bool IsUSorCA { get { return IsUS || IsCA; } }

        /// <summary>
        /// Label for the Region DDL when it is visible. If US, then State; if CA, then Province; else empty string.
        /// Note that the Region DDL is hidden when the country doesn't support picking regions from a DDL.
        /// </summary>
        public string RegionDdlLabel
        {
            get
            {
                if (IsUS)
                {
                    return AddressFormResources.RegionLabelUS;
                }

                if (IsCA)
                {
                    return AddressFormResources.RegionLabelCA;
                }

                // Selected country does not support picking a region from a DDL. We still need to default the region 
                //  DDL lagel to the US's label. We can't make it null or empty, or else LabelFor will not render the 
                //  label tag. Then, if the user happens to change their country to US, the region DDL will render 
                //  where the region DDL label should have been (all the way to the left).
                // JavaScript will update the region DDL label to have the approriate text when the user chooses 
                //  either US or Canada as a country.
                return AddressFormResources.RegionLabelUS;
            }
        }

        public string LocalityLabel
        {
            get
            {
                if (IsUS)
                {
                    return AddressFormResources.LocalityLabelUS;
                }

                if (IsCA)
                {
                    return AddressFormResources.LocalityLabelCA;
                }

                return AddressFormResources.LocalityLabelOther;
            }
        }

        public string PostalCodeLabel
        {
            get
            {
                if (IsUS)
                {
                    return AddressFormResources.PostalCodeLabelUS;
                }

                if (IsCA)
                {
                    return AddressFormResources.PostalCodeLabelCA;
                }

                return AddressFormResources.PostalCodeLabelOther;
            }
        }

        #endregion


        public PersonEditorModel()
        {
            Countries = new List<SelectListItem>();
        }

        /// <summary>
        /// Ensure that the user has specified a State/Province from either the Region drop down list or the 
        /// text box, depending on the selected Country.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var regionErrorMessage = IsUS ? AddressFormResources.RegionRequiredErrorMessageUS : AddressFormResources.RegionRequiredErrorMessageCA;
            var postalCodeErrorMessage = IsUS ? AddressFormResources.PostalCodeRequiredErrorMessageUS : AddressFormResources.PostalCodeRequiredErrorMessageCA;

            // If U.S. or Canada, RegionDropDownList and PostalCode are required.
            if ((Country == "US" || Country == "CA"))
            {
                if (string.IsNullOrWhiteSpace(RegionDropDownList))
                {
                    yield return new ValidationResult(regionErrorMessage, new[] { "RegionDropDownList" });
                }

                if (string.IsNullOrWhiteSpace(PostalCode))
                {
                    yield return new ValidationResult(postalCodeErrorMessage, new[] { "PostalCode" });
                }
            }
        }
    }
}