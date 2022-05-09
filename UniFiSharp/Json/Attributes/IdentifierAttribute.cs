using System;

namespace UniFiSharp.Json.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdentifierAttribute : Attribute
    {
        public IdentifierAttribute() { }
    }
}
