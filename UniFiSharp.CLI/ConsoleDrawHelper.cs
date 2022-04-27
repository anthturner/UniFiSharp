using Spectre.Console;

namespace UniFiSharp.CLI
{
    internal static class ConsoleDrawHelper
    {
        internal static Color GenerateColorForString(string str)
        {
            var bytes = System.Security.Cryptography.SHA256.Create()
                              .ComputeHash(System.Text.Encoding.UTF8.GetBytes(str))
                              .TakeLast(3)
                              .ToArray();
            return new Color(bytes[0], bytes[1], bytes[2]);
        }

        internal static async Task ShowDynamicBarChart<TDevice>(
            string title, Func<TDevice, string> nameFunc, Func<TDevice, int> valueFunc, Func<int, bool> valueGateFunc, int interval,
            Func<Task<IEnumerable<TDevice>>> getData)
        {
            var chart = new BarChart()
                    .Width(Console.WindowWidth)
                    .LeftAlignLabel()
                    .Label(title);

            await AnsiConsole.Live(chart)
                .StartAsync(async ctx =>
                {
                    var lastDrawnTime = DateTime.MinValue;
                    while (!Console.KeyAvailable || Console.ReadKey().Key != ConsoleKey.Escape)
                    {
                        if ((DateTime.Now - lastDrawnTime).TotalMilliseconds > interval)
                        {
                            // get data
                            var clientSource = new List<TDevice>();
                            clientSource.AddRange((await getData()).OrderByDescending(valueFunc).Where(i => valueGateFunc(valueFunc(i))));
                            if (!clientSource.Any()) return;

                            chart = new BarChart()
                                .Width(Console.WindowWidth)
                                .LeftAlignLabel()
                                .Label(title);

                            clientSource.ForEach(item =>
                            {
                                var name = nameFunc(item);
                                var value = valueFunc(item);
                                chart.AddItem(name, value, ConsoleDrawHelper.GenerateColorForString(name));
                            });

                            ctx.UpdateTarget(chart);

                            lastDrawnTime = DateTime.Now;
                        }
                    }
                });
        }
    }
}
