using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        [Display(Name = "State/Province")]
        public string RegionTextBox { get; set; }

        [StringLength(50)]
        [Display(Name = "State/Province")]
        public string RegionDropDownList { get; set; }

        [StringLength(30)]
        [Display(Name = "Zip/Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
        public string Country { get; set; }

        public List<SelectListItem> Countries { get; private set; }
        public List<SelectListItem> Regions { get; private set; }

        public List<SelectListItem> States { get; private set; }
        public List<SelectListItem> Provinces { get; private set; }

        public PersonEditorModel()
        {
            Countries = new List<SelectListItem>();
            Regions = new List<SelectListItem>();

            States = new List<SelectListItem>();
            Provinces = new List<SelectListItem>();
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