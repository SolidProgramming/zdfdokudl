namespace zdfdokudl_downloader.Classes
{
    public class HttpZdfDeRelsSearchResult
    {
        public object score { get; set; }

        [JsonProperty("http://zdf.de/rels/target")]
        public HttpZdfDeRelsTarget HttpZdfDeRelsTarget { get; set; }
        public string profile { get; set; }
        public string id { get; set; }
        public int viewCount { get; set; }
        public int ratingCount { get; set; }
        public string resultType { get; set; }
    }


}
