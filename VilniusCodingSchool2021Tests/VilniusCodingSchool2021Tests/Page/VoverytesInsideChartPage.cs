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
            driver.Url = PageAddressOpenLogin;
        }
        private IWebElement RemoveFromChartButton => driver.FindElement(By.CssSelector("#content > form > div > table > tbody > tr > td.text-left.quantity > div > span > button.btn.btn-danger"));
        private IWebElement EmptyChartResult => driver.FindElement(By.CssSelector("#content > p"));
        private IWebElement ShippingPriceResult => driver.FindElement(By.CssSelector("#content > div.extrow.account_option > div.extsm-8 > div:nth-child(2) > div:nth-child(1) > div > div > div > div.extpanel-body.delivery-method-content.ext-delivery-method > div:nth-child(5) > label"));

        
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
        public VoverytesInsideChartPage CheckFreeShipingResult(string expectedResulFree)
        {
            Assert.AreEqual(expectedResulFree, ShippingPriceResult.Text, "Shiping is not free");
            return this;
        }

    }
}
