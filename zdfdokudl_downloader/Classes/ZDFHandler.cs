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
        //thumbnail small     https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=240x270
        //thumbnail big       https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=640x720
        //thumbnail wide      https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=384x216 
        //thumbnail wallpaper https://epg-image.zdf.de/fotobase-webdelivery/images/7cdd8c5f-414a-4e58-8b1c-5b40ed153ec9?layout=2400x1350

        internal static async Task CreateTopicList()
        {
            string pageContent = await PageHandler.GetPageContent(Endpoint.DocuAndKnowledge);

            HtmlDocument htmlDocument = new();

            htmlDocument.LoadHtml(pageContent);         

            List<HtmlNode> teaserNodes = GetAllTeaserNodes(htmlDocument);

            List<Teaser> teasers = GetAllTeaser(teaserNodes);

        }
        internal static List<HtmlNode> GetAllTeaserNodes(HtmlDocument htmlDocument)
        {
            List<HtmlNode> teaserNodes = new();

            List<HtmlNode> articleNodes = new ParserQueryBuilder()
                .Query(htmlDocument)
                .ByElement("article")                
                .Result;

            List<HtmlNode> normalLoadedNodes = new ParserQueryBuilder()
                 .Query(articleNodes)
                 .ByClass("b-cluster-teaser b-vertical-teaser js-teaser-extend cluster-teaser-new js-impression-track")
                 .Result;

            List<HtmlNode> lazyLoadedNodes = new ParserQueryBuilder()
                .Query(articleNodes)
                .ByClass("b-cluster-teaser m-placeholder lazyload")
                .Result;

            teaserNodes.AddRange(normalLoadedNodes);
            teaserNodes.AddRange(lazyLoadedNodes);

            return teaserNodes;
        }
        internal static List<Teaser> GetAllTeaser(List<HtmlNode> teaserNodes)
        {
            List<Teaser> teasers = new();

            foreach (HtmlNode teaserNode in teaserNodes)
            {
                Teaser teaser = GetTeaser(teaserNode);

                teasers.Add(teaser);
            }

            return teasers;
        }
        internal static Teaser GetTeaser(HtmlNode teaserNode)
        {
            Teaser teaser = new()
            {
                 
            };

            return new();
        }

    }
}
