using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilniusCodingSchool2021Tests.Page;

namespace VilniusCodingSchool2021Tests.Test
{
    class FinalProjectTest
    {
        private static FinalProjectLoginPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new FinalProjectLoginPage(driver);
            /*_page2 = new Open24Homepage(driver);
            _page3 = new Open24ChildrenSection(driver);*/
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }
        [TestCase("gabriele.rutkauske@gmail.com", "KodasTestui", "Mano užsakymai", TestName = "Test Valid LogIn")]
        public void TestValidLogIn(string email, string password, string result)
        {
            _page.InsertEmailAndPassword(email, password)
            .ClickLogInButton()
            .CheckLogInResult(result);
        }
        [TestCase("gabriele.rutkauske@gmail.com", "KodasTestui", "Lojalumo taškų istorija", TestName = "Test Loyalty button")]
        public void TestLoyaltybutton(string firstInput, string secondInput, string result)
        {
            _page.InsertEmailAndPassword(firstInput, secondInput)
            .ClickLogInButton()
            .LoyaltyButtonClick()
            .CheckLoyaltyButtonResult(result);
        }
    }
}
