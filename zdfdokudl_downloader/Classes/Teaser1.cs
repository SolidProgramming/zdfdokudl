namespace zdfdokudl_downloader.Classes
{
    public class Teaser
    {
        [JsonProperty("http://zdf.de/rels/target")]
        public HttpZdfDeRelsTarget HttpZdfDeRelsTarget { get; set; }
        public string headerDecorationText { get; set; }
        public bool displayBrandLogo { get; set; }
        public string profile { get; set; }
    }


}
