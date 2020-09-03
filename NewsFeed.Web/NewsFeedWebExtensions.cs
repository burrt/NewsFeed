using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using WeatherFeed;

namespace NewsFeed.Web
{
    /// <summary>
    /// News feed web extensions.
    /// </summary>
    public static class NewsFeedWebExtensions
    {
        /// <summary>
        /// Add news feed web services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddNewsFeedWebServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddNewsFeedServices()
                .AddWeatherFeedServices();
        }
    }
}
