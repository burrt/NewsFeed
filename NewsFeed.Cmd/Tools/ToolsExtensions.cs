using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Cmd.Tools
{
    [ExcludeFromCodeCoverage]
    public static class ToolsExtensions
    {
        public static IServiceCollection AddToolsServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddSingleton<IConsolePrinter, ConsolePrinter>()
                .AddSingleton<IWeatherForecastConsolePrinter, WeatherForecastConsolePrinter>();
        }
    }
}
