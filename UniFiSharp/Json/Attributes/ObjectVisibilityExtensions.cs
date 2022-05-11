using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UniFiSharp.Json.Attributes
{
    public static class ObjectVisibilityExtensions
    {
        /// <summary>
        /// Check if any identifier property matches a given search string.
        /// </summary>
        /// <remarks>
        /// Search strings can contain "*" to match multiple characters or "?" to match a single character.
        /// </remarks>
        /// <example>
        /// obj.IdentifierMatches("dev-*-office")
        /// </example>
        /// <param name="obj">Object being checked for matching identifier</param>
        /// <param name="searchString">Search string</param>
        /// <returns><c>TRUE</c> if any identifier on this object matches the search string</returns>
        public static bool IdentifierMatches(this IJsonObject obj, string searchString)
        {
            var searchRegex = new Regex($"^{Regex.Escape(searchString).Replace("\\?", ".").Replace("\\*", ".*")}$");
            return obj.GetType()
                      .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                      .Where(p => p.GetCustomAttribute<IdentifierAttribute>() != null)
                      .Any(p => searchRegex.IsMatch(p.GetValue(obj).ToString()));
        }

        /// <summary>
        /// Get a collection of properties for a given object which should be displayed at a specified filter level (or below).
        /// </summary>
        /// <param name="obj">Object being checked for properties</param>
        /// <param name="level">Requested data filter level</param>
        /// <returns>A collection of PropertyInfo objects representing what is to be displayed</returns>
        public static IEnumerable<PropertyInfo> GetVisibleProperties(this IJsonObject obj, Levels level = Levels.Basic) =>
            obj.GetType()
               .GetProperties(BindingFlags.Instance | BindingFlags.Public)
               .Where(p =>
               {
                   if (level == Levels.All) return true;
                   return (p.GetCustomAttribute<ShowWithAttribute>() != null &&
                           p.GetCustomAttribute<ShowWithAttribute>().IsVisibleAt(level));
               })
               .OrderBy(p => p.GetPropertyName());

        /// <summary>
        /// Get the collection of properties for a given object to be displayed in a pivoted view.
        /// (e.g. when multiple of the same object type is displayed in a table, these will be used as the columns)
        /// </summary>
        /// <param name="obj">Object being checked for properties</param>
        /// <returns>A collection of PropertyInfo objects representing what is to be displayed</returns>
        public static IEnumerable<PropertyInfo> GetMultipleViewColumns(this IJsonObject obj) => GetVisibleProperties(obj, Levels.Minimal);

        /// <summary>
        /// Get all groups of properties for a given object to be displayed
        /// </summary>
        /// <param name="obj">Object being checked for properties</param>
        /// <param name="level">Requested data filter level</param>
        /// <returns>A collection of PropertyInfo objects representing what is to be displayed, grouped by name</returns>
        public static IDictionary<string, IEnumerable<PropertyInfo>> GetPropertyGroups(this IJsonObject obj, Levels level = Levels.Basic) =>
            obj.GetVisibleProperties(level).GroupBy(p =>
            {
                var groupAttr = p.GetCustomAttribute<GroupAttribute>();
                if (groupAttr == null) return string.Empty;
                else return groupAttr.Name;
            }).ToDictionary(k => k.Key, v => v.AsEnumerable());

        public static string GetPropertyName(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.GetCustomAttribute<DisplayNameAttribute>() == null)
                return propertyInfo.Name;
            else return propertyInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
        }
    }
}
