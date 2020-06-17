using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;

namespace WeatherFeed.Http.Australia
{
    /// <summary>
    /// Australia HTTP extensions.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class AustraliaHttpExtensions
    {
        /// <summary>
        /// Add Australia HTTP services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddAustraliaHttpServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            // Add typed HTTP clients
            services.AddHttpClient<BomHttpClient>();

            return services
                .AddTransient<IBomAustraliaApiRunner, BomAustraliaApiRunner>();
        }
    }
}
