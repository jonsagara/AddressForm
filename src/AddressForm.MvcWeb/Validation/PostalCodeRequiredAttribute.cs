﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AddressForm.MvcWeb.Extensions;
using AddressForm.MvcWeb.Models;
using AddressForm.MvcWeb.Resources;

namespace AddressForm.MvcWeb.Validation
{
    /// <summary>
    /// If the selected Country is US or CA, then PostalCode is required. Otherwise, it is optional.
    /// Includes code for server-side validation and hooking up client-side unobtrusive validation.
    /// </summary>
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
            var country = validationContext.ObjectInstance.GetPropertyValue<string>(CountryPropertyName);

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