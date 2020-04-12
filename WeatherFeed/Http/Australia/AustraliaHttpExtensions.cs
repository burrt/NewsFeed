using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;

namespace WeatherFeed.Http.Australia
{
    [ExcludeFromCodeCoverage]
    public static class AustraliaHttpExtensions
    {
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
