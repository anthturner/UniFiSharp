using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections;
using System.Reflection;
using UniFiSharp.Json;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.CLI
{
    internal class TableGenerator
    {
        Levels Level { get; }
        internal TableGenerator(Levels level = Levels.Basic) => Level = level;

        internal IRenderable GenerateMultipleObjectListTable<TEnumerated>(IEnumerable<TEnumerated> data, bool isInsideComplexObject = false)
        {
            if (data == null || !data.Any()) return new Text("<No Data>");

            var properties = (data as IJsonObject).GetVisibleProperties(Levels.Minimal);

            var tbl = new Table().AddColumns(
                properties.Select(p => new TableColumn(p.GetPropertyName()))
                          .ToArray());

            foreach (var row in data)
                tbl.AddRow(properties.Select(p => GenerateTableValue(p.GetValue(row), isInsideComplexObject)).ToArray());

            return tbl;
        }

        internal IRenderable GenerateSingleObjectTable<TObject>(TObject data, bool isInsideComplexObject = false)
        {
            var tbl = new Table().AddColumns("Property", "Value").HideHeaders();

            var properties = (data as IJsonObject).GetVisibleProperties(isInsideComplexObject ? Levels.Minimal : Level);
            foreach (var property in properties)
                tbl.AddRow(new Text(Markup.Escape(property.GetPropertyName())), GenerateTableValue(property.GetValue(data), true));

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
    }
}
