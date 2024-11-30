using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;
using OpenQA.Selenium.Support.UI;
using myFirstNUnitTest.Base;
using myFirstNUnitTest.Pages;
using PetClinicTestAutomation.TestData;


namespace AddingOwnerTest.TestCases {

    [TestFixture]
    public class AddingOwnerTest : BaseTest {
        private FindOwnersPage findOwnerPage;


        [SetUp]
        public new void Setup() {
            findOwnerPage = new FindOwnersPage(Driver);
        }

        [TearDown]
        public new void Teardown() {
            base.Teardown();
        }

        [Test]
        [Order(1)]
        public void AddOwnerTest() {

            var owner = PeopleData.Bartolomeo;

            findOwnerPage.AddOwner(owner.firstName,
                                   owner.lastName,
                                   owner.address,
                                   owner.city,
                                   owner.phoneNumber);

            findOwnerPage.CheckOwner(owner.firstName,
                                     owner.lastName,
                                     owner.address,
                                     owner.city,
                                     owner.phoneNumber);
        }

        [Test]
        [Order(2)]
        public void AddAnimalTest() {
            var dog = AnimalData.Dog;
            var owner = PeopleData.Bartolomeo;

            findOwnerPage.AddPet(dog.name,
                                 dog.birthDate,
                                 dog.type,
                                 owner.firstName,
                                 owner.lastName);

            findOwnerPage.CheckPet(dog.name,
                                   dog.birthDate,
                                   dog.type,
                                   owner.firstName,
                                   owner.lastName);
        }

        [Test]
        [Order(3)]
        public void EditOwnerTest() {
            var owner = PeopleData.Bartolomeo;
            var editedOwner = PeopleData.Pedro;

            findOwnerPage.EditOwnerData(owner.firstName,
                                        owner.lastName,
                                        editedOwner.firstName,
                                        editedOwner.lastName,
                                        editedOwner.address,
                                        editedOwner.city,
                                        editedOwner.phoneNumber);

            findOwnerPage.CheckOwner(editedOwner.firstName,
                                     editedOwner.lastName,
                                     editedOwner.address,
                                     editedOwner.city,
                                     editedOwner.phoneNumber);
        }
    }
}