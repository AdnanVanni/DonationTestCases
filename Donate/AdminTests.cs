using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donate
{
    internal class AdminTests
    {
        private static IWebDriver dr;
        [SetUp]
        public void SetupDriverConfig()
        {
            var chromeOptions = new ChromeOptions();
            //  //chromeOptions.AddArgument(@"user-data-dir=C:\Users\adnan.ali\AppData\Local\Google\Chrome\User Data\Profile 1");// #Path to your chrome profile
            chromeOptions.DebuggerAddress = "localhost:1000";
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;

            dr = new ChromeDriver(@"C:\Users\adnan.ali\source\repos\Donate\Donate\", chromeOptions);

            dr.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);



        }
        [Test]
        public void CreateAndPreviewCampaign()
        {

            

        }
    }
}
