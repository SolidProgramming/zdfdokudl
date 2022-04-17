using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{

    public class PlayerResponse
    {
        public string contentType { get; set; }
        public string title { get; set; }
        public DateTime editorialDate { get; set; }
        public string leadParagraph { get; set; }
        public string teasertext { get; set; }

        [JsonProperty("http://zdf.de/rels/next-video-personalized")]
        public string HttpZdfDeRelsNextVideoPersonalized { get; set; }

        [JsonProperty("http://zdf.de/rels/next-video-timeout")]
        public int HttpZdfDeRelsNextVideoTimeout { get; set; }
        public TeaserImageRef teaserImageRef { get; set; }
        public bool embeddingPossible { get; set; }
        public DateTime endDate { get; set; }

        [JsonProperty("http://zdf.de/rels/category")]
        public HttpZdfDeRelsCategory HttpZdfDeRelsCategory { get; set; }

        [JsonProperty("http://zdf.de/rels/uri")]
        public string HttpZdfDeRelsUri { get; set; }

        [JsonProperty("http://zdf.de/rels/sharing-url")]
        public string HttpZdfDeRelsSharingUrl { get; set; }

        [JsonProperty("http://zdf.de/rels/brand")]
        public HttpZdfDeRelsBrand HttpZdfDeRelsBrand { get; set; }
        public bool hasVideo { get; set; }
        public string currentVideoType { get; set; }
        public string tvService { get; set; }
        public string profile { get; set; }
        public string self { get; set; }
        public string canonical { get; set; }
        public string structureNodePath { get; set; }

        [JsonProperty("http://zdf.de/rels/recommended-videos")]
        public HttpZdfDeRelsRecommendedVideos HttpZdfDeRelsRecommendedVideos { get; set; }

        [JsonProperty("http://zdf.de/rels/recommended-videos-object-reference")]
        public HttpZdfDeRelsRecommendedVideosObjectReference HttpZdfDeRelsRecommendedVideosObjectReference { get; set; }
        public Tracking tracking { get; set; }
        public bool fskBlocked { get; set; }
        public List<string> additionalPaths { get; set; }
        public List<ProgrammeItem> programmeItem { get; set; }
        public MainVideoContent mainVideoContent { get; set; }
    }


}
