namespace zdfdokudl_downloader.Classes
{
    public class ResultsWithVideo
    {
        public int totalResultsCount { get; set; }
        public string next { get; set; }

        [JsonProperty("http://zdf.de/rels/search/suggestions")]
        public List<object> HttpZdfDeRelsSearchSuggestions { get; set; }

        [JsonProperty("http://zdf.de/rels/search/results")]
        public List<HttpZdfDeRelsSearchResult> HttpZdfDeRelsSearchResults { get; set; }
        public string profile { get; set; }
        public string self { get; set; }
        public string first { get; set; }
        public Facets facets { get; set; }
    }


}
