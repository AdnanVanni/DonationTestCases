
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using NUnit;


namespace Donate
{
    [TestFixture]
    
    public class DonateTests
    {
        private static IWebDriver dr;
        

        [SetUp]
        public void SetupDriverConfig()
        {
            ChromeOptions options = new ChromeOptions();
            
            options.AddArgument("no-sandbox");

            //ChromeDriver drv = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            



           // var chromeOptions = new ChromeOptions();
         
           // chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;


            //this three argument line solved the issue and takes timespan as well.
            dr = new ChromeDriver(@"C:\Users\adnan.ali\source\repos\Donate\Donate\TestDriver", options, TimeSpan.FromMinutes(3));
           // dr.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));

            
            
            




        }
        [Test]
   
        public void Verify()
        {

            DonatePageObjects PO = new DonatePageObjects(dr);
          
            try
            {
               
             PO.GoTo();

            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(5000);
            }


            PO.AmountSelection();
            Screenshot ss = ((ITakesScreenshot)dr).GetScreenshot();
            ss.SaveAsFile("Image1.png", ScreenshotImageFormat.Png);
            PO.PaymentDetailsCard();
            PO.PersonalDetails();
            PO.SubmitAndVerifyDonationReceipt(General.SelectedValue.OneTime);

            Screenshot ss1 = ((ITakesScreenshot)dr).GetScreenshot();
            ss1.SaveAsFile("Image2.png",ScreenshotImageFormat.Png);

        }
        [Test]
  
        public void VerifyMonthlyPayment()
         {
            DonatePageObjects PO = new DonatePageObjects(dr);
            try
            {
                PO.GoTo();

                                                                                                                                                                                                                        }
            catch (WebDriverException e)
            {
                PO.CancelLoading();
            }

            PO.MonthlyAmountSelection();
            PO.PaymentDetailsCard();
            PO.PersonalDetails();
            PO.SubmitAndVerifyDonationReceipt(General.SelectedValue.Monthly);
        }
        [Test]

        public void VerifyMonthlyPaymentAgain()
        {
            DonatePageObjects PO = new DonatePageObjects(dr);
            try
            {
                PO.GoTo();

            }
            catch (WebDriverException e)
            {
                PO.CancelLoading();
            }

            PO.MonthlyAmountSelection();
            PO.EmployerMatch();
            PO.PaymentDetailsCard();
            PO.PersonalDetails();
            PO.SubmitAndVerifyDonationReceipt(General.SelectedValue.Monthly);
        }
            //[Test]
            //public void VerifyAdmin()
            //{



            //    try
            //    {
            //        dr.Navigate().GoToUrl("https://donateadminqa.azurewebsites.net/");

            //    }
            //    catch (WebDriverTimeoutException e)
            //    {

            //    }




            // }
            [TearDown]
        public void Finish()
        {
           dr.Close();  
            dr.Quit();  

        }
    }
}
