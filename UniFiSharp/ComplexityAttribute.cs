using System;

namespace UniFiSharp
{
    /// <summary>
    /// Level of detail associated with a given property. This defines how it is included in the output.
    /// </summary>
    public enum Complexities : int
    {
        /// <summary>
        /// Discard this data
        /// </summary>
        Discard = 0,

        /// <summary>
        /// Data is high in technical complexity
        /// </summary>
        HighlyTechnical = 1,

        /// <summary>
        /// Data is average in technical complexity
        /// </summary>
        Average = 2,
        
        /// <summary>
        /// Data is low in technical complexity
        /// </summary>
        Low = 3
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class IncludeInObjectGroupAttribute : Attribute {
        public IncludeInObjectGroupAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ComplexityAttribute : Attribute
    {
        public Complexities Complexity { get; private set; }

        public ComplexityAttribute(Complexities complexity = Complexities.Average)
        {
            Complexity = complexity;
        }
    }
}
