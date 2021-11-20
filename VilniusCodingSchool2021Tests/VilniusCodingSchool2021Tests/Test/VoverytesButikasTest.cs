using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilniusCodingSchool2021Tests.Drivers;
using VilniusCodingSchool2021Tests.Page;

namespace VilniusCodingSchool2021Tests.Test
{
        public class VoverytesButikasTest : BaseTest
        {

            [TestCase("REGISTRUOTI VARTOTOJĄ", TestName = "Test New User Registration Button")]
            public void TestNewUserRegisterButton(string result2)
            {
                _loginPage.NavigateToDefaultPage();
                _loginPage.ClickNewRegisterButton();
                _accountRegisterPage.CheckNewRegisterButtonResult(result2);
            }
            [TestCase("g_survilaite@outlook.com", "KodasTestui", TestName = "Test LogIn")]
            public void TestLogIn(string email, string password)
            {
                _loginPage.NavigateToDefaultPage();
                _loginPage.InsertEmailAndPassword(email, password);
                _loginPage.ClickLoginButton()
                .CheckLoginResult();
            }

            [TestCase("testouser", "TestoKodas", "123@gmail.com", "868686868", "Testo gatve", "Vilnius", "Slaptažodis turi būti nuo 3 iki 20 simbolių ilgio!", TestName = "Test New User Registration Form")]
            public void TestNewUserRegistrationForm(string name, string lastName, string email, string phone, string adress, string city, string result)
            {
                _accountRegisterPage.NavigateToDefaultPage()
                .InsertAllPersonalInfoWithNoPassword(name, lastName, email, phone, adress, city);
                string Lithuania = "Lithuania";
                string Vilnius = "Vilnius";
                _accountRegisterPage.SelectFromDropdownCountry(Lithuania)
                .SelectFromDropdownCity(Vilnius)
                .CheckNewlettersCheckbox()
                .CheckPrivacyCheckbox()
                .ClickContinueRegistratonButton()
                .CheckEmptyPasswordErrorResult(result);
            }

            [TestCase("1", TestName = "Test Correct Chart")]
            public void TestAddToChart(string quantity)
            {
                _compareChartElementsPage.NavigateToDefaultPage();
                _compareChartElementsPage.SelectSize36Years()
                .SelectQuantityByValue(quantity)
                .ClickAddToChart()
                .CheckChartTotalResult();

            }
            [TestCase("1", "Jūsų krepšelis tuščias!", TestName = "Test Remove from Chart")]
            public void TestRemoveFromChart(string quantity, string result2)
            {
                _compareChartElementsPage.NavigateToDefaultPage();
                _compareChartElementsPage.BuyBrownChildrensCap(quantity);
                _chartPage.RemoveItemFromChart()
                .CheckEmptyChartResult(result2);
            }

            [TestCase("Paštomatas - 0.00€", TestName = "Check free shiping price for item over 45 eur")]
            public void TestFreeShipping(string result3)
            {
                _productOver45eurPage.NavigateToDefaultPage();
                _productOver45eurPage.BuyProductOver45eur();
                _checkoutPage.CheckFreeShipingResult(result3);
            }







        }
}
