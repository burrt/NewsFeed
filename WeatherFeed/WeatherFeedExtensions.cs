using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;
using WeatherFeed.Australia;
using WeatherFeed.Http.Australia;

namespace WeatherFeed
{
    /// <summary>
    /// Weather feed extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WeatherFeedExtensions
    {
        /// <summary>
        /// Add weather feed services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddWeatherFeedServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddAustraliaWeatherServices()
                .AddAustraliaHttpServices();
        }
    }
}
