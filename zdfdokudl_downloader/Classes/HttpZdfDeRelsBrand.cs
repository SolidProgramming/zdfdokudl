namespace zdfdokudl_downloader.Classes
{
    public class HttpZdfDeRelsBrand
    {
        public string profile { get; set; }
        public string self { get; set; }
        public string canonical { get; set; }
        public string title { get; set; }

        [JsonProperty("http://zdf.de/rels/target")]
        public HttpZdfDeRelsTarget HttpZdfDeRelsTarget { get; set; }
    }


}
