using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using WeatherFeed.Australia;
using WeatherFeed.Http;
using WeatherFeed.Http.Australia;

namespace WeatherFeed
{
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
