using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project01win_example
{
    public partial class Form1 : Form
    {
        List<News> newsList;
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
        }
    }
}
