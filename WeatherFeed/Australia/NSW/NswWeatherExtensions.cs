using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using NewsFeed.Weather.Australia.NSW;

namespace WeatherFeed.Australia.NSW
{
    /// <summary>
    /// NSW weather extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class NswWeatherExtensions
    {
        /// <summary>
        /// Add NSW weather services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddNswWeatherServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddTransient<ISydneyRegionWeatherForecast, SydneyRegionWeatherForecast>();
        }
    }
}
