using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    public class Teaser
    {
        public string? Title;
        public Url Url;
        public DocuTopicType Type = DocuTopicType.None;
        public Thumbnail Thumbnail;
        public DataTrack? DataTrack;
    }
}
