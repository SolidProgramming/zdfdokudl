using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    internal class ZDFHandler
    {
        private Task<string>? _BearerToken;
        public Task<string> BearerToken
        {
            get
            {
                if (_BearerToken is null)
                {
                    _BearerToken = GetBearerToken();
                    return _BearerToken;                   
                }

                return _BearerToken;
            }
            set
            {
                _BearerToken = value;
            }
        }

        private async Task<string> GetBearerToken()
        {
            string pageContent = await PageHandler.GetPageContent(Endpoint.Base);

            string token = Regex.Match(pageContent, "apiToken: '([a-z0-9]{40})'").Groups[1].Value;

            return token;
        }
        internal async Task CreateTopicList()
        {
            string? pageContent = await PageHandler.GetPageContent(Endpoint.DocuAndKnowledge);

            HtmlDocument htmlDocument = new();

            htmlDocument.LoadHtml(pageContent);

            List<HtmlNode> teaserNodes = GetAllTeaserNodes(htmlDocument);

            List<Teaser> teasers = await GetAllTeaser(teaserNodes);

        }
        internal List<HtmlNode> GetAllTeaserNodes(HtmlDocument htmlDocument)
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
        internal async Task<List<Teaser>> GetAllTeaser(List<HtmlNode> teaserNodes)
        {
            List<Teaser> teasers = new();

            foreach (HtmlNode teaserNode in teaserNodes)
            {
                Teaser? teaser = await GetTeaser(teaserNode);

                if (teaser is null) continue;

                teasers.Add(teaser);
            }

            return teasers;
        }
        internal async Task<Teaser?> GetTeaser(HtmlNode teaserNode)
        {
            HtmlNode dataNode = new ParserQueryBuilder().Query(teaserNode).ByElement("a").Result;
            dataNode.Attributes["data-track"].Value = HttpUtility.HtmlDecode(dataNode.Attributes["data-track"].Value);

            HtmlNode pictureNode = new ParserQueryBuilder().Query(teaserNode).ByClass("artdirect").ByElement("img").Result;

            Teaser teaser = new()
            {
                Title = dataNode.Attributes["title"].Value,
                Url = new()
                {
                    Site = dataNode.Attributes["href"].Value,
                    ShortUrl = dataNode.Attributes["data-target-id"].Value,
                },
                DataTrack = JsonConvert.DeserializeObject<DataTrack>(dataNode.Attributes["data-track"].Value),
                Thumbnail = new()
                {
                    Url = pictureNode.Attributes["data-src"].Value
                }
            };           

            using HttpClient httpclient = new();

            httpclient.DefaultRequestHeaders.Add("Api-Auth", $"Bearer { await BearerToken }");


            HttpResponseMessage response = await httpclient.GetAsync($"{Endpoint.ApiBase}/content/documents/{teaser.Url.ShortUrl}.json?profile=player");
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();

          
                return teaser;
        }

      

    }
}
