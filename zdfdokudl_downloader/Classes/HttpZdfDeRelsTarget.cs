namespace zdfdokudl_downloader.Classes
{
    public class HttpZdfDeRelsTarget
    {
        public string id { get; set; }
        public string externalId { get; set; }
        public string title { get; set; }
        public bool hasVideo { get; set; }
        public string contentType { get; set; }
        public string profile { get; set; }
        public string self { get; set; }
        public string canonical { get; set; }
        public string structureNodePath { get; set; }
        public string altText { get; set; }
        public string copyrightNotice { get; set; }
        public string source { get; set; }
        public Layouts layouts { get; set; }
        public List<Stage> stage { get; set; }
        public int duration { get; set; }
        public bool visible { get; set; }
        public DateTime visibleFrom { get; set; }
        public DateTime visibleTo { get; set; }
        public string aspectRatio { get; set; }

        [JsonProperty("http://zdf.de/rels/streams/ptmd-template")]
        public string HttpZdfDeRelsStreamsPtmdTemplate { get; set; }
        public Streams streams { get; set; }
        public DateTime editorialDate { get; set; }
        public TeaserImageRef teaserImageRef { get; set; }

        [JsonProperty("http://zdf.de/rels/category")]
        public HttpZdfDeRelsCategory HttpZdfDeRelsCategory { get; set; }

        [JsonProperty("http://zdf.de/rels/sharing-url")]
        public string HttpZdfDeRelsSharingUrl { get; set; }

        [JsonProperty("http://zdf.de/rels/brand")]
        public HttpZdfDeRelsBrand HttpZdfDeRelsBrand { get; set; }
        public string currentVideoType { get; set; }

        [JsonProperty("http://zdf.de/rels/player")]
        public string HttpZdfDeRelsPlayer { get; set; }
        public Tracking tracking { get; set; }
        public bool fskBlocked { get; set; }
        public MainVideoContent mainVideoContent { get; set; }
        public string genre { get; set; }
        public string subtitle { get; set; }
        public string contentId { get; set; }
    }


}
