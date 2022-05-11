using System;

namespace UniFiSharp.Json.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GroupAttribute : Attribute
    {
        public string Name { get; set; }
        public GroupAttribute(string groupName) => Name = groupName;
    }
}
