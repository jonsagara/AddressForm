using System;

namespace AddressForm.MvcWeb.Extensions
{
    public static class ObjectExtensions
    {
        public static T GetPropertyValue<T>(this object objectInstance, string propertyName)
        {
            if (objectInstance == null)
            {
                throw new ArgumentNullException("objectInstance");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("propertyName must not be null or white space", "propertyName");
            }

            var propertyInfo = objectInstance.GetType().GetProperty(propertyName);
            return (T)propertyInfo.GetValue(objectInstance);
        }
    }
}