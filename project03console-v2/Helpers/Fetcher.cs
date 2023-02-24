using HtmlAgilityPack;
using project03console_v2.Helpers;
using System;

namespace project03console_v2
{
    static class Fetcher
    {

        public static void GetGlobalNumbers(HtmlNode node, string globalCasesConfirmedXPath, string globalDeathsXPath)
        {
            string globalCasesConfirmed = node.SelectSingleNode(globalCasesConfirmedXPath).InnerText.Clear();
            string globalDeaths = node.SelectSingleNode(globalDeathsXPath).InnerText.Clear();

            Console.WriteLine($"GLOBAL cases (confirmed): {globalCasesConfirmed}, deaths: {globalDeaths}\n");
        }

        public static void GetLocalNumbers(HtmlNode node, string localCasesConfirmedXPath, string localDeathsXPath, string country)
        {
            string localCasesConfirmed = node.SelectSingleNode(localCasesConfirmedXPath).InnerText.Clear();
            string localDeaths = node.SelectSingleNode(localDeathsXPath).InnerText.Clear();

            Console.WriteLine($"Local cases for {country.ToUpper()} (confirmed): {localCasesConfirmed}, deaths: {localDeaths}\n");
        }
    }
}