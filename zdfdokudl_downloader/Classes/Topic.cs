using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    public class Topic
    {
        public int Id;
        public string Name;
        public string Description;
        public string Title;
        public DocuTopicType Type = DocuTopicType.None;
        public Thumbnail Thumbnail;
    }
}
