using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Cmd.Tools.Weather;
using NewsFeed.Core;

namespace NewsFeed.Cmd.Tools
{
    /// <summary>
    /// Tools extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ToolsExtensions
    {
        /// <summary>
        /// Add tool services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddToolsServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddSingleton<IConsolePrinter, ConsolePrinter>()
                .AddSingleton<IWeatherForecastConsolePrinter, WeatherForecastConsolePrinter>();
        }
    }
}
