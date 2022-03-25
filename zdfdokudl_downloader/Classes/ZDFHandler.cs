using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    internal static class ZDFHandler
    {
        private static HtmlDocument htmlDocument = new();

        //thumbnail small     https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=240x270
        //thumbnail big       https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=640x720
        //thumbnail wide      https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=384x216 
        //thumbnail wallpaper https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=2400x1350

        internal static async Task<List<Topic>> CreateTopicList()
        {
            string pageContent = await PageHandler.GetPageContent("https://www.zdf.de/doku-wissen");

            htmlDocument.LoadHtml(pageContent);

            List<HtmlNode>? nodes = new ParserQueryBuilder()
                .Query(ref htmlDocument)
                .ByAttributeValues("data-node-id", Misc.AllowedDocuTopics.Keys.ToList())
                .Result;  



            return null;
        }
        internal static List<Topic> CreateTopicList(List<HtmlNode> nodes)
        {
            
        }
    }
}
