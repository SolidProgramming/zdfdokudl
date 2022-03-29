global using HtmlAgilityPack;
global using zdfdokudl_downloader.Enums;
global using zdfdokudl_downloader.Classes;
global using zdfdokudl_downloader.Structs;
global using System.Web;


namespace zdfdokudl_downloader
{
    public class Downloader
    {
        public async Task Start()
        {
            await ZDFHandler.CreateTopicList();
        }
    }
}