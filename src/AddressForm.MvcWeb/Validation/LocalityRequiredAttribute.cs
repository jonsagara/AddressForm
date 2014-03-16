using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AddressForm.MvcWeb.Extensions;
using AddressForm.MvcWeb.Models;
using AddressForm.MvcWeb.Resources;

namespace AddressForm.MvcWeb.Validation
{
    /// <summary>
    /// A custom attribute is required for validating Locality (i.e., City/Town) so that jQuery unobtrusive
    /// validation and Data Annotations can display an error message appropriate for the selected country.
    /// </summary>
    public class LocalityRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private string CountryPropertyName { get; set; }

        public LocalityRequiredAttribute(string countryPropertyName)
            : base("The {0} field is required.")
        {
            CountryPropertyName = countryPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var country = validationContext.ObjectInstance.GetPropertyValue<string>(CountryPropertyName);

            // Locality is always required. Just format the error message according to country.

            return new RequiredAttribute().IsValid(value)
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(country));
        }

        public override string FormatErrorMessage(string countryName)
        {
            return string.Format(ErrorMessageString, GetDisplayName(countryName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var model = (PersonEditorModel)context.Controller.ViewData.Model;
            var modelClientValRule = new ModelClientValidationRule
            {
                ValidationType = "localityrequired",
                ErrorMessage = FormatErrorMessage(model.Country)
            };

            // We don't need to reference country on the client side because Locality is always required, regardless of selected Country.

            yield return modelClientValRule;
        }


        #region Private Methods

        private string GetDisplayName(string country)
        {
            if (country == "US")
            {
                return AddressFormResources.LocalityLabelUS;
            }

            if (country == "CA")
            {
                return AddressFormResources.LocalityLabelCA;
            }

            return AddressFormResources.LocalityLabelOther;
        }

        #endregion
    }
}