using System;

namespace UniFiSharp.Json.Attributes
{
    /// <summary>
    /// Data visibility levels
    /// </summary>
    public enum Levels
    {
        /// <summary>
        /// Show data when rendering a table of multiple objects of the same type; this expects the properties to be rendered as columns rather than rows
        /// </summary>
        Minimal = 4,

        /// <summary>
        /// Show data when no arguments are given to an information request
        /// </summary>
        Basic = 3,

        /// <summary>
        /// Show data when the user requests more technical or extended information
        /// </summary>
        Extended = 2,

        /// <summary>
        /// Only show data when the user explicitly requests a complete dump of the object
        /// </summary>
        All = 1
    }

    /// <summary>
    /// When to show a given property on an object
    /// </summary>
    public class ShowWithAttribute : Attribute
    {
        public bool IsVisibleAt(Levels targetLevel) => targetLevel >= Level;

        public Levels Level { get; }
        public ShowWithAttribute(Levels filterLevel) => Level = filterLevel;
    }
}
