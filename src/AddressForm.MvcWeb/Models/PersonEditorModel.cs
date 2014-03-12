﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using AddressForm.MvcWeb.Validation;
using Newtonsoft.Json;

namespace AddressForm.MvcWeb.Models
{
    public class PersonEditorModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [StringLength(100)]
        [Display(Name = "Extended Address")]
        public string ExtendedAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string Locality { get; set; }

        [StringLength(50)]
        [Display(Name = "State/Province/Region")]
        public string RegionTextBox { get; set; }

        [StringLength(50)]
        [Display(Name = "State/Province/Region")]
        public string RegionDropDownList { get; set; }

        /// <summary>
        /// DisplayName is set at runtime, and is determined by the selected Country. Also, as Country changes,
        /// JavaScript updates the display name on the page accordingly.
        /// </summary>
        [PostalCodeRequired("Country")]
        [StringLength(30)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
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
            const string errorMessage = "State/Province is required";

            // If U.S. or Canada, RegionDropDownList is required. Otherwise, RegionTextBox is required.
            if ((Country == "US" || Country == "CA"))
            {
                if (string.IsNullOrWhiteSpace(RegionDropDownList))
                {
                    yield return new ValidationResult(errorMessage, new[] { "RegionDropDownList" });
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(RegionTextBox))
                {
                    yield return new ValidationResult(errorMessage, new[] { "RegionTextBox" });
                }
            }
        }
    }
}