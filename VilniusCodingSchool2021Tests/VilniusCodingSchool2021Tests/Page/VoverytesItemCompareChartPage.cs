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
    public class VoverytesItemCompareChartPage :BasePage
    {
        public const string PageAddressItemPage = "https://www.voverytesbutikelis.lt/pasipuosimui_ir_svarai/Wooly_organic_rudenine_kepure_su_ausytemis_Caramel";
        public const string ChartTotalResultOnPage = "1 prekė(s) - 16.00€";
        public VoverytesItemCompareChartPage(IWebDriver webdriver) : base(webdriver)
        { }
        public VoverytesItemCompareChartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressItemPage)
                Driver.Url = PageAddressItemPage;
            return this;
        }
        private IWebElement SelectSize1 => Driver.FindElement(By.CssSelector("#product > div.options.push-select.push-image.push-checkbox.push-radio > div > ul > li:nth-child(1) > span"));
        private IWebElement QuantityNumberBox => Driver.FindElement(By.CssSelector("#input-quantity"));
        private IWebElement AddToChart => Driver.FindElement(By.Id("button-cart"));
        private IWebElement ChartTotalResultOnSamePage => Driver.FindElement(By.Id("cart-total"));
        private IWebElement MiniChartTotalBox => Driver.FindElement(By.CssSelector("#cart > div > ul > li:nth-child(2) > div"));
        private IWebElement ReviewChartButton => Driver.FindElement(By.CssSelector("#cart > div > ul > li:nth-child(2) > div > p > a:nth-child(1)"));


        public VoverytesItemCompareChartPage SelectSize36Years()
        {
            SelectSize1.Click();
            return this;
        }
        public VoverytesItemCompareChartPage SelectQuantityByValue(string quantity)
        {
            Actions action = new Actions(Driver);
            action.DoubleClick(QuantityNumberBox).Perform();
            QuantityNumberBox.SendKeys(quantity);
            action.Build().Perform();
            return this;
        }

        public VoverytesItemCompareChartPage ClickAddToChart()
        {
            AddToChart.Click();
            Thread.Sleep(300);
            return this;
        }
        public void BuyBrownChildrensCap(string quantity)
        {
            SelectSize36Years();
            SelectQuantityByValue(quantity);
            ClickAddToChart();
            Thread.Sleep(300);
            GoToChartStep();
        }

        public VoverytesItemCompareChartPage GoToChartStep()
        {

            Actions action = new Actions(Driver);
            action.MoveToElement(ChartTotalResultOnSamePage).Perform();
            action.MoveToElement(MiniChartTotalBox).Perform();
            action.Build().Perform();
            ReviewChartButton.Click();
            return this;
        }

        public VoverytesItemCompareChartPage CheckChartTotalResult()
        {
            Assert.AreEqual(ChartTotalResultOnPage, ChartTotalResultOnSamePage.Text, "Total is not correct");
            return this;
        }


    }

}
