using NewsFeed.Http.Australia.NSW;
using System.Threading;
using System.Threading.Tasks;

namespace NewsFeed.Http.Australia
{
    public interface IBomAustraliaApiRunner : IBomNswApiRunner
    {
        /// <summary>
        /// Gets the latest weather forcast for all states in Australia from the BOM.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        public Task GetLatestAustraliaForcastAsync(CancellationToken cancellationToken = default);
    }
}
