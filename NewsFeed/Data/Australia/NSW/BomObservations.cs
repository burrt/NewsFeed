using System.Collections.Generic;

namespace NewsFeed.Data.Australia.NSW
{
    public class BomObservations
    {
        public IList<BomHeader> header { get; set; }
        public IList<BomData> data { get; set; }
    }
}