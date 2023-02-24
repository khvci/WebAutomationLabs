using HtmlAgilityPack;
using System.Linq;

namespace project03console_v2
{
    public static class NodeManager
    {
        public static HtmlNode[] CreateNodes(string path, string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes(path).ToArray();
            return nodes;
        }
    }
}