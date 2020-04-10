using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Core;

namespace NewsFeed.Cmd.Tools
{
    internal static class ToolsExtensions
    {
        internal static IServiceCollection AddToolsServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddSingleton<IConsolePrinter, ConsolePrinter>()
                .AddSingleton<IWeatherForecastConsolePrinter, WeatherForecastConsolePrinter>();
        }
    }
}
