using System;

namespace UniFiSharp
{
    [Flags]
    public enum VisualizationModes : int
    {
        Single = 1,
        Multiple = 2,
        Both = 3
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal class IncludedInVisualizationAttribute : Attribute
    {
        public VisualizationModes VisualizationMode { get; private set; }
        
        public IncludedInVisualizationAttribute(VisualizationModes mode = VisualizationModes.Single)
        {
            VisualizationMode = mode;
        }
    }
}
