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
        public static IWebDriver Driver;
        public static VoverytesAccountRegisterPage _accountRegisterPage;
        public static VoverytesButikasLoginPage _loginPage;
        public static VoverytesInsideChartPage _chartPage;
        public static VoverytesItemCompareChartPage _compareChartElementsPage;
        public static VoverytesMoreThan45EURPage _productOver45eurPage;
        public static CheckOutPageAndShipping _checkoutPage;


        [OneTimeSetUp]
        public static void SetUp()
        {
            Driver = CustomDriver.GetChromeDriver();
            _accountRegisterPage = new VoverytesAccountRegisterPage(Driver);
            _loginPage = new VoverytesButikasLoginPage(Driver);
            _chartPage = new VoverytesInsideChartPage(Driver);
            _compareChartElementsPage = new VoverytesItemCompareChartPage(Driver);
            _productOver45eurPage = new VoverytesMoreThan45EURPage(Driver);
            _checkoutPage = new CheckOutPageAndShipping(Driver);
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            //Driver.Quit();
        }

        /*[TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }*/





    }

}
    




