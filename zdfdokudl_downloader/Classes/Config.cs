namespace zdfdokudl_downloader.Classes
{
    public class Config
    {
        public string sc { get; set; }
        public ZDFKanal ZDF { get; set; }
        public ZDFKanal ZDFneo { get; set; }
        public ZDFKanal ZDFinfo { get; set; }

        [JsonProperty("ZDF.kultur")]
        public ZDFKanal ZDFKultur { get; set; }
        public ZDFKanal _3sat { get; set; }
        public ZDFKanal KiKA { get; set; }

        [JsonProperty("KI.KA")]
        public ZDFKanal KIKA { get; set; }

        [JsonProperty("ZDF-Mediathek")]
        public ZDFKanal ZDFMediathek { get; set; }
        public ZDFKanal PHOENIX { get; set; }
        public ZDFKanal ZDFtivi { get; set; }
        public ZDFKanal arte { get; set; }
        public ZDFKanal funk { get; set; }
        public ZDFKanal livestream { get; set; }
    }


}
