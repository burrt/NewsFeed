using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;
using NewsFeed.Weather.Australia.NSW;
using System.Diagnostics.CodeAnalysis;

namespace WeatherFeed.Australia.NSW
{
    [ExcludeFromCodeCoverage]
    public static class NswWeatherExtensions
    {
        public static IServiceCollection AddNswWeatherServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services
                .AddTransient<ISydneyRegionWeatherForecast, SydneyRegionWeatherForecast>();
        }
    }
}
