using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testavimo_kursai_2021.Page
{
    public class DropDownPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private SelectElement DropDown => new SelectElement(driver.FindElement(By.CssSelector(".form-control")));
        private IWebElement ResultTextElement => driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement FirstSelectedButton => driver.FindElement(By.CssSelector(".btn .btn-primary"));
        private IWebElement GetAllSelectedButton => driver.FindElement(By.Id("printAll"));
        private SelectElement MultiDropDown => new SelectElement(driver.FindElement(By.Id("#multi-select")));
        public DropDownPage(IWebDriver webdriver) : base(webdriver)
        {
            driver.Url = PageAddress;
        }

        public DropDownPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropDownPage SelectFromDropdownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropDownPage ClickFirstSelectedButton()
        {
            FirstSelectedButton.Click();
            return this;
        }

        public DropDownPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropDownPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(FirstSelectedButton);
            action.Build().Perform();
            return this;
        }

        public DropDownPage VerifyResult(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }
    }
}
