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

        internal static async Task CreateTopicList()
        {
            string pageContent = await PageHandler.GetPageContent(Endpoint.DocuAndKnowledge);

            HtmlDocument htmlDocument = new();

            htmlDocument.LoadHtml(pageContent);

            List<HtmlNode> teaserNodes = GetAllTeaserNodes(htmlDocument);

            List<Teaser> teasers = await GetAllTeaser(teaserNodes);

        }
        internal static List<HtmlNode> GetAllTeaserNodes(HtmlDocument htmlDocument)
        {
            List<HtmlNode> teaserNodes = new();

            List<HtmlNode> articleNodes = new ParserQueryBuilder()
                .Query(htmlDocument)
                .ByElement("article")
                .Results;

            List<HtmlNode> normalLoadedNodes = new ParserQueryBuilder()
                 .Query(articleNodes)
                 .ByClass("b-cluster-teaser b-vertical-teaser js-teaser-extend cluster-teaser-new js-impression-track")
                 .Results;

            List<HtmlNode> lazyLoadedNodes = new ParserQueryBuilder()
                .Query(articleNodes)
                .ByClass("b-cluster-teaser m-placeholder lazyload")
                .Results;

            teaserNodes.AddRange(normalLoadedNodes);
            teaserNodes.AddRange(lazyLoadedNodes);

            return teaserNodes;
        }
        internal static async Task<List<Teaser>> GetAllTeaser(List<HtmlNode> teaserNodes)
        {
            List<Teaser> teasers = new();

            foreach (HtmlNode teaserNode in teaserNodes)
            {
                Teaser teaser = await GetTeaser(teaserNode);

                teasers.Add(teaser);
            }

            return teasers;
        }
        internal static async Task<Teaser> GetTeaser(HtmlNode teaserNode)
        {
            HtmlNode dataNode = new ParserQueryBuilder().Query(teaserNode).ByClass("teaser-title-link m-clickarea-action js-rb-autofocus js-track-click has-foot").Result;

            HtmlNode pictureNode = new ParserQueryBuilder().Query(teaserNode).ByClass("artdirect").ByElement("img").Result;

            Teaser teaser = new()
            {
                Title = dataNode.Attributes["title"].Value,
                Url = new()
                {
                    Site = dataNode.Attributes["href"].Value
                },
                DataTrack = JsonConvert.DeserializeObject<DataTrack>(dataNode.Attributes["data-track"].Value),
                Thumbnail = new()
                {
                    Url = pictureNode.Attributes["data-src"].Value
                }
            };

            string videoPageContent = await PageHandler.GetPageContent("https://www.zdf.de/uri/cfe0c7a7-7d80-4da2-9de6-c9c171dc4913");

            //HtmlNode videoNode = 

            return teaser;
        }



    }
}
