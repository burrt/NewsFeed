using Microsoft.Extensions.DependencyInjection;
using NewsFeed.Core;

namespace NewsFeed
{
    public static class NewsFeedExtensions
    {
        public static IServiceCollection AddNewsFeedServices(this IServiceCollection services)
        {
            Guard.IsNotNull(services, nameof(services));

            return services;
        }
    }
}
