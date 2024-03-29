﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace zdfdokudl_downloader.Classes
{
    internal class ParserQueryBuilder
    {
        private List<HtmlNode> _nodes = new();

        /// <summary>
        ///     Return all resulting nodes from the list
        /// </summary>
        internal List<HtmlNode> Results => _nodes;

        /// <summary>
        ///     Returns only the first node result from the list
        /// </summary>
        internal HtmlNode Result => _nodes[0];

        internal ParserQueryBuilder Query(HtmlDocument doc)
        {
            _nodes.Add(doc.DocumentNode);

            return this;
        }
        internal ParserQueryBuilder Query(HtmlNode node)
        {
            _nodes.Add(node);

            return this;
        }
        internal ParserQueryBuilder Query(List<HtmlNode> nodes)
        {
            _nodes.AddRange(nodes);

            return this;
        }

        internal ParserQueryBuilder ById(string id)
        {
            string query = $".//*[@id='{ id }']";

            _nodes = GetNodesByQuery(query);

            return this;
        }
        internal ParserQueryBuilder ByElement(string elementName)
        {
            string query = ".//" + elementName;

            _nodes = GetNodesByQuery(query);

            return this;
        }
        internal ParserQueryBuilder ByClass(params string[] classNames)
        {
            StringBuilder _builder = new();

            foreach (string className in classNames)
            {
                _builder.Append(className);
                _builder.Append(' ');
            }

            _builder.Remove(_builder.Length - 1, 1);

            string query = $".//*[@class='{ _builder }']";

            _nodes = GetNodesByQuery(query);

            return this;
        }
        internal ParserQueryBuilder ByAttribute(params string[] attributeNames)
        {
            StringBuilder _builder = new();

            foreach (string className in attributeNames)
            {
                _builder.Append(className);
                _builder.Append(' ');
            }

            _builder.Remove(_builder.Length - 1, 1);

            string query = $".//*[@{ _builder }]";

            _nodes = GetNodesByQuery(query);

            return this;
        }
        internal ParserQueryBuilder ByAttributeValue(string attributeName, string attributeValue)
        {
            string query = $".//*[@{ attributeName }='{ attributeValue }']";

            _nodes = GetNodesByQuery(query);

            return this;
        }
        internal ParserQueryBuilder ByAttributeValues(string attributeName, List<string> attributeValues)
        {
            List<HtmlNode> filteredNodes = new();
            foreach (string attValue in attributeValues)
            {
                string query = $".//*[@{ attributeName }='{ attValue }']";

                filteredNodes.AddRange(GetNodesByQuery(query));
            }

            _nodes = filteredNodes;

            return this;
        }
        private List<HtmlNode> GetNodesByQuery(string query)
        {
            List<HtmlNode> nodes = new();

            for (int i = 0; i < _nodes?.Count; i++)
            {
                List<HtmlNode>? newNodes = _nodes[i].SelectNodes(query)?.ToList();

                if (newNodes is null) continue;

                nodes.AddRange(newNodes);
            }

            return nodes;
        }

    }
}
