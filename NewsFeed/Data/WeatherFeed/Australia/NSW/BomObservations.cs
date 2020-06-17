using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    /// <summary>
    /// BOM observations.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BomObservations
    {
#pragma warning disable IDE1006
#pragma warning disable SA1300 // Element should begin with upper-case letter

        /// <summary>
        /// Gets or sets Header.
        /// </summary>
        public IList<BomHeader> header { get; set; }

        /// <summary>
        /// Gets or sets data.
        /// </summary>
        public IList<BomData> data { get; set; }

#pragma warning restore IDE1006
#pragma warning restore SA1300 // Element should begin with upper-case letter
    }
}
