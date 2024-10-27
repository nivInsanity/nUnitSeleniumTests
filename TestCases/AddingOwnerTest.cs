using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;
using OpenQA.Selenium.Support.UI;
using myFirstNUnitTest.Base;
using myFirstNUnitTest.Pages;


namespace AddingOwnerTest.TestCases
{

    [TestFixture]
    public class AddingOwnerTest : BaseTest
    {
        private FindOwnersPage findOwnerPage;


        [SetUp]
        public new void Setup()
        {
            findOwnerPage = new FindOwnersPage(Driver);
        }

        [TearDown]
        public new void Teardown()
        {
            base.Teardown();
        }

        [Test]
        public void NunitSeleniumTest()
        {
            string firstName = "Bartolomeo";
            string lastName = "Chaffinch";
            string address = "Imagined 234/a";
            string city = "New York";
            string phoneNumber = "1234567890";

            findOwnerPage.AddOwner(firstName, lastName, address, city, phoneNumber);

            findOwnerPage.CheckOwner(firstName, lastName, address, city, phoneNumber);



        }
    }
}