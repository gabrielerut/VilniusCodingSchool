using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testavimo_kursai_2021.Page
{
    class Open24ChildrenSection : BasePage
    {
        public const string PageAddressChildren = "https://www.open24.lt/lt/katalogas/vaikams/";
        public Open24ChildrenSection(IWebDriver webdriver) : base(webdriver)
        {
            driver.Url = PageAddressChildren;
        }
        private IWebElement firstChosenItem => driver.FindElement(By.CssSelector("#p_list > div > div:nth-child(1) > a > span.thumb > span > picture > img"));
        private IWebElement chooseColor1 => driver.FindElement(By.CssSelector("#color_link_22376 > img.img-responsive.visible-md.visible-lg"));
        private IWebElement chooseSize1 => driver.FindElement(By.CssSelector("#product_sizes > div.products_list.hidden-xs.hidden-sm > div > a.dynamic.col-xs-3.col-md-2.size.active > span"));
        private IWebElement addToChartButton => driver.FindElement(By.CssSelector("#cart_add_form > button"));
        private IWebElement openChartButton => driver.FindElement(By.ClassName(".btn. btn-primary. btn-block"));
        private IWebElement chartResultFirstItemName => driver.FindElement(By.CssSelector("#cart_detailed_form > div > div > div.parcel_items > div > div > div.col.col-xs-8.info > a > span.name"));
        private IWebElement chartResultFirstItemPrice => driver.FindElement(By.CssSelector("#cart_detailed_form > div > div > div.parcel_items > div > div > div.col.col-xs-8.info > div.prices > span"));
        private IWebElement chartResultTotalPrice => driver.FindElement(By.ClassName(".main_price total"));
        private IWebElement firstItemPrice => driver.FindElement(By.CssSelector("#right_content > div.block.product_buy > div.row > div:nth-child(1) > div > span"));

        private IWebElement firstItemName => driver.FindElement(By.CssSelector("#right_content > h1"));
        public Open24ChildrenSection ClickFirstChosenItem()
        {
            firstChosenItem.Click();
            return this;
        }
        public Open24ChildrenSection ClickChosenColor1()
        {
            chooseColor1.Click();
            return this;
        }
        public Open24ChildrenSection ClickChosenSixe1()
        {
            chooseSize1.Click();
            return this;
        }
        public Open24ChildrenSection ClickAddToChartButton()
        {
            addToChartButton.Click();
            return this;
        }
        public Open24ChildrenSection ClickOpenChartButton()
        {
            openChartButton.Click();
            return this;
        }
        public Open24ChildrenSection VerifyFirstItemNameResult(string firstItemName)
        {
            Assert.IsTrue(firstItemName.Equals(chartResultFirstItemName.Text), $"Names do not match");
            return this;
        }
        public Open24ChildrenSection VerifyFirstItemPriceResult(string firstItemPrice)
        {
            Assert.IsTrue(firstItemPrice.Equals(chartResultFirstItemPrice.Text), $"Prices do not match");
            return this;
        }
        public Open24ChildrenSection VerifyTotalChartPriceResult(string totalChartResult)
        {
            Assert.IsTrue(totalChartResult.Equals(chartResultTotalPrice.Text), $"Total is incorrect");
            return this;
        }
    }
}
