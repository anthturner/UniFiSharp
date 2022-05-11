using System;
using System.ComponentModel;
using System.Linq;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Base class for JSON objects returned from UniFi
    /// </summary>
    public abstract class IJsonObject
    {
        protected const string GROUP_WIRELESS_5G = "5G Wireless";
        protected const string GROUP_WIRELESS_2G = "2.4G Wireless";
        protected const string GROUP_WIRELESS = "Wireless";

        protected const string GROUP_WIRED = "Wired";
        
        protected const string GROUP_POE = "Power Over Ethernet";

        internal T CloneAs<T>() where T : IJsonObject
        {
            var targetProperties = TypeDescriptor.GetProperties(typeof(T)).Cast<PropertyDescriptor>();
            var sourceProperties = TypeDescriptor.GetProperties(this).Cast<PropertyDescriptor>();

            var convert = (T)Activator.CreateInstance(typeof(T), true);

            foreach (var entityProperty in sourceProperties)
            {
                var val = entityProperty.GetValue(this);
                if (val == null || val == default) continue;

                var targetProperty = targetProperties.FirstOrDefault(prop => prop.Name == entityProperty.Name);
                targetProperty.SetValue(convert, val);
            }

            return convert;
        }
        internal T CloneAs<T>(Action<T> action) where T : IJsonObject
        {
            var clone = CloneAs<T>();
            action(clone);
            return clone;
        }
    }
}
