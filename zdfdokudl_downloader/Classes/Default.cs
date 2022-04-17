namespace zdfdokudl_downloader.Classes
{
    public class Default
    {
        public string label { get; set; }
        public string extId { get; set; }

        [JsonProperty("http://zdf.de/rels/streams/ptmd-template")]
        public string HttpZdfDeRelsStreamsPtmdTemplate { get; set; }
    }


}
