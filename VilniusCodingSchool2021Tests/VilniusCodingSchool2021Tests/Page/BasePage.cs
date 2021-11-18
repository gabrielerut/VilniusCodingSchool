using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilniusCodingSchool2021Tests.Drivers;

namespace VilniusCodingSchool2021Tests.Page
{
    public class BasePage : CustomDriver
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
