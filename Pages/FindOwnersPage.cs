﻿using OpenQA.Selenium;
using myFirstNUnitTest.Base;
using myFirstNUnitTest.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;

namespace myFirstNUnitTest.Pages
{
    public class FindOwnersPage
    {
        private readonly ElementInteractions elementInteractions;

        #region Locators
        private readonly string btnFindOwnersLocator = "//a[@title='find owners']";
        private readonly string btnAddOwnerLocator = "//a[contains(text(), 'Add Owner')]";
        private readonly string inpAddOwnerLocator = "firstName";
        private readonly string inpLastNameLocator = "lastName";
        private readonly string inpAddressLocator = "address";
        private readonly string inpCityLocator = "city";
        private readonly string inpTelephoneLocator = "telephone";
        private readonly string btnScndAddOwnerLocator = "//button[contains(text(), 'Add Owner')]";
        private readonly string btnScndFindOwnersLocator = "//a[@title='find owners']";
        private readonly string btnFindOwnerLocator = "//button[contains(text(), 'Find')]";

        private readonly string fldNameLocator = "(//th[contains(text(),'Name')]/following::td)[1]";
        private readonly string fldAddressLocator = "(//th[contains(text(),'Address')]/following::td)[1]";
        private readonly string fldCityLocator = "(//th[contains(text(),'City')]/following::td)[1]";
        private readonly string fldTelephoneLocator = "(//th[contains(text(),'Telephone')]/following::td)[1]";

        private readonly string btnEditOwnerLocator = "//a[@class='btn btn-primary' and contains(text(), 'Edit')]";
        private readonly string btnAddNewPetLocator = "//a[@class='btn btn-primary' and contains(text(), 'Add')]";
        private readonly string inpPetName = "name";
        private readonly string inpBirthDate = "birthDate";
        private readonly string lstType = "type";
        private readonly string btnAddPet = "//button[@type='submit']";

        #endregion Locators

        public FindOwnersPage(IWebDriver driver)
        {
            this.elementInteractions = new ElementInteractions(driver);
        }

        public void AddOwner(string firstName, string lastName, string address, string city, string phoneNumber)
        {
            elementInteractions.ClickButton(btnFindOwnersLocator);
            elementInteractions.ClickButton(btnAddOwnerLocator);

            elementInteractions.FillInput(inpAddOwnerLocator, firstName);
            elementInteractions.FillInput(inpLastNameLocator, lastName);
            elementInteractions.FillInput(inpAddressLocator, address);
            elementInteractions.FillInput(inpCityLocator, city);
            elementInteractions.FillInput(inpTelephoneLocator, phoneNumber);

            elementInteractions.ClickButton(btnScndAddOwnerLocator);         

        }

        public void CheckOwner(string firstName, string lastName, string address, string city, string phoneNumber)
        {
            FindOwnerViaLastName(firstName, lastName);

            string fldNameText = elementInteractions.GetText(fldNameLocator);
            string fldAddressText = elementInteractions.GetText(fldAddressLocator);
            string fldCityText = elementInteractions.GetText(fldCityLocator);
            string fldTelephoneText = elementInteractions.GetText(fldTelephoneLocator);

            Assert.That(fldNameText, Is.EqualTo($"{firstName} {lastName}"));
            Assert.That(fldAddressText, Is.EqualTo(address));
            Assert.That(fldCityText, Is.EqualTo(city));
            Assert.That(fldTelephoneText, Is.EqualTo(phoneNumber));
        }

        public void FindOwnerViaLastName(string firstName, string lastName)
        {
            elementInteractions.ClickButton(btnScndFindOwnersLocator);
            elementInteractions.FillInput(inpLastNameLocator, lastName);
            elementInteractions.ClickButton(btnFindOwnerLocator);

            if (elementInteractions.IsElementPresent(By.XPath($"//a[contains(text(),'{firstName} {lastName}')]")))
            {
                elementInteractions.ClickButton($"//a[contains(text(),'{firstName} {lastName}')]");
            }
            else
            {
                Console.WriteLine("Element not found; skipping the click action.");
            }
        }

        public void AddPet(string petName, string birthDate, string animalType, string ownerName, string ownerLastname)
        {
            FindOwnerViaLastName(ownerName, ownerLastname);

            //TODO: finish method for pet adding
        }


    }
}
