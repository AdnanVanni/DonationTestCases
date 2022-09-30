using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donate
{
    public class BasePageClass
    {
        
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait wait;

        public BasePageClass(IWebDriver driver)
        {

          
            Driver = driver;
            wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 100));
          
        }
       
    }
    
}
