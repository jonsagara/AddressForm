using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AddressForm.MvcWeb.Models;
using AddressForm.MvcWeb.Resources;

namespace AddressForm.MvcWeb.Validation
{
    public class PostalCodeRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private static readonly List<string> CountriesRequiringPostalCode = new List<string> { "US", "CA" }; 

        private string CountryPropertyName { get; set; }

        public PostalCodeRequiredAttribute(string countryPropertyName)
            : base("The {0} field is required.")
        {
            CountryPropertyName = countryPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var country = GetCountryValue(validationContext.ObjectInstance, CountryPropertyName);

            if (CountriesRequiringPostalCode.Contains(country))
            {
                return new RequiredAttribute().IsValid(value)
                    ? ValidationResult.Success
                    : new ValidationResult(FormatErrorMessage(country));
            }

            return ValidationResult.Success;
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
                ValidationType = "postalcoderequiredifcountry",
                ErrorMessage = FormatErrorMessage(model.Country)
            };

            modelClientValRule.ValidationParameters.Add("countryprop", CountryPropertyName);

            yield return modelClientValRule;
        }


        #region Private Methods

        private static string GetCountryValue(object objectInstance, string countryPropertyName)
        {
            if (objectInstance == null)
            {
                throw new ArgumentNullException("objectInstance");
            }

            if (string.IsNullOrWhiteSpace(countryPropertyName))
            {
                throw new ArgumentException("CountryPropertyName must not be null or white space", "countryPropertyName");
            }

            var propertyInfo = objectInstance.GetType().GetProperty(countryPropertyName);
            return (string)propertyInfo.GetValue(objectInstance);
        }

        private string GetDisplayName(string country)
        {
            if (CountriesRequiringPostalCode.Contains(country))
            {
                // Currently only support U.S. and Canada.
                return country == "US" 
                    ? AddressFormResources.PostalCodeLabelUS 
                    : AddressFormResources.PostalCodeLabelCA;
            }

            return AddressFormResources.PostalCodeLabelOther;
        }

        #endregion
    }
}