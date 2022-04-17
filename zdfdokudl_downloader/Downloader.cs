global using HtmlAgilityPack;
global using zdfdokudl_downloader.Enums;
global using zdfdokudl_downloader.Classes;
global using zdfdokudl_downloader.Structs;
global using System.Web;
global using Newtonsoft.Json;


namespace zdfdokudl_downloader
{
    public class Downloader
    {
        public async Task Start()
        {
            ZDFHandler handler = new();

            await handler.CreateTopicList();
        }
    }
}