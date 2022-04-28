using System;
using System.ComponentModel;
using System.Linq;

namespace UniFiSharp.Json
{
    public abstract class IJsonObject
    {
        public T CloneAs<T>() where T : IJsonObject
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
        public T CloneAs<T>(Action<T> action) where T : IJsonObject
        {
            var clone = CloneAs<T>();
            action(clone);
            return clone;
        }
    }
}
