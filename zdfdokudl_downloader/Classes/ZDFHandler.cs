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

            var nodes = new ParserQueryBuilder()
                .Query(ref htmlDocument)
                .ByClass("sb-page") 
                .ByAttributeValues("data-node-id", new() { "08c2f76b-4cc5-44bf-b2ad-d1f1e173cebd", "27d082ef-707c-4133-94cb-3410c9efd0ef" })
                .Result;  


            return null;
        }
        internal static List<Topic> CreateTopicList(HtmlNodeCollection unfilteredTopicNodes)
        {
            List<Topic> topicList = new();

            for (int i = 0; i < unfilteredTopicNodes.Count; i++)
            {
                Topic topic = GetTopic(ref unfilteredTopicNodes, i);

                topicList.Add(topic);
            }

            return topicList;
        }
        internal static Topic GetTopic(ref HtmlNodeCollection topicNodes, int index)
        {
            return new()
            {
                Title = topicNodes[index].SelectSingleNode(".//*[@class='js-rb-live cluster-title']").InnerText
            };
        }
    }
}
