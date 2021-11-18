using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilniusCodingSchool2021Tests.Drivers;
using VilniusCodingSchool2021Tests.Page;

namespace VilniusCodingSchool2021Tests.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static VoverytesAccountRegisterPage _accountRegisterPage;
        public static VoverytesButikasLoginPage _loginPage;
        public static VoverytesInsideChartPage _chartPage;
        public static VoverytesItemCompareChartPage _compareChartElementsPage;
        public static VoverytesMoreThan45EURPage _productOver45eurPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _accountRegisterPage = new VoverytesAccountRegisterPage(driver);
            _loginPage = new VoverytesButikasLoginPage(driver);
            _chartPage = new VoverytesInsideChartPage(driver);
            _compareChartElementsPage = new VoverytesItemCompareChartPage(driver);
            _productOver45eurPage = new VoverytesMoreThan45EURPage(driver);
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }

        /*[TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }*/





    }

}
    




