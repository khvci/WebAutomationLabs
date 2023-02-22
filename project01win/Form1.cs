using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project01win
{
    public partial class Form1 : Form
    {
        HtmlWeb htmlWeb = new HtmlWeb();
        public Form1()
        {
            InitializeComponent();
            btnGetData.Click += btnGetData_Click;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtWebSite.Text = "https://www.haberler.com/son-dakika/";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var doc = htmlWeb.Load(txtWebSite.Text);
            
            var newsList = new List<News>();
            HtmlNodeCollection hblColls = doc.DocumentNode.SelectNodes("//div[@class='hblnBox']");
            foreach (var hbl in hblColls)
            {
                string newsTime = hbl.SelectSingleNode("//div[@class='hblnTime']").InnerText;
                string newsImage = hbl.SelectSingleNode("//div/a/img/[@class='hblnTime']").InnerText;
                string newsTitle = hbl.SelectSingleNode("//div[@class='hblnContent']").InnerText;

                newsList.Add(new News()
                {
                    Title = newsTime
                });
                lstData.Items.Add(newsImage);
            }
        }
    }
}
