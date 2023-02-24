using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.IO;

namespace project03console_v2
{
    class Program
    {
        static string url;
        static string country;
        static HtmlNode[] nodes;

        static string globalContainerXPath;
        static string globalCasesConfirmedXPath;
        static string globalDeathsXPath;

        static string localContainerXPath;
        static string localCasesConfirmedXPath;
        static string localDeathsXPath;

        static void Main(string[] args)
        {
            FillAttributes();
            bool userWantsToExit = false;

            do
            {
                Console.WriteLine("Provide country name, or press Enter for global results, or Q for exit.");
                country = Console.ReadLine();

                switch (country)
                {
                    case "":
                        nodes = NodeManager.CreateNodes(globalContainerXPath, url);
                        foreach (var node in nodes)
                        {
                            Fetcher.GetGlobalNumbers(node, globalCasesConfirmedXPath, globalDeathsXPath);
                        }
                        break;
                    case "Q":
                    case "q":
                        Console.WriteLine("BYE.");
                        userWantsToExit = true;
                        break;
                    default:
                        string generatedUrl = url + "+" + country;
                        nodes = NodeManager.CreateNodes(localContainerXPath, generatedUrl);
                        foreach (var node in nodes)
                        {
                            Fetcher.GetLocalNumbers(node, localCasesConfirmedXPath, localDeathsXPath, country);
                        }
                        break;
                }
            } while (!userWantsToExit);

            //try
            //{
            //    country = args[0];
            //    url += "+" + country;
            //    nodes = CreateNodes(localContainerXPath);
            //    foreach (var node in nodes)
            //    {
            //        GetLocalNumbers(node);
            //    }
            //}
            //catch (Exception)
            //{
            //    nodes = CreateNodes(globalContainerXPath);
            //    foreach (var node in nodes)
            //    {
            //        GetGlobalNumbers(node);
            //    }
            //}

            Console.ReadKey();
        }

        private static void FillAttributes()
        {
            string configFilePath = System.Configuration.ConfigurationManager.AppSettings["ConfigFilePath"];
            var configJson = File.ReadAllText(configFilePath);
            var config = JsonConvert.DeserializeObject<dynamic>(configJson);

            url = config.url;
            country = config.country;
            globalContainerXPath = config.globalContainerXPath;
            globalCasesConfirmedXPath = config.globalCasesConfirmedXPath;
            globalDeathsXPath = config.globalDeathsXPath;
            localContainerXPath = config.localContainerXPath;
            localCasesConfirmedXPath = config.localCasesConfirmedXPath;
            localDeathsXPath = config.localDeathsXPath;
        }
    }
}