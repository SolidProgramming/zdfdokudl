using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{   
    public class EmbedNotAllowed
    {
        public string message { get; set; }
    }

    public class VideoMissing
    {
        public string message { get; set; }
    }

    public class VideoNotYetAvailable
    {
        public string message { get; set; }
    }

    public class NoFormatSupported
    {
        public string message { get; set; }
    }

    public class Offline
    {
        public string message { get; set; }
        public bool reloadButton { get; set; }
    }

    public class PlaybackError
    {
        public string message { get; set; }
    }

    public class InitDataMissing
    {
        public string message { get; set; }
        public bool reloadButton { get; set; }
    }

    public class ConfigError
    {
        public string message { get; set; }
        public bool reloadButton { get; set; }
    }

    public class LoadError
    {
        public string message { get; set; }
        public bool reloadButton { get; set; }
    }

    public class LoadTimeout
    {
        public string message { get; set; }
        public bool reloadButton { get; set; }
    }

    public class ContentNotAllowed
    {
        public string message { get; set; }
    }

    public class Image
    {
        public string nano { get; set; }
        public string mini { get; set; }
        public string small { get; set; }
        public string normal { get; set; }
        public string maxi { get; set; }
    }

    public class Fsk12
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class Fsk16
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class Fsk18
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DeGeoblock
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DachGeoblock
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class EbuGeoblock
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DeGeoblockFsk12
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class EbuGeoblockFsk12
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DachGeoblockFsk12
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DeGeoblockFsk16
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class EbuGeoblockFsk16
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DachGeoblockFsk16
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DeGeoblockFsk18
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class EbuGeoblockFsk18
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class DachGeoblockFsk18
    {
        public string alt { get; set; }
        public Image image { get; set; }
    }

    public class Errors
    {
        public Default @default { get; set; }
        public EmbedNotAllowed embedNotAllowed { get; set; }
        public VideoMissing videoMissing { get; set; }
        public VideoNotYetAvailable videoNotYetAvailable { get; set; }
        public NoFormatSupported noFormatSupported { get; set; }
        public Offline offline { get; set; }
        public PlaybackError playbackError { get; set; }
        public InitDataMissing initDataMissing { get; set; }
        public ConfigError configError { get; set; }
        public LoadError loadError { get; set; }
        public LoadTimeout loadTimeout { get; set; }
        public ContentNotAllowed contentNotAllowed { get; set; }
        public Fsk12 fsk12 { get; set; }
        public Fsk16 fsk16 { get; set; }
        public Fsk18 fsk18 { get; set; }
        public DeGeoblock deGeoblock { get; set; }
        public DachGeoblock dachGeoblock { get; set; }
        public EbuGeoblock ebuGeoblock { get; set; }
        public DeGeoblockFsk12 deGeoblockFsk12 { get; set; }
        public EbuGeoblockFsk12 ebuGeoblockFsk12 { get; set; }
        public DachGeoblockFsk12 dachGeoblockFsk12 { get; set; }
        public DeGeoblockFsk16 deGeoblockFsk16 { get; set; }
        public EbuGeoblockFsk16 ebuGeoblockFsk16 { get; set; }
        public DachGeoblockFsk16 dachGeoblockFsk16 { get; set; }
        public DeGeoblockFsk18 deGeoblockFsk18 { get; set; }
        public EbuGeoblockFsk18 ebuGeoblockFsk18 { get; set; }
        public DachGeoblockFsk18 dachGeoblockFsk18 { get; set; }
    }

    public class PlayerConfiguration
    {
        public bool autoplay { get; set; }
        public bool preload { get; set; }
        public int shortVideoLength { get; set; }
        public int loadTimeout { get; set; }
        public bool sportDataPlayer { get; set; }
        public bool forceGuiOnMobile { get; set; }
        public bool muted { get; set; }
        public int controlsTimeout { get; set; }
        public bool dvr { get; set; }
        public bool flash { get; set; }
        public int logLevel { get; set; }
        public bool captionsButton { get; set; }
        public bool mediaLibraryButton { get; set; }
        public bool plusButton { get; set; }
        public bool skipIntroButton { get; set; }
        public string privacyButton { get; set; }
        public bool nextVideoTeaser { get; set; }
        public int volume { get; set; }
        public string nextVideoContentPrefix { get; set; }
        public string nextVideoContentSuffix { get; set; }
        public bool noPersonalizedReco { get; set; }
        public string apiProfile { get; set; }
        public string ptmdPlayerId { get; set; }
        public string epgServiceBaseUrl { get; set; }
        public string embedBaseUrl { get; set; }
        public Chromecast chromecast { get; set; }
        public QualityLabels qualityLabels { get; set; }
        public AudioChannelLabels audioChannelLabels { get; set; }
        public Tracking tracking { get; set; }
        public Errors errors { get; set; }
    }


}
