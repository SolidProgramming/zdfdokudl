using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    internal static class PageHandler
    {
        internal static async Task<string> GetPageContent(string url)
        {
            using HttpClient client = new();

            return await client.GetStringAsync(url);
        }
    }
}
