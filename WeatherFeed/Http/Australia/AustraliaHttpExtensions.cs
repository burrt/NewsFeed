using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;

namespace WeatherFeed.Http.Australia
{
    internal static class AustraliaHttpExtensions
    {
        internal static IServiceCollection AddAustraliaHttpServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            // Add typed HTTP clients
            services.AddHttpClient<BomHttpClient>();

            return services
                .AddTransient<IBomAustraliaApiRunner, BomAustraliaApiRunner>();;
        }
    }
}
