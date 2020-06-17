using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;
using WeatherFeed.Australia.NSW;

namespace WeatherFeed.Australia
{
    /// <summary>
    /// Australia weather extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AustraliaWeatherExtensions
    {
        /// <summary>
        /// Add Australia weather services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddAustraliaWeatherServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddNswWeatherServices();
        }
    }
}
