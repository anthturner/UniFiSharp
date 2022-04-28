using System;

namespace UniFiSharp
{
    public static class DataTypeConversionExtensions
    {
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string WithSizeSuffix(this double value, int decimalPlaces = 1) => WithSizeSuffix((long)value, decimalPlaces);
        public static string WithSizeSuffix(this float value, int decimalPlaces = 1) => WithSizeSuffix((long)value, decimalPlaces);
        public static string WithSizeSuffix(this int value, int decimalPlaces = 1) => WithSizeSuffix((long)value, decimalPlaces);
        public static string WithSizeSuffix(this long value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + WithSizeSuffix(-value, decimalPlaces); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }
    }
}
