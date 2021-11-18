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
    class VoverytesLoginTest : BaseTest
    {

        [TestCase("g_survilaite@outlook.com", "KodasTestui", "REGISTRUOTI VARTOTOJĄ", TestName = "Test New User Registration Button")]
        public void TestNewUserRegisterButton(string email, string password, string result2)
        {
            _loginPage.InsertEmailAndPassword(email, password);
            _loginPage.ClickLoginButton()
            .ClickNewRegisterButton();
            _accountRegisterPage.CheckNewRegisterButtonResult(result2);
        }
        [TestCase("g_survilaite@outlook.com", "KodasTestui", "Įspėjimas: El. paštas ir/arba slaptažodis nerasti sistemoje.", TestName = "Test Valid LogIn")]
        public void TestValidLogIn(string email, string password, string result)
        {
            _loginPage.InsertEmailAndPassword(email, password);
            _loginPage.ClickLoginButton()
            .CheckLoginResult(result);
        }
        
        [TestCase("testouser", "TestoKodas", "123@gmail.com", "868686868", "Testo gatve", "Vilnius",  "Lithuania", "Vilnius", "Iveskite slaptazodi", TestName = "Test New User Registration Form")]
        public void TestNewUserRegistrationForm(string name, string lastName, string email, string phone, string adress, string city, string country, string region, string result )
        {
            _accountRegisterPage.InsertAllPersonalInfoWithNoPassword(name, lastName, email, phone, adress, city, country, region);
            _accountRegisterPage.CheckEmptyPasswordErrorResult(result);
        }

        [TestCase("1", "1 prekė(s) - 16.00€", TestName = "Test Correct Chart")]
        public void TestAddToChart(string quantity, string result1)
        {
            _compareChartElementsPage.SelectSize36Years()
            .SelectQuantityByValue(quantity)
            .ClickAddToChart()
            .CheckChartTotalResult(result1);

        }
        [TestCase("1", "Jūsų krepšelis tuščias!", TestName = "Test Remove from Chart")]
        public void TestRemoveFromChart(string quantity, string result2)
        {
            _compareChartElementsPage.BuyBrownChildrensCap(quantity);
            _chartPage.RemoveItemFromChart()
            .CheckEmptyChartResult(result2);
        }

        [TestCase("Paštomatas - 0.00€ ", TestName = "Check free shiping price for item over 45 eur")]
        public void TestFreeShipping(string result3)
        {
            _productOver45eurPage.BuyProductOver45eur();
            _checkoutPage.CheckFreeShipingResult(result3);
        }







    }
}
