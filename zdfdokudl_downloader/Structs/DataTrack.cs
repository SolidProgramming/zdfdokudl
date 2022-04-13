using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Structs
{
    public class DataTrack
    {
        public string element { get; set; }
        public string action { get; set; }
        public string targetAssetId { get; set; }
        public string nodeId { get; set; }
        public string clickedClusterPosition { get; set; }
        public string clickedTeaserPosition { get; set; }
        public string format { get; set; }
        public string teaserTracking { get; set; }
        public string actionDetail { get; set; }
    }
}
