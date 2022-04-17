using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{

    public class ZDFMainContentVideoResponse
    {
        public Attributes attributes { get; set; }
        public string basename { get; set; }
        public List<Caption> captions { get; set; }
        public int documentVersion { get; set; }
        public string mandant { get; set; }
        public string playerId { get; set; }
        public List<PriorityList> priorityList { get; set; }
        public string profile { get; set; }
        public ScrubPreview scrubPreview { get; set; }
        public string self { get; set; }
        public int version { get; set; }
    }

}
