using System;
using System.Text;
using AddressForm.MvcWeb.Models;

namespace AddressForm.MvcWeb.Extensions
{
    public static class PersonExtensions
    {
        public static string ToSingleLineAddress(this Person entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var address = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(entity.StreetAddress))
            {
                address.Append(entity.StreetAddress);
            }

            if (!string.IsNullOrWhiteSpace(entity.ExtendedAddress))
            {
                if (address.Length > 0)
                {
                    address.Append(", ");
                }

                address.Append(entity.ExtendedAddress);
            }

            if (!string.IsNullOrWhiteSpace(entity.Locality))
            {
                if (address.Length > 0)
                {
                    address.Append(", ");
                }

                address.Append(entity.Locality);
            }

            if (!string.IsNullOrWhiteSpace(entity.Region))
            {
                if (address.Length > 0)
                {
                    address.Append(", ");
                }

                address.Append(entity.Region);
            }

            if (!string.IsNullOrWhiteSpace(entity.PostalCode))
            {
                if (address.Length > 0)
                {
                    // Space between state and U.S. Zip Code. Assumes state precedes it.
                    address.Append(" ");
                }

                address.Append(entity.PostalCode);
            }

            if (!string.IsNullOrWhiteSpace(entity.Country))
            {
                if (address.Length > 0)
                {
                    address.Append(", ");
                }

                address.Append(entity.Country);
            }

            return address.ToString();
        }
    }
}