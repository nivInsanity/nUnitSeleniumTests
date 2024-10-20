using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;
using OpenQA.Selenium.Support.UI;


namespace NunitSeleniumDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NunitSeleniumTest()
        {
            String path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            IWebDriver driver = new ChromeDriver(path + "\\drivers");
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:8080/";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.Until(driver => driver.Title == "PetClinic :: a Spring Framework demonstration");
            IWebElement btnFindOwners = driver.FindElement(By.XPath("//a[@title='find owners']"));
            btnFindOwners.Click();
            IWebElement btnAddOwner = driver.FindElement(By.XPath("//a[contains(text(), 'Add Owner')]")); 
            btnAddOwner.Click();

            IWebElement inpAddOwner = driver.FindElement(By.Id("firstName"));
            string firstName = "Bartolomeo";
            inpAddOwner.SendKeys(firstName);
            IWebElement inpLastName = driver.FindElement(By.Id("lastName"));
            string lastName = "Chaffinch";
            inpLastName.SendKeys(lastName);
            IWebElement inpAddress = driver.FindElement(By.Id("address"));
            string address = "Imagined 234/a";
            inpAddress.SendKeys(address);
            IWebElement inpCity = driver.FindElement(By.Id("city"));
            string city = "New York";
            inpCity.SendKeys(city);
            IWebElement inpTelephone = driver.FindElement(By.Id("telephone"));
            string phoneNumber = "1234567890";
            inpTelephone.SendKeys(phoneNumber);

            IWebElement btnScndAddOwner = driver.FindElement(By.XPath("//button[contains(text(), 'Add Owner')]"));

            btnScndAddOwner.Click();

            IWebElement btnScndFindOwners = driver.FindElement(By.XPath("//a[@title='find owners']"));
            btnScndFindOwners.Click();

            IWebElement inpScndLastName = driver.FindElement(By.Id("lastName"));
            inpScndLastName.SendKeys(lastName);

            IWebElement btnFindOwner = driver.FindElement(By.XPath("//button[contains(text(), 'Find')]"));
            btnFindOwner.Click();

            IWebElement btnOwner = driver.FindElement(By.XPath($"//a[contains(text(),'{firstName} {lastName}')]"));
            btnOwner.Click();

            IWebElement fldName = driver.FindElement(By.XPath("(//th[contains(text(),'Name')]/following::td)[1]"));
            string fldNameText = fldName.Text;
            IWebElement fldAddress = driver.FindElement(By.XPath("(//th[contains(text(),'Address')]/following::td)[1]"));
            string fldAddressText = fldAddress.Text;
            IWebElement fldCity = driver.FindElement(By.XPath("(//th[contains(text(),'City')]/following::td)[1]"));
            string fldCityText = fldCity.Text;
            IWebElement fldTelephone = driver.FindElement(By.XPath("(//th[contains(text(),'Telephone')]/following::td)[1]"));
            string fldTelephoneText = fldTelephone.Text;

            Assert.That(fldNameText, Is.EqualTo($"{firstName} {lastName}"));
            Assert.That(fldAddressText, Is.EqualTo(address));
            Assert.That(fldCityText, Is.EqualTo(city));
            Assert.That(fldTelephoneText, Is.EqualTo(phoneNumber));

            driver.Close();
            driver.Quit();

        }
    }
}