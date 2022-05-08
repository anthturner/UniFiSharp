using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using UniFiSharp.Json;

namespace UniFiSharp.CLI
{
    internal class TableGenerator
    {
        Complexities Complexity { get; }
        internal TableGenerator(Complexities complexity = Complexities.Average) => Complexity = complexity;

        internal IRenderable GenerateMultipleObjectListTable<TEnumerated>(IEnumerable<TEnumerated> data, bool isInsideComplexObject = false)
        {
            if (data == null || !data.Any()) return new Text("<No Data>");

            var properties = MultiObjectDisplayProperties(data);

            var tbl = new Table().AddColumns(
                properties.Select(p => new TableColumn(GeneratePropertyName(p)))
                          .ToArray());

            foreach (var row in data)
                tbl.AddRow(properties.Select(p => GenerateTableValue(p.GetValue(row), isInsideComplexObject)).ToArray());

            return tbl;
        }

        internal IRenderable GenerateSingleObjectTable<TObject>(TObject data, bool isInsideComplexObject = false)
        {
            var tbl = new Table().AddColumns("Property", "Value").HideHeaders();

            var properties = SingleObjectDisplayProperties(data, isInsideComplexObject);
            foreach (var property in properties)
                tbl.AddRow(GeneratePropertyName(property), GenerateTableValue(property.GetValue(data), true));

            return tbl;
        }

        internal IRenderable GenerateNumberedListTable<TEnumerated>(IEnumerable<TEnumerated> data, bool isInsideComplexObject = false)
        {
            if (data == null || !data.Any()) return new Text("<No Data>");

            var tbl = new Table().HideHeaders().AddColumn("");
            foreach (var item in data)
                tbl.AddRow(GenerateTableValue(item, isInsideComplexObject));

            return tbl;
        }

        private IRenderable GenerateTableValue<TData>(TData data, bool isInsideOtherData = false)
        {
            if (data == null) return new Text(string.Empty);

            if (data is IEnumerable && data is not string)
            {
                var enumerableInterface = data.GetType().GetInterfaces().First(i => i.Name.StartsWith("IEnumerable") && i.IsGenericType);
                var genericArgs = enumerableInterface.GetGenericArguments()[0];
                var method = GetType().GetMethod(nameof(GenerateNumberedListTable), BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(genericArgs);
                return (IRenderable)method.Invoke(this, new object[] { data, isInsideOtherData });
            }

            if (data is IJsonObject) return GenerateSingleObjectTable(data, isInsideOtherData);

            return new Text(Markup.Escape(data.ToString()));
        }

        private static IRenderable GeneratePropertyName(PropertyInfo property) =>
            new Text(Markup.Escape(property.GetCustomAttribute<DisplayNameAttribute>() != null ?
                                   property.GetCustomAttribute<DisplayNameAttribute>().DisplayName :
                                   property.Name));

        private IEnumerable<PropertyInfo> MultiObjectDisplayProperties<TObject>(TObject data) =>
            data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                          .Where(p => p.GetCustomAttribute<IncludeInObjectGroupAttribute>() != null);

        private IEnumerable<PropertyInfo> SingleObjectDisplayProperties<TObject>(TObject data, bool isInsideComplexObject = false) =>
            data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                          .Where(p =>
                          {
                              var attr = p.GetCustomAttribute<ComplexityAttribute>();
                              if (isInsideComplexObject)
                              {
                                  if (attr == null) return false; // complexity is high if not given
                                  return attr.Complexity >= Complexities.Low;
                              }
                              else
                              {
                                  if (attr == null) return Complexity <= Complexities.HighlyTechnical; // no complexity attribute -> highest complexity
                                  return attr.Complexity >= Complexity;
                              }
                          });
    }
}
