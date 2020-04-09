using System.Collections.Generic;

namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    public class BomObservations
    {
#pragma warning disable IDE1006

        public IList<BomHeader> header { get; set; }
        public IList<BomData> data { get; set; }

#pragma warning restore IDE1006
    }
}