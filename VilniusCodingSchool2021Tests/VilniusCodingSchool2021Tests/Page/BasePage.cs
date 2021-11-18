using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilniusCodingSchool2021Tests.Drivers;

namespace VilniusCodingSchool2021Tests.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void CloseBrowser()
        {
            //Driver.Quit();
        }
    }

}
