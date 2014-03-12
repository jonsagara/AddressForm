using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;

namespace AddressForm.MvcWeb.Validation
{
    public class PostalCodeRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        private static readonly List<string> CountriesRequiringPostalCode = new List<string> { "US", "CA" }; 

        public string CountryPropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var country = GetCountryValue(validationContext.ObjectInstance, CountryPropertyName);

            if (CountriesRequiringPostalCode.Contains(country))
            {
                return new RequiredAttribute().IsValid(value)
                    ? ValidationResult.Success
                    : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValRule = new ModelClientValidationRule
            {
                ValidationType = "postalcoderequiredifcountry",
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
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

        #endregion
    }
}