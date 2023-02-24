using HtmlAgilityPack;
using project03console_v2.Helpers;
using System;
using System.Linq;

namespace project03console_v2
{
    class Program
    {
        static string url = "https://www.bing.com/search?q=coronavirus+statistics";
        static string country;
        static HtmlNode[] nodes;

        static string globalContainerXPath = "//*[@id=\"b_context\"]/li[1]/div/div[2]/div/div[1]/div[4]";
        static string globalCasesConfirmedXPath = "./div[2]/div/div[1]/div[1]/div[2]/div[1]";
        static string globalDeathsXPath = "./div[2]/div/div[1]/div[2]/div[2]/div[1]";

        static string localContainerXPath = "//*[@id=\"b_context\"]/li[1]/div/div[2]/div/div[1]/div[2]";
        static string localCasesConfirmedXPath = "./div[2]/div/div/div[1]/div[2]/div";
        static string localDeathsXPath = "./div[2]/div/div/div[2]/div[2]/div";
        
        static void Main(string[] args)
        {
            //country = "turkey";
            //url += "+" + country;
            //nodes = CreateNodes(localContainerXPath);
            //foreach (var node in nodes)
            //{
            //    GetLocalNumbers(node);
            //}


            try
            {
                country = args[0];
                url += "+" + country;
                nodes = CreateNodes(localContainerXPath);
                foreach (var node in nodes)
                {
                    GetLocalNumbers(node);
                }
            }
            catch (Exception)
            {
                nodes = CreateNodes(globalContainerXPath);
                foreach (var node in nodes)
                {
                    GetGlobalNumbers(node);
                }
            }

            Console.ReadKey();
        }

        private static HtmlNode[] CreateNodes(string path)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes(path).ToArray();
            return nodes;
        }

        private static void GetGlobalNumbers(HtmlNode node)
        {
            string globalCasesConfirmed = node.SelectSingleNode(globalCasesConfirmedXPath).InnerText.Clear();
            string globalDeaths = node.SelectSingleNode(globalDeathsXPath).InnerText.Clear();

            Console.WriteLine($"global cases (confirmed): {globalCasesConfirmed}, deaths: {globalDeaths}");
        }

        private static void GetLocalNumbers(HtmlNode node)
        {
            string localCasesConfirmed = node.SelectSingleNode(localCasesConfirmedXPath).InnerText.Clear();
            string localDeaths = node.SelectSingleNode(localDeathsXPath).InnerText.Clear();

            Console.WriteLine($"local cases for {country} (confirmed): {localCasesConfirmed}, deaths: {localDeaths}");
        }
    }
}