using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdfdokudl_downloader.Classes
{
    internal class Parser
    {
        internal HtmlNodeCollection FindNodeByClass(ref HtmlDocument doc, params string[] classNames)
        {
            StringBuilder sb = new();

            foreach (string className in classNames)
            {
                sb.Append(className);
                sb.Append(' ');
            }

            sb.Remove(sb.Length - 1, 1);

            return doc.DocumentNode.SelectNodes($"//*[@class='{ sb }']");

        } 
    }
}
