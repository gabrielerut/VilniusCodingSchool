using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testavimo_kursai_2021.Page
{
    public class Open24Homepage : BasePage
    {
        public const string PageAddressOpenHomepage = "https://www.open24.lt/";
        private const string ReimaResultText = "REIMA (448)";
        public Open24Homepage(IWebDriver webdriver) : base(webdriver)
        {
            driver.Url = PageAddressOpenHomepage;
        }
        private IWebElement ReimaBanner => driver.FindElement(By.CssSelector("#desktop_banners_container > div:nth-child(1) > a"));
        private IWebElement ReimaBannerResult => driver.FindElement(By.CssSelector("#main_content > h1"));
        public Open24Homepage ClickReimaBanner()
        {
            ReimaBanner.Click();
            return this;
        }
        public Open24Homepage VerifyReimaBannerResult(string selectedBanner)
        {
            Assert.IsTrue(ReimaBannerResult.Text.Equals(ReimaResultText), $"Result is wrong, not Reima");
            return this;
        }
    }
}
