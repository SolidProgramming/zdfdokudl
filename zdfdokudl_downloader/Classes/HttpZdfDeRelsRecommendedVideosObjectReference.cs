namespace zdfdokudl_downloader.Classes
{
    public class HttpZdfDeRelsRecommendedVideosObjectReference
    {
        public string profile { get; set; }

        [JsonProperty("reference-type")]
        public string ReferenceType { get; set; }
        public string uri { get; set; }
    }


}
