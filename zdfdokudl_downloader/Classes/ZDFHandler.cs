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
        private static Task<string>? _BearerToken;
        private static Task<string> BearerToken
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
        }

        private static Task<PlayerConfiguration?>? _PlayerConfiguraion;
        private static Task<PlayerConfiguration?> PlayerConfiguration
        {
            get
            {
                if (_PlayerConfiguraion is null)
                {
                    _PlayerConfiguraion = GetPlayerConfiguration();

                    return _PlayerConfiguraion;
                }

                return _PlayerConfiguraion;
            }
        }


        private static async Task<string> GetBearerToken()
        {
            string pageContent = await PageHandler.GetPageContent(Endpoint.Base);

            string token = Regex.Match(pageContent, "apiToken: '([a-z0-9]{40})'").Groups[1].Value;

            return token;
        }
        private static async Task<PlayerConfiguration?> GetPlayerConfiguration()
        {
            string pageContent = await PageHandler.GetPageContent(Endpoint.Configuration);

            PlayerConfiguration? configuration = JsonConvert.DeserializeObject<PlayerConfiguration>(pageContent);

            return configuration;
        }
        internal static async Task CreateTopicList()
        {
            string? pageContent = await PageHandler.GetPageContent(Endpoint.DocuAndKnowledge);

            HtmlDocument htmlDocument = new();

            htmlDocument.LoadHtml(pageContent);

            List<HtmlNode> teaserNodes = GetAllTeaserNodes(htmlDocument);

            List<ZDFTeaser> teasers = await GetAllTeaser(teaserNodes);

        }
        private static List<HtmlNode> GetAllTeaserNodes(HtmlDocument htmlDocument)
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
        private static async Task<List<ZDFTeaser>> GetAllTeaser(List<HtmlNode> teaserNodes)
        {
            List<ZDFTeaser> teasers = new();

            foreach (HtmlNode teaserNode in teaserNodes)
            {
                ZDFTeaser? teaser = await GetTeaser(teaserNode);

                if (teaser is null) continue;

                teasers.Add(teaser);
            }

            return teasers;
        }
        private static async Task<ZDFTeaser?> GetTeaser(HtmlNode teaserNode)
        {
            HtmlNode dataNode = new ParserQueryBuilder().Query(teaserNode).ByElement("a").Result;
            dataNode.Attributes["data-track"].Value = HttpUtility.HtmlDecode(dataNode.Attributes["data-track"].Value);

            HtmlNode pictureNode = new ParserQueryBuilder().Query(teaserNode).ByClass("artdirect").ByElement("img").Result;

            ZDFTeaser teaser = new()
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

            string? playerMainVideoContentUrl = await GetPlayerMainVideoContentUrl(teaser);

            if (playerMainVideoContentUrl is null) return null;

            PlayerConfiguration? playerConfiguration = await PlayerConfiguration;

            if (playerConfiguration is null) return null;

            playerMainVideoContentUrl = playerMainVideoContentUrl.Replace("{playerId}", playerConfiguration.ptmdPlayerId);

            string? mainContentVideoUrl = await GetMainContentVideoUrl(Endpoint.ApiBase + playerMainVideoContentUrl);

            if (mainContentVideoUrl is null) return null;

            teaser.Url.Video = mainContentVideoUrl;

            return teaser;
        }
        private static async Task<string?> GetPlayerMainVideoContentUrl(ZDFTeaser teaser)
        {
            using HttpClient httpclient = new();

            httpclient.DefaultRequestHeaders.Add("Api-Auth", $"Bearer { await BearerToken }");

            HttpResponseMessage response = await httpclient.GetAsync($"{Endpoint.ApiBase}/content/documents/{teaser.Url.ShortUrl}.json?profile=player");

            if (response.StatusCode != HttpStatusCode.OK) return null;

            string stringResult = await response.Content.ReadAsStringAsync();

            PlayerResponse? playerResponse = JsonConvert.DeserializeObject<PlayerResponse?>(stringResult);

            if (playerResponse is null || playerResponse.mainVideoContent is null) return null;

            return playerResponse.mainVideoContent.HttpZdfDeRelsTarget.HttpZdfDeRelsStreamsPtmdTemplate;
        }
        private static async Task<string?> GetMainContentVideoUrl(string playerMainVideoContentUrl)
        {
            using HttpClient httpclient = new();

            httpclient.DefaultRequestHeaders.Add("Api-Auth", $"Bearer { await BearerToken }");

            HttpResponseMessage response = await httpclient.GetAsync(playerMainVideoContentUrl);

            if (response.StatusCode != HttpStatusCode.OK) return null;

            string stringResult = await response.Content.ReadAsStringAsync();

            ZDFMainContentVideoResponse? contentVideoResponse = JsonConvert.DeserializeObject<ZDFMainContentVideoResponse>(stringResult);

            if (contentVideoResponse is null) return null;

            return contentVideoResponse.priorityList[0].formitaeten[0].qualities[0].audio.tracks[0].uri;
        }

    }
}
