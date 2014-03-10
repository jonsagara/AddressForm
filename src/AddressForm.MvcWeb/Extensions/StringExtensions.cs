using System;

namespace AddressForm.MvcWeb.Extensions
{
    public static class StringExtensions
    {
        public static bool DoesCountryHaveRegions(this string country)
        {
            if (country == null)
            {
                throw new ArgumentNullException("country");
            }

            // Currently only U.S.A and Canada.
            return (country == "US" || country == "CA");
        }
    }
}