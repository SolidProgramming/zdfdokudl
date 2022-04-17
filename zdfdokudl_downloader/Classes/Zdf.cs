namespace zdfdokudl_downloader.Classes
{
    public class Zdf
    {
        [JsonProperty("config-v2")]
        public ConfigV2 ConfigV2 { get; set; }

        [JsonProperty("templates-v2")]
        public TemplatesV2 TemplatesV2 { get; set; }
    }


}
