using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilniusCodingSchool2021Tests.Page
{
    public class VoverytesAccountRegisterPage : BasePage
    {

        public const string PageAddressAccountRegister = "https://www.voverytesbutikelis.lt/account-register";
        public const string RegisterResultText = "REGISTRUOTI VARTOTOJĄ";

        public VoverytesAccountRegisterPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddressAccountRegister;
        }
        public VoverytesAccountRegisterPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddressAccountRegister)
                Driver.Url = PageAddressAccountRegister;
            return this;
        }
        private IWebElement newRegisterResult => Driver.FindElement(By.CssSelector("#content > h1"));
        private IWebElement newUserName => Driver.FindElement(By.Id("input-firstname"));
        private IWebElement newUserLastName => Driver.FindElement(By.Id("input-lastname"));
        private IWebElement newUserEmail => Driver.FindElement(By.Id("input-email"));
        private IWebElement newUserPhone => Driver.FindElement(By.Id("input-telephone"));
        private IWebElement newUserAdress => Driver.FindElement(By.Id("input-address-1"));
        private IWebElement newUserCity => Driver.FindElement(By.Id("input-city"));
        private SelectElement dropDownCountry => new SelectElement(Driver.FindElement(By.Id("input-country")));

        private SelectElement dropDownRegion => new SelectElement(Driver.FindElement(By.Id("input-zone")));
        private IWebElement privacyCheckbox => Driver.FindElement(By.Id("#content > div > form > div > div > input[type=checkbox]:nth-child(2)"));
        private IWebElement newslettersCheckbox => Driver.FindElement(By.CssSelector("#content > div > form > fieldset:nth-child(7) > div > div > label:nth-child(2) > input[type=radio]"));
        private IWebElement continueRegistrationButton => Driver.FindElement(By.CssSelector("#content > div > form > div > div > input.btn.btn-primary.button"));
        private IWebElement emptyPasswordErrorResult => Driver.FindElement(By.Id("#content > div > form > fieldset:nth-child(5) > div.form-group.required.has-error > div > div"));

        public VoverytesAccountRegisterPage CheckNewRegisterButtonResult(string expectedRegisterButtonResul)
        {
            Assert.AreEqual(expectedRegisterButtonResul, newRegisterResult.Text, "User is not redirected to register page");
            return this;
        }
        public VoverytesAccountRegisterPage InsertName(string name)
        {
            newUserName.Clear();
            newUserName.SendKeys(name);
            return this;
        }

        public VoverytesAccountRegisterPage InsertLastname(string lastName)
        {
            newUserLastName.Clear();
            newUserLastName.SendKeys(lastName);
            return this;
        }
        public VoverytesAccountRegisterPage InsertEmail(string email)
        {
            newUserEmail.Clear();
            newUserEmail.SendKeys(email);
            return this;
        }
        public VoverytesAccountRegisterPage InsertPhone(string phone)
        {
            newUserPhone.Clear();
            newUserPhone.SendKeys(phone);
            return this;
        }
        public VoverytesAccountRegisterPage InsertAdress(string adress)
        {
            newUserAdress.Clear();
            newUserAdress.SendKeys(adress);
            return this;
        }
        public VoverytesAccountRegisterPage InsertCity(string city)
        {
            newUserCity.Clear();
            newUserCity.SendKeys(city);
            return this;
        }
        public void InsertAllPersonalInfoWithNoPassword(string name, string lastName, string email, string phone, string adress, string city, string country, string region)
        {
            InsertName(name);
            InsertLastname(lastName);
            InsertEmail(email);
            InsertPhone(phone);
            InsertAdress(adress);
            InsertCity(city);
            SelectFromDropdownCountry(country);
            SelectFromDropdownCity(region);
            CheckNewlettersCheckbox();
            CheckPrivacyCheckbox();
            ClickContinueRegistratonButton();
        }
        public VoverytesAccountRegisterPage SelectFromDropdownCountry(string country)
        {
            dropDownCountry.SelectByValue(country);
            return this;
        }
        public VoverytesAccountRegisterPage SelectFromDropdownCity(string region)
        {
            dropDownRegion.SelectByValue(region);
            return this;
        }
        public VoverytesAccountRegisterPage CheckNewlettersCheckbox()
        {
            if (!newslettersCheckbox.Selected)
                newslettersCheckbox.Click();
            return this;
        }
        public VoverytesAccountRegisterPage CheckPrivacyCheckbox()
        {
            if (!privacyCheckbox.Selected)
                privacyCheckbox.Click();
            return this;
        }
        public VoverytesAccountRegisterPage ClickContinueRegistratonButton()
        {
            continueRegistrationButton.Click();
            return this;
        }
        public VoverytesAccountRegisterPage CheckEmptyPasswordErrorResult(string expectedErrorResul)
        {
            Assert.AreEqual(expectedErrorResul, emptyPasswordErrorResult.Text, "No related error");
            return this;
        }


    }
}



