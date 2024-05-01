using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Cmd.Tools;
using NewsFeed.Core;
using WeatherFeed;

namespace NewsFeed.Cmd
{
    /// <summary>
    /// News feed cmd extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class NewsFeedCmdExtensions
    {
        /// <summary>
        /// Add news feed cmd services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddNewsFeedCmdServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddToolsServices()
                .AddNewsFeedServices()
                .AddWeatherFeedServices();
        }

        /// <summary>
        /// Adds the News Feed appsettings files to the Configuration Builder.
        /// </summary>
        /// <param name="configurationBuilder">The configuration builder to add the appsettings.json files to.</param>
        /// <param name="contentRootPath">The root path where the appsettings.json files are located.</param>
        /// <returns>Configuration builder.</returns>
        public static IConfigurationBuilder AddNewsFeedConfigurationJsonFiles(this IConfigurationBuilder configurationBuilder, string contentRootPath)
        {
            return configurationBuilder
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.LocalDev.json", optional: true);
        }
    }
}
