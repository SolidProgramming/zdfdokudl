namespace zdfdokudl_downloader.Classes
{
    public class HttpZdfDeRelsRecommendedVideos
    {
        public string filterType { get; set; }
        public List<string> filterDocTypes { get; set; }
        public string profile { get; set; }
        public string self { get; set; }
        public string canonical { get; set; }
        public ResultsWithVideo resultsWithVideo { get; set; }
        public bool filterFskBlocked { get; set; }
    }


}
