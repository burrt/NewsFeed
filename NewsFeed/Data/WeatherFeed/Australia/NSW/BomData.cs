namespace NewsFeed.Data.WeatherFeed.Australia.NSW
{
    public class BomData
    {
#pragma warning disable IDE1006

        public int sort_order { get; set; }
        public string name { get; set; }
        public string local_date_time { get; set; }
        public long aifstime_utc { get; set; }
        public double air_temp { get; set; }
        public string wind_dir { get; set; }
        public int wind_spd_kmh { get; set; }

#pragma warning restore IDE1006
    }
}
