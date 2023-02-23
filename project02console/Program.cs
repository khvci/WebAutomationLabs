using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project02console
{
    internal class Program
    {
        private static string dolarTitleXPath = "//div[@class='dovizBar mBot20']//a[1]//span[1]//span[1]";
        private static string dolarAlisXPath = "//div[@class='dovizBar mBot20']//a[1]//span[2]//span[2]";
        private static string dolarSatisXPath = "//div[@class='dovizBar mBot20']//a[1]//span[3]//span[2]";

        private static string euroTitleXPath = "//div[@class='dovizBar mBot20']//a[2]//span[1]//span[1]";
        private static string euroAlisXPath = "//div[@class='dovizBar mBot20']//a[2]//span[2]//span[2]";
        private static string euroSatisXPath = "//div[@class='dovizBar mBot20']//a[2]//span[3]//span[2]";

        private static string sterlinTitleXPath = "//div[@class='dovizBar mBot20']//a[3]//span[1]//span[1]";
        private static string sterlinAlisXPath = "//div[@class='dovizBar mBot20']//a[3]//span[2]//span[2]";
        private static string sterlinSatisXPath = "//div[@class='dovizBar mBot20']//a[3]//span[3]//span[2]";
        static void Main(string[] args)
        {
            List<BigPara> dovizler = new List<BigPara>();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://bigpara.hurriyet.com.tr/doviz/");

            var dolarTitle = doc.DocumentNode.SelectSingleNode(dolarTitleXPath).InnerText;
            var dolarAlis = doc.DocumentNode.SelectSingleNode(dolarAlisXPath).InnerText;
            var dolarSatis = doc.DocumentNode.SelectSingleNode(dolarSatisXPath).InnerText;

            var euroTitle = doc.DocumentNode.SelectSingleNode(euroTitleXPath).InnerText;
            var euroAlis = doc.DocumentNode.SelectSingleNode(euroAlisXPath).InnerText;
            var euroSatis = doc.DocumentNode.SelectSingleNode(euroSatisXPath).InnerText;

            var sterlinTitle = doc.DocumentNode.SelectSingleNode(sterlinTitleXPath).InnerText;
            var sterlinAlis = doc.DocumentNode.SelectSingleNode(sterlinAlisXPath).InnerText;
            var sterlinSatis = doc.DocumentNode.SelectSingleNode(sterlinSatisXPath).InnerText;

            dovizler.Add(new BigPara
            {
                AlisFiyat = dolarAlis,
                SatisFiyat = dolarSatis,
                DovizTur = dolarTitle,
            });

            dovizler.Add(new BigPara
            {
                AlisFiyat = euroAlis,
                SatisFiyat = euroSatis,
                DovizTur = euroTitle,
            });

            dovizler.Add(new BigPara
            {
                AlisFiyat = sterlinAlis,
                SatisFiyat = sterlinSatis,
                DovizTur = sterlinTitle,
            });

            foreach (var item in dovizler)
            {
                Console.WriteLine($"Doviz Tur: {item.DovizTur}, Alis: {item.AlisFiyat}, Satis: {item.SatisFiyat}");
            }
            Console.WriteLine("X!");
        }
    }
}
