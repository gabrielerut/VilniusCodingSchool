using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingSchool2021Tests.Page
{
    class FinalProjectLoginPage : BasePage
    {
        
        public const string PageAddressOpenLogin = "https://www.open24.lt/lt/mano-duomenys/mano-uzsakymai/";
        public FinalProjectLoginPage(IWebDriver webdriver) : base(webdriver)
        {
            driver.Url = PageAddressOpenLogin;
        }
        private IWebElement UserEmail => driver.FindElement(By.Id("login_email"));
        private IWebElement UserPassword => driver.FindElement(By.Id("login_password"));
        private IWebElement LogInButton => driver.FindElement(By.CssSelector("#login_form > button"));
        private IWebElement LogInResult => driver.FindElement(By.CssSelector("#content_layout_plain > div.tab_navs > ul > li.active > a"));
        private IWebElement LoyaltyButton => driver.FindElement(By.CssSelector("#content_layout_plain > div.tab_navs > ul > li:nth-child(3) > a"));
        private IWebElement LoyaltyButtonResult => driver.FindElement(By.CssSelector("#loyalty_points_history > div > h2"));
        public void InsertEmail(string text)
        {
            UserEmail.Clear();
            UserEmail.SendKeys(text);
        }
        public void InsertPassword(string text)
        {
            UserPassword.Clear();
            UserPassword.SendKeys(text);
        }
        public FinalProjectLoginPage InsertEmailAndPassword(string email, string password)
        {
            InsertEmail(email);
            InsertPassword(password);
            return this;
        }
        public FinalProjectLoginPage ClickLogInButton()
        {
            LogInButton.Click();
            return this;
        }
        public FinalProjectLoginPage CheckLogInResult(string expectedResultLogIn)
        {
            Assert.AreEqual(expectedResultLogIn, LogInResult.Text, "Log in failed");
            return this;
        }
        public FinalProjectLoginPage LoyaltyButtonClick()
        {
            LoyaltyButton.Click();
            return this;
        }
        public FinalProjectLoginPage CheckLoyaltyButtonResult(string expectedResultLoyalty)
        {
            Assert.AreEqual(expectedResultLoyalty, LoyaltyButtonResult.Text, "Not the loyalty page result");
            return this;
        }

    }
}

