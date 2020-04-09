using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using WeatherFeed.Australia.NSW;

namespace WeatherFeed.Australia
{
    internal static class AustraliaWeatherExtensions
    {
        public static IServiceCollection AddAustraliaWeatherServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddNswWeatherServices();
        }
    }
}
