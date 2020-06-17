using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;

namespace NewsFeed
{
    /// <summary>
    /// News Feed extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class NewsFeedExtensions
    {
        /// <summary>
        /// Add News Feed services to the IoC container.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddNewsFeedServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services;
        }
    }
}
