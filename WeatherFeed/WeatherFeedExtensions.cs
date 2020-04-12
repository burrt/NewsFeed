using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using System.Diagnostics.CodeAnalysis;
using WeatherFeed.Australia;
using WeatherFeed.Http.Australia;

namespace WeatherFeed
{
    [ExcludeFromCodeCoverage]
    public static class WeatherFeedExtensions
    {
        public static IServiceCollection AddWeatherFeedServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddAustraliaWeatherServices()
                .AddAustraliaHttpServices();
        }
    }
}
