using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingSchool2021Tests.Page
{
    public class VoverytesInsideChartPage : BasePage
    {
        public const string PageAddressOpenLogin = "https://www.voverytesbutikelis.lt/cart";

        public VoverytesInsideChartPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddressOpenLogin;
        }
        private IWebElement RemoveFromChartButton => Driver.FindElement(By.CssSelector("#content > form > div > table > tbody > tr > td.text-left.quantity > div > span > button.btn.btn-danger"));
        private IWebElement EmptyChartResult => Driver.FindElement(By.CssSelector("#content > p"));
 
        public VoverytesInsideChartPage RemoveItemFromChart()
        {
            RemoveFromChartButton.Click();
            return this;
        }
        public VoverytesInsideChartPage CheckEmptyChartResult(string expectedResultEmpty)
        {
            Assert.AreEqual(expectedResultEmpty, EmptyChartResult.Text, "Log in failed");
            return this;
        }
        

    }
}
