using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingSchool2021Tests.Page
{
    public class CheckOutPageAndShipping : BasePage
    {
        public const string PageAddressFinalCheckout = "https://www.voverytesbutikelis.lt/index.php?route=onepagecheckout/checkout";

        public CheckOutPageAndShipping(IWebDriver webdriver) : base(webdriver)
        {}
        public CheckOutPageAndShipping NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressFinalCheckout)
                Driver.Url = PageAddressFinalCheckout;
            return this;
        }

        private IWebElement ShippingPriceResult => Driver.FindElement(By.CssSelector("#content > div.extrow.account_option > div.extsm-8 > div:nth-child(2) > div:nth-child(1) > div > div > div > div.extpanel-body.delivery-method-content.ext-delivery-method > div:nth-child(5) > label"));
        public CheckOutPageAndShipping CheckFreeShipingResult(string expectedResulFree)
        {
            Assert.AreEqual(expectedResulFree, ShippingPriceResult.Text, "Shiping is not free");
            return this;
        }


    }
}
