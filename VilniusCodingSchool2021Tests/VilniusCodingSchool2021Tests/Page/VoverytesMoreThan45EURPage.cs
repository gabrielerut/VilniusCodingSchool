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
    public class VoverytesMoreThan45EURPage : BasePage
    {
        public const string PageAddressOpenLogin = "https://www.voverytesbutikelis.lt/Drabuziu_kabykla_Tipi";
        public VoverytesMoreThan45EURPage(IWebDriver webdriver) : base(webdriver)
        {
            driver.Url = PageAddressOpenLogin;
        }
        private IWebElement OrderButton => driver.FindElement(By.Id("button-cart"));
        private IWebElement ChartTotalResultSamePage => driver.FindElement(By.Id("cart-total"));
        private IWebElement MiniChartTotalBox => driver.FindElement(By.CssSelector("#cart > div > ul > li:nth-child(2) > div"));
        private IWebElement ReviewChartButton => driver.FindElement(By.CssSelector("#cart > div > ul > li:nth-child(2) > div > p > a:nth-child(1)"));
        private IWebElement FinalBuyButton => driver.FindElement(By.CssSelector("#content > div > div.buttons > div.pull-right > a"));

        public VoverytesMoreThan45EURPage ClickAddToChart()
        {
            OrderButton.Click();
            return this;
        }
        public VoverytesMoreThan45EURPage GoToChartStep()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(ChartTotalResultSamePage).Perform();
            action.MoveToElement(MiniChartTotalBox).Perform();
            action.Build().Perform();
            ReviewChartButton.Click();
            return this;
        }
        public VoverytesMoreThan45EURPage ClickFinalBuyButtont()
        {
            FinalBuyButton.Click();
            return this;
        }
        public void BuyProductOver45eur()
        {
            ClickAddToChart();
            GoToChartStep();
            ClickFinalBuyButtont();
        }


    }
}
