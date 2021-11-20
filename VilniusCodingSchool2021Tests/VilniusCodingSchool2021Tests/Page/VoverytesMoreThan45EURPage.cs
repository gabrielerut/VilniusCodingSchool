using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VilniusCodingSchool2021Tests.Page
{
    public class VoverytesMoreThan45EURPage : BasePage
    {
        public const string PageAddressExpensiveItem = "https://www.voverytesbutikelis.lt/Drabuziu_kabykla_Tipi";
        public VoverytesMoreThan45EURPage(IWebDriver webdriver) : base(webdriver)
        { }
        public VoverytesMoreThan45EURPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressExpensiveItem)
                Driver.Url = PageAddressExpensiveItem;
            return this;
        }
        private IWebElement OrderButton => Driver.FindElement(By.Id("button-cart"));
        private IWebElement ChartTotalResultSamePage => Driver.FindElement(By.Id("cart-total"));
        private IWebElement MiniChartTotalBox => Driver.FindElement(By.CssSelector("#cart > div > ul > li:nth-child(2) > div"));
        private IWebElement ReviewChartButton => Driver.FindElement(By.CssSelector("#cart > div > ul > li:nth-child(2) > div > p > a:nth-child(1)"));
        private IWebElement FinalBuyButton => Driver.FindElement(By.CssSelector("#content > div > div.buttons > div.pull-right > a"));

        public VoverytesMoreThan45EURPage ClickAddToChart()
        {
            OrderButton.Click();
            return this;
        }
        public VoverytesMoreThan45EURPage GoToChartStep()
        {
            Thread.Sleep(300);
            Actions action = new Actions(Driver);
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
            Thread.Sleep(300);
            GoToChartStep();
            ClickFinalBuyButtont();
        }


    }
}
