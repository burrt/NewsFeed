using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM observations.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public record BomObservations
    {
#pragma warning disable IDE1006
#pragma warning disable SA1300 // Element should begin with upper-case letter

        /// <summary>
        /// Gets BOM header.
        /// </summary>
        public IList<BomHeader> header { get; init; }

        /// <summary>
        /// Gets BOM data.
        /// </summary>
        public IList<BomData> data { get; init; }

#pragma warning restore IDE1006
#pragma warning restore SA1300 // Element should begin with upper-case letter
    }
}
