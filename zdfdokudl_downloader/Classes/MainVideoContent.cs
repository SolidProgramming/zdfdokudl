namespace zdfdokudl_downloader.Classes
{
    public class MainVideoContent
    {
        [JsonProperty("http://zdf.de/rels/target")]
        public HttpZdfDeRelsTarget HttpZdfDeRelsTarget { get; set; }
        public string profile { get; set; }
    }


}
