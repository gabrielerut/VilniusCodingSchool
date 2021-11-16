using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testavimo_kursai_2021.Page;

namespace Testavimo_kursai_2021.Test
{
    public class DropDownSeleniumTest
    {
        public class DropDownTest
        {
            private static DropDownPage _page;

            [OneTimeSetUp]
            public static void SetUp()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                _page = new DropDownPage(driver);
            }

            [OneTimeTearDown]

            public static void TearDown()
            {
                _page.CloseBrowser();
            }

            [Test]
            public void TestDropDown()
            {
                _page.SelectFromDropdownByValue("Friday")
                    .VerifyResult("Friday");
            }

            [Test]
            public void TestMultiDropDown()
            {
                _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
                    .ClickFirstSelectedButton();


            }
        }

    }
}
