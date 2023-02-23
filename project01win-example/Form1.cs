using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project01win_example
{
    public partial class Form1 : Form
    {
        List<News> newsList;
        HtmlWeb htmlWeb;
        HtmlNodeCollection nodes;

        public Form1()
        {
            InitializeComponent();
            btnGetData.Click += btnGetData_Click;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtWebsite.Text = "https://www.businessinsider.de/";
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            newsList = new List<News>();
            htmlWeb = new HtmlWeb();
            htmlWeb.Load(txtWebsite.Text);
            var doc = htmlWeb.Load(txtWebsite.Text);
            nodes = doc.DocumentNode.SelectNodes("//div[@class='article - grid article - grid--2 - columns']");
            
            foreach (var node in nodes)
            {
                string newsTitle = node.SelectSingleNode("//div[@class='teaser-post__link']").InnerText;
               

                newsList.Add(new News()
                {
                    Title = newsTitle
                });
                lstData.Items.Add(newsTitle);
            }
        }
    }
}
