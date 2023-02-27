using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Windows.Forms;

namespace project04sleniumwin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnRun.Click += BtnRun_Click;
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";

            Thread.Sleep(TimeSpan.FromSeconds(1));
            var acceptCookies = driver.FindElement(By.Id("W0wltc"));
            acceptCookies.Click();
            var searchBox = driver.FindElement(By.Name("q"));
            if (searchBox != null )
            {
                searchBox.SendKeys("khvci github");
                searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
        }
    }
}
