using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donate
{
    internal class DonatePageObjects:BasePageClass
    {

        public DonatePageObjects(IWebDriver driver) : base(driver) { }
        #region
        public IWebElement Body => Driver.FindElement(By.TagName("body"));
        public By ContinuePaymentButton => By.XPath("//button[@data-steps='step-payment']");
        public IWebElement Amount250 =>  Driver.FindElement(By.XPath("//div[@data-paymentamount='250']"));
        public IWebElement Month => Driver.FindElement(By.Id("payment_card_expire_month"));
        public IWebElement Year => Driver.FindElement(By.Id("payment_card_expire_year"));
        public IWebElement CVV => Driver.FindElement(By.XPath("//input[@name='securityCode']"));
        public IWebElement Continue => Driver.FindElement(By.XPath(("//button[@data-steps='step-contact,call-to-action']")));
        public IWebElement FirstName => Driver.FindElement(By.Id("contact_first_name"));
        public IWebElement LastName => Driver.FindElement(By.Id("contact_last_name"));
        public IWebElement Email => Driver.FindElement(By.Id("contact_email"));
        public IWebElement Address => Driver.FindElement(By.Id("contact_address_line1"));
        public IWebElement Zip => Driver.FindElement(By.Id("contact_address_zip"));
        public IWebElement AddressLine => Driver.FindElement(By.Id("contact_address_line1"));
        public IWebElement AddressState => Driver.FindElement(By.Id("contact_address_state"));
        public IWebElement submit => Driver.FindElement(By.Id("submit_button"));

        public IWebElement CheckBoxFee => Driver.FindElement(By.Id("chk_add_process_fee"));
        public IWebElement CheckBoxEmployerMatch => Driver.FindElement(By.XPath("//label[@for='chk_add_process_fee']"));
        public IWebElement CheckBoxDedicate => Driver.FindElement(By.Id("chk_want_to_dedicate"));
        public IWebElement EmployerMatchTextBox => Driver.FindElement(By.Id("employer_name"));

        public By CCNumber => By.XPath("//input[@name='number']");
        public IWebElement monthlyFrequency => Driver.FindElement(By.Id("frequency_monthly"));
        public By Close => (By.XPath("//button[@title='Close']"));
            public IWebElement AmountReview => Driver.FindElement(By.Id("amount-review"));
       
         

        #endregion


        public bool IsVisible
        {
            get { return Driver.Title == "Donate Today | The American Cancer Society"; }
            private set { }
        }
        internal void CancelLoading()
        {
            Body.SendKeys(Keys.Escape); 
        }

        internal void AmountSelection()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(ContinuePaymentButton));
            Amount250.Click();
          
            
        }
        internal void MonthlyAmountSelection()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(ContinuePaymentButton));
            monthlyFrequency.Click();
           


        }
        internal void ServiceFee()
        {
            CheckBoxFee.Click();
        }
        internal void EmployerMatch()
        {
          // ExpectedConditions.ElementIsVisible(By.Id("employer_name"));
            CheckBoxEmployerMatch.Click();
            ExpectedConditions.ElementIsVisible(By.Id("employer_name"));
            EmployerMatchTextBox.Click();
            EmployerMatchTextBox.SendKeys("Microsoft");
            Driver.FindElement(By.XPath("//*[contains(text(),'Corporation')]")).Click();

        }






            internal void PaymentDetailsCard()
        {
            Driver.FindElement(ContinuePaymentButton).Click();
            Driver.SwitchTo().Frame(0);
            wait.Until(ExpectedConditions.ElementIsVisible(CCNumber));//Credit Card Number which is in iframe

            Driver.FindElement(CCNumber).Click();
            Driver.FindElement(CCNumber).SendKeys("4111111111111111");
            Driver.SwitchTo().DefaultContent();
            Month.Click();
            Month.SendKeys("02");
            Year.SendKeys("2023");

            Driver.SwitchTo().Frame(1);
            CVV.Click();
            CVV.SendKeys("123");
            Driver.SwitchTo().DefaultContent();
            Continue.Click();
        }
        internal void PersonalDetails()
        {
            FirstName.Click();
            FirstName.SendKeys("Yash");
            LastName.Click();
            LastName.SendKeys("Raj");
            Email.Click();
            Email.SendKeys("adnanali@cancer.org");
            Address.Click();
            Address.SendKeys("247 G 3 Ln");
            AddressState.SendKeys("a");
            //  dr.FindElement(By.XPath("//class[contains(text(),'Te Lo Ca Dr, Campton NH')]")).Click();
            Zip.Clear();
            Zip.SendKeys("01547");
            //AddressLine.SendKeys(Keys.Tab);

        }
        internal void SubmitAndVerifyDonationReceipt(General.SelectedValue val)
        {
            AmountReview.Click();
            submit.Click();

            System.Threading.Thread.Sleep(50000);
           
            if (val ==General.SelectedValue.OneTime)
            Assert.IsTrue(Driver.FindElement(By.XPath("//*[contains(text(),'Your one time tax-deductible donation of $250')]")).Displayed);
            if (val == General.SelectedValue.Monthly)
                Assert.IsTrue(Driver.FindElement(By.XPath("//*[contains(text(),'Your monthly tax-deductible donation of $25')]")).Displayed);

        }


        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://qa.donate.cancer.org/");
            //wait.Until(ExpectedConditions.ElementIsVisible(Close));
            //Driver.FindElement(Close).Click();
            Assert.IsTrue(IsVisible,
                $"Sample application page was not visible. Expected=>{"Donate Today | The American Cancer Society"}." +
                $"Actual=>{Driver.Title}");
           
        }
 
    }
}
